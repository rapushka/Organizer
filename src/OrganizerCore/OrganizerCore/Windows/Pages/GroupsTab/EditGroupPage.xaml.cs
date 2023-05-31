using System;
using System.Windows;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Windows.Pages.Courses_Tab;

namespace OrganizerCore.Windows.Pages.GroupsTab;

public partial class EditGroupPage
{
	private readonly Group _group;

	public EditGroupPage(Group group)
	{
		_group = group;

		InitializeComponent();
	}

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private void EditGroupPage_OnLoaded(object sender, RoutedEventArgs e) => Load();

	private void Load()
	{
		TitleTextBox.Text = _group.Title;
		SetupCourseComboBox();
		BeginDatePiker.SelectedDate = _group.BeginningDate;
		EndDatePiker.SelectedDate = _group.EndingDate;
		MinAgeTextBox.Text = _group.MinAge.ToString();
		MaxAgeTextBox.Text = _group.MaxAge.ToString();
		PlacesCountTextBox.Text = _group.MaxStudentsInGroupCount.ToString();
	}

	private void SetupCourseComboBox()
	{
		CourseComboBox.ItemsSource = Context.Courses.Observe();
		CourseComboBox.SelectedValuePath = nameof(Course.Id);
		CourseComboBox.DisplayMemberPath = nameof(Course.Title);
		CourseComboBox.SelectedValue = _group.Course.Id;
	}

	private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (TrySave())
		{
			Context.SaveChanges();
			NavigationService!.GoBack();
		}
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DataBaseConnection.Instance.ResetAll();
		NavigationService!.GoBack();
	}

	private bool TrySave()
	{
		var beginDate = BeginDatePiker.SelectedDate ?? DateTime.Now;
		var endDate = EndDatePiker.SelectedDate ?? DateTime.Now;

		var isValidDates = beginDate < endDate;

		var canParseMinAge = int.TryParse(MinAgeTextBox.Text, out var minAge);
		var canParseMaxAge = int.TryParse(MaxAgeTextBox.Text, out var maxAge);
		var canParsePlacesCount = int.TryParse(PlacesCountTextBox.Text, out var placesCount);

		var valid = isValidDates && canParseMinAge && canParseMaxAge && canParsePlacesCount;

		if (InNoEmpty == false)
		{
			MessageBoxUtils.ShowError("Не все поля заполнены");
		}

		if (valid == false)
		{
			MessageBoxUtils.ShowError("Данные введены некорректно!");
			return false;
		}

		_group.Title = TitleTextBox.Text;
		_group.Course = (Course)CourseComboBox.SelectedItem;
		_group.BeginningDate = beginDate;
		_group.EndingDate = endDate;
		_group.MinAge = minAge;
		_group.MaxAge = maxAge;
		_group.MaxStudentsInGroupCount = placesCount;
		return true;
	}

	private bool InNoEmpty
		=> TitleTextBox.IsNotEmpty()
		   && CourseComboBox.IsNotEmpty()
		   && MinAgeTextBox.IsNotEmpty()
		   && MaxAgeTextBox.IsNotEmpty()
		   && PlacesCountTextBox.IsNotEmpty()
		   && BeginDatePiker.IsNotEmpty()
		   && EndDatePiker.IsNotEmpty();
}