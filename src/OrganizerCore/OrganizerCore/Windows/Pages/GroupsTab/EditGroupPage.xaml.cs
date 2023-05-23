using System;
using System.Windows;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;
using static System.Globalization.CultureInfo;

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

	private void Load()
	{
		TitleTextBox.Text = _group.Title;
		CourseTextBox.Text = _group.Course.Title;
		BeginDatePiker.Text = _group.BeginningDate.ToString(InvariantCulture);
		EndDatePiker.Text = _group.EndingDate.ToString(InvariantCulture);
		MinAgeTextBox.Text = _group.MinAge.ToString();
		MaxAgeTextBox.Text = _group.MaxAge.ToString();
		PlacesCountTextBox.Text = _group.MaxStudentsInGroupCount.ToString();
	}

	private bool TrySave()
	{
		var canParseBeginDate = DateTime.TryParse(BeginDatePiker.Text, out var beginDate);
		var canParseEdnDate = DateTime.TryParse(EndDatePiker.Text, out var endDate);
		var canParseMinAge = int.TryParse(MinAgeTextBox.Text, out var minAge);
		var canParseMaxAge = int.TryParse(MaxAgeTextBox.Text, out var maxAge);
		var canParsePlacesCount = int.TryParse(PlacesCountTextBox.Text, out var placesCount);

		var valid = canParseBeginDate && canParseEdnDate && canParseMinAge && canParseMaxAge && canParsePlacesCount;

		if (valid)
		{
			_group.Title = TitleTextBox.Text;
			_group.Course.Title = CourseTextBox.Text;
			_group.BeginningDate = beginDate;
			_group.EndingDate = endDate;
			_group.MinAge = minAge;
			_group.MaxAge = maxAge;
			_group.MaxStudentsInGroupCount = placesCount;
			return true;
		}

		MessageBoxUtils.ShowError("Данные введены некорректно!");
		return false;
	}

	private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
	{
		Context.SaveChanges();
		NavigationService!.GoBack();
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DataBaseConnection.Instance.ResetAll();
		NavigationService!.GoBack();
	}
}