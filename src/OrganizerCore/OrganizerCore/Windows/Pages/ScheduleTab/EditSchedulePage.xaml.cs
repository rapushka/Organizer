using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Windows.Pages.Courses_Tab;

namespace OrganizerCore.Windows.Pages.ScheduleTab;

public partial class EditSchedulePage
{
	private readonly Schedule _schedule;

	public EditSchedulePage(Schedule schedule)
	{
		_schedule = schedule;
		InitializeComponent();
	}

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private CourseTypeShow CourseTypeShow
	{
		get => ShowAllRadioButton.IsChecked ?? false       ? CourseTypeShow.All
			: OnlyIndividualRadioButton.IsChecked ?? false ? CourseTypeShow.Individual
			: OnlyGroupRadioButton.IsChecked ?? false      ? CourseTypeShow.Group : throw new ArgumentException();
		set
		{
			if (value is CourseTypeShow.All)
			{
				ShowAllRadioButton.IsChecked = true;
			}
			else if (value is CourseTypeShow.Individual)
			{
				OnlyIndividualRadioButton.IsChecked = true;
			}
			else if (value is CourseTypeShow.Group)
			{
				OnlyGroupRadioButton.IsChecked = true;
			}
		}
	}

	private void Page_Load(object sender, RoutedEventArgs e)
	{
		Load();
		SetupCoursesComboBox();
	}

	private void SetupCoursesComboBox()
	{
		CourseComboBox.ItemsSource = Context.Courses.Observe();
	}

	private void RadioButton_Click(object sender, RoutedEventArgs e) => UpdateLessorComboBox();

	private void CourseComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		=> UpdateLessorComboBox();

	private void UpdateLessorComboBox()
	{
		if (CourseComboBox.SelectedItem is not Course selectedCourse)
		{
			DisableLessonComboBox();
			return;
		}

		var groups = GetGroupsFor(selectedCourse);
		var individualCourses = GetIndividualCoursesFor(selectedCourse);

		LessonComboBox.ItemsSource = PickCollectionByTypeFilter(individualCourses, groups);
		LessonComboBox.IsEnabled = true;
	}

	private void DisableLessonComboBox()
	{
		LessonComboBox.ItemsSource = null;
		LessonComboBox.SelectedItem = null;
		LessonComboBox.IsEnabled = false;
	}

	private IEnumerable<object> PickCollectionByTypeFilter
		(IEnumerable<IndividualCoursesOfStudent> individualCourses, IEnumerable<Group> groups)
		=> CourseTypeShow switch
		{
			CourseTypeShow.All        => individualCourses.Concat(groups.Cast<object>()),
			CourseTypeShow.Group      => groups,
			CourseTypeShow.Individual => individualCourses,
			_                         => throw new Exception()
		};

	private static IEnumerable<IndividualCoursesOfStudent> GetIndividualCoursesFor(Course selectedCourse)
		=> Context.IndividualCourses.Observe().Where((ic) => ic.Course == selectedCourse);

	private static IEnumerable<Group> GetGroupsFor(Course selectedCourse)
		=> Context.Groups.Observe().Where((g) => g.Course == selectedCourse);

#region Save-Load

	private void Load()
	{
		CourseTypeShow = CourseTypeShow.All;
		CourseComboBox.SelectedItem = _schedule.View.Course;
		LessonComboBox.SelectedItem = _schedule.Lessor;
		DateTimePicker.Value = _schedule.ScheduledTime;
		NoteTextBox.Text = _schedule.Note;
	}

	private void Save()
	{
		if (IsNoEmpty == false)
		{
			throw new InvalidOperationException("Не все поля заполнены!");
		}

		_schedule.View.Course = (Course)CourseComboBox.SelectedItem;
		_schedule.Lessor = LessonComboBox.SelectedItem;
		_schedule.ScheduledTime = DateTimePicker.Value ?? DateTime.MinValue;
		_schedule.Note = NoteTextBox.Text;
	}

#endregion

#region Apply/Cancel

	private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
	{
		try
		{
			Save();
			Context.SaveChanges();
			NavigationService!.GoBack();
		}
		catch (Exception ex)
		{
			MessageBoxUtils.ShowException(ex);
		}
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DataBaseConnection.Instance.ResetAll();
		NavigationService!.GoBack();
	}

#endregion

	private void DateTimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e) { }

	private bool IsNoEmpty
		=> CourseComboBox.IsNotEmpty()
		   && LessonComboBox.IsNotEmpty()
		   && DateTimePicker.IsNotEmpty();
}

public enum CourseTypeShow
{
	All,
	Individual,
	Group,
}