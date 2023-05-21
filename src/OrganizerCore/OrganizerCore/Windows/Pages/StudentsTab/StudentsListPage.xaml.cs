using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public partial class StudentsListPage
{
	public StudentsListPage() => InitializeComponent();

	private void ShowIndividualCoursesButton_Click(object sender, RoutedEventArgs e) { }

	private void ShowGroupCoursesButton_Click(object sender, RoutedEventArgs e) { }

	private void FullnameSearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => SetupStudentsDataGrid();

	private void OnPickedBirthdateChanged(object? sender, SelectionChangedEventArgs e) => SetupStudentsDataGrid();

	private void StudentsListPage_OnLoaded(object sender, RoutedEventArgs e) => SetupStudentsDataGrid();

	private void SetupStudentsDataGrid()
	{
		var studentsViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<Student>(),
		};

		studentsViewSource.Filter += FilterStudents;
		StudentsDataGrid.ItemsSource = studentsViewSource.View;
	}

	private void FilterStudents(object sender, FilterEventArgs e)
	{
		var from = FromBirthdateDatePicker.SelectedDate;
		var to = ToBirthdateDatePicker.SelectedDate;
		var student = (Student)e.Item;

		var fitsByBirthdate = (from is null || student.Birthdate >= from) && (to is null || student.Birthdate <= to);
		var fitsByName = student.FullName.Contains(FullnameSearchTextBox.Text);

		e.Accepted = fitsByName && fitsByBirthdate;
	}
}