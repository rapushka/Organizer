using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Model.Views;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;

namespace OrganizerCore.Windows.Pages.ScheduleTab;

public partial class FullSchedulePage
{
	public FullSchedulePage() => InitializeComponent();

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

#region Filters

	private bool ShowOnlyNotHeld => ShowAll || (OnlyNotHeldRadioButton?.IsChecked ?? false);

	private bool ShowOnlyHeld => ShowAll || (OnlyHeldRadioButton?.IsChecked ?? false);

	private bool ShowAll => ShowAllRadioButton?.IsChecked ?? false;

#endregion

	private void FullSchedulePage_OnLoaded(object sender, RoutedEventArgs e) => UpdateViewTable();

#region Table

	private void UpdateViewTable()
	{
		SetupTable();
		SetupColumns();
	}

	private void SetupTable()
	{
		var scheduleViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<Schedule>(),
		};

		scheduleViewSource.Filter += FilterTable;
		ScheduleViewDataGrid.ItemsSource = scheduleViewSource.View;
	}

	private void FilterTable(object sender, FilterEventArgs e)
	{
		var schedule = (Schedule)e.Item;
		var from = SearchFromDateTPicker?.SelectedDate;
		var to = SearchToDatePicker?.SelectedDate;
		var applyDatesFilter = ApplyDatesFilterCheckBox?.IsChecked ?? false;
		var showOnlyForToday = IsTodayCheckBox?.IsChecked ?? false;

		var fitsByLessonType = schedule.View.Lesson.Contains(SearchStudentTextBox.Text);
		var fitsByDates = applyDatesFilter == false
		                  || (showOnlyForToday && schedule.ScheduledTime.IsToday())
		                  || schedule.ScheduledTime.IsBetween(from, to);
		var fitsByHeld = (ShowOnlyHeld && schedule.IsHeld) || (ShowOnlyNotHeld && !schedule.IsHeld);

		e.Accepted = fitsByLessonType && fitsByDates && fitsByHeld;
	}

	private void SetupColumns()
	{
		ScheduleViewDataGrid.Columns.Clear();

		const string view = $"{nameof(Schedule.View)}.";

		// | Дата-Время | Курс | Занятие | Примечание | Проведено |
		ScheduleViewDataGrid.AddTextColumn("ID", nameof(Schedule.Id), Visibility.Collapsed);
		ScheduleViewDataGrid.AddTextColumn("Дата-Время", view + nameof(ScheduleView.ScheduledTime));
		ScheduleViewDataGrid.AddTextColumn("Курс", view + nameof(ScheduleView.CourseTitle));
		ScheduleViewDataGrid.AddTextColumn("Занятие", nameof(Schedule.Lessor));
		ScheduleViewDataGrid.AddTextColumn("Примечание", view + nameof(ScheduleView.Note));
		ScheduleViewDataGrid.AddTextColumn("Проведено", view + nameof(ScheduleView.IsHeld));
	}

#endregion

#region Upload

	private void UploadButton_OnClick(object sender, RoutedEventArgs e)
	{
		using var document = WordprocessingDocument.Create("Schedule.docx", WordprocessingDocumentType.Document);
		var mainPart = document.AddMainDocumentPart();

		mainPart.Document = new Document();
		var body = mainPart.Document.AppendChild(new Body());

		var now = DateTime.Now;
		var endOfDay = now.Date.AddDays(1).AddSeconds(-1); // end of day is start of next day minus one second

		var schedules = Context.Schedules
		                       .Where(s => s.ScheduledTime >= now && s.ScheduledTime <= endOfDay && !s.IsHeld)
		                       .OrderBy(s => s.ScheduledTime)
		                       .ToList();

		if (schedules.Any() == false)
		{
			var noSchedulesParagraph = new Paragraph(new Run(new Text("No schedules found for today.")));
			body.AppendChild(noSchedulesParagraph);

			mainPart.Document.Save();
			return;
		}

		var groupedSchedules = schedules.GroupBy(s => s.IsGroup ? s.Group.Title : s.IndividualCourse.Course.Title);

		foreach (var group in groupedSchedules)
		{
			var table = new Table();
			var properties = new TableProperties
			(
				new TableBorders
				(
					new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
					new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
					new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
					new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
					new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
					new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
				)
			);
			table.AppendChild(properties);

			var typeCell = new TableCell(new Paragraph(new Run(new Text($"Type: {group.Key}"))));
			var typeRow = new TableRow(typeCell);
			table.AppendChild(typeRow);

			foreach (var schedule in group)
			{
				var scheduleRow = new TableRow
				(
					new TableCell
					(
						new Paragraph
							(new Run(new Text($"Scheduled Time: {schedule.ScheduledTime:yyyy/MM/dd HH:mm:ss}")))
					),
					new TableCell(new Paragraph(new Run(new Text($"Note: {schedule.Note}"))))
				);
				table.AppendChild(scheduleRow);
			}

			body.AppendChild(table);
		}

		mainPart.Document.Save();
	}

#endregion

#region Held

	private void HeldButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureSelected(out var schedule) == false
		    || CanBeHelded(schedule!) == false)
		{
			return;
		}

		if (schedule!.IsHeld == false)
		{
			schedule.IsHeld = true;
			MessageBoxUtils.ShowInfo("Занятие успешно проведено!");
		}
		else
		{
			UnHeldSchedule(schedule);
		}

		Context.SaveChanges();
	}

	private void UnHeldSchedule(Schedule schedule)
	{
		if (MessageBoxUtils.ShowEnsure("Занятие уже проведено. Вы хотите отменить проведение?"))
		{
			schedule.IsHeld = false;
		}
	}

	private static bool CanBeHelded(Schedule schedule)
	{
		var lessonsCount = schedule.IsGroup
			? schedule.Group.Course.LessonsCount
			: schedule.IndividualCourse.LessonsCount;

		var anyLessonsLeft = lessonsCount > 0;
		if (anyLessonsLeft == false)
		{
			MessageBoxUtils.ShowError("Все уроки по данному курсу уже проведены!");
		}

		return anyLessonsLeft;
	}

#endregion

#region CRUD

	private void AddButton_OnClick(object sender, RoutedEventArgs e)
	{
		var schedule = new Schedule
		{
			IndividualCourse = Context.IndividualCourses.First(),
			ScheduledTime = DateTime.Now,
			IsHeld = false,
			Note = string.Empty,
		};
		Context.Schedules.Add(schedule);
		NavigationService!.Navigate(new EditSchedulePage(schedule));
	}

	private void EditButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureSelected(out var schedule))
		{
			NavigationService!.Navigate(new EditSchedulePage(schedule!));
		}
	}

	private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureSelected(out var schedule)
		    && MessageBoxUtils.ConfirmDeletion(schedule!))
		{
			Context.Schedules.Observe().Remove(schedule!);
			Context.SaveChanges();
		}
	}

	private bool EnsureSelected(out Schedule? schedule)
	{
		schedule = ScheduleViewDataGrid.SelectedItem as Schedule;
		if (schedule is null)
		{
			MessageBoxUtils.AtFirstSelect("рассписание");
		}

		return schedule is not null;
	}

#endregion

#region Update filters

	private void RadioButton_Click(object sender, RoutedEventArgs e) => UpdateViewTable();

	private void UpdateFrom_TextBox(object sender, TextChangedEventArgs e) => UpdateViewTable();

	private void UpdateFrom_CheckBox(object sender, RoutedEventArgs e) => UpdateViewTable();

	private void UpdateFrom_DatePicker(object? sender, SelectionChangedEventArgs e) => UpdateViewTable();

#endregion
}