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

	public Student SelectedStudent => (Student)StudentsDataGrid.SelectedItem;

	private void StudentsListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		SetupStudentsDataGrid();
		SetupStudentsColumns();
		ShowIndividualCourses();
	}

#region Students Table setup

	private void SetupStudentsDataGrid()
	{
		var studentsViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<Student>(),
		};

		studentsViewSource.Filter += FilterStudents;
		StudentsDataGrid.ItemsSource = studentsViewSource.View;
	}

	private void SetupStudentsColumns()
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

#endregion

	private void ShowIndividualCourses()
	{
		SetupForCoursesTable<IndividualCoursesOfStudent>();
		SetupStudentIndividualCoursesColumns();
	}

	private void ShowGroupCourses()
	{
		SetupForCoursesTable<GroupCoursesOfStudent>();
		SetupStudentGroupCoursesColumns();
	}

#region Courses Table setup

	private void SetupForCoursesTable<T>()
		where T : class
	{
		var lessonsViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<T>(),
		};

		lessonsViewSource.Filter += FilterCoursesBySelectedStudent;
		CoursesOfStudentDataGrid.ItemsSource = lessonsViewSource.View;
	}

	private void FilterCoursesBySelectedStudent(object sender, FilterEventArgs e)
	{
		if (e.Item is IndividualCoursesOfStudent individualCourse)
		{
			e.Accepted = individualCourse.Student == SelectedStudent;
		}

		if (e.Item is GroupCoursesOfStudent groupCourse)
		{
			e.Accepted = groupCourse.Student == SelectedStudent;
		}
	}

	private void SetupStudentGroupCoursesColumns()
	{
		CoursesOfStudentDataGrid.Columns.Clear();

		CoursesOfStudentDataGrid.AddTextColumn("ID", nameof(GroupCoursesOfStudent.Id), Visibility.Collapsed);
		CoursesOfStudentDataGrid.AddTextColumn("Группа", nameof(GroupCoursesOfStudent.Group));
		CoursesOfStudentDataGrid.AddTextColumn("Показатель", nameof(GroupCoursesOfStudent.Indicator));
		CoursesOfStudentDataGrid.AddTextColumn("Количество занятий", nameof(GroupCoursesOfStudent.LessonsCount));
	}

	private void SetupStudentIndividualCoursesColumns()
	{
		CoursesOfStudentDataGrid.Columns.Clear();

		CoursesOfStudentDataGrid.AddTextColumn("ID", nameof(IndividualCoursesOfStudent.Id), Visibility.Collapsed);
		CoursesOfStudentDataGrid.AddTextColumn("Курс", nameof(IndividualCoursesOfStudent.Course));
		CoursesOfStudentDataGrid.AddTextColumn("Дата начала", nameof(IndividualCoursesOfStudent.BeginningDate));
		CoursesOfStudentDataGrid.AddTextColumn("Дата окончания", nameof(IndividualCoursesOfStudent.EndingDate));
		CoursesOfStudentDataGrid.AddTextColumn("Показатель", nameof(IndividualCoursesOfStudent.Indicator));
		CoursesOfStudentDataGrid.AddTextColumn("Количество занятий", nameof(IndividualCoursesOfStudent.LessonsCount));
	}

#endregion

	private void ShowIndividualCoursesButton_Click(object sender, RoutedEventArgs e) => ShowIndividualCourses();

	private void ShowGroupCoursesButton_Click(object sender, RoutedEventArgs e) => ShowGroupCourses();

	private void FullnameSearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => SetupStudentsDataGrid();

	private void OnPickedBirthdateChanged(object? sender, SelectionChangedEventArgs e) => SetupStudentsDataGrid();
}