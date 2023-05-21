using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools.Extensions;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public partial class StudentsListPage
{
	public StudentsListPage() => InitializeComponent();

	private void StudentsListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		SetupStudentsDataGrid();
		SetupCoursesColumns();
	}

	private void ShowIndividualCoursesButton_Click(object sender, RoutedEventArgs e) { }

	private void ShowGroupCoursesButton_Click(object sender, RoutedEventArgs e) { }

	private void FullnameSearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => SetupStudentsDataGrid();

	private void OnPickedBirthdateChanged(object? sender, SelectionChangedEventArgs e) => SetupStudentsDataGrid();

	private void SetupStudentsDataGrid()
	{
		var studentsViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<Student>(),
		};

		studentsViewSource.Filter += FilterStudents;
		StudentsDataGrid.ItemsSource = studentsViewSource.View;
	}

	private void SetupCoursesColumns()
	{
		StudentsDataGrid.Columns.Clear();

		StudentsDataGrid.AddTextColumn("ID", nameof(Student.Id), Visibility.Collapsed);
		StudentsDataGrid.AddTextColumn("ФИО", nameof(Student.FullName));
		StudentsDataGrid.AddTextColumn("Номер телефона", nameof(Student.PhoneNumber));
		StudentsDataGrid.AddTextColumn("Дата рождения", nameof(Student.Birthdate));
		StudentsDataGrid.AddTextColumn("Электронная почта", nameof(Student.Email));
		StudentsDataGrid.AddTextColumn("ФИО доверенного лица", nameof(Student.ProxyFullName));
		StudentsDataGrid.AddTextColumn("Номер телефона доверенного лица", nameof(Student.ProxyPhoneNumber));
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