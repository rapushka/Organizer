using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public partial class StudentsListPage
{
	private bool _isIndividualShown;

	public StudentsListPage() => InitializeComponent();

	private Student SelectedStudent => (Student)StudentsDataGrid.SelectedItem;

	private void StudentsListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		SetupStudentsDataGrid();
		SetupStudentsColumns();
		IsIndividualShown = true;
	}

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private bool IsIndividualShown
	{
		set
		{
			_isIndividualShown = value;
			UpdateCoursesView();
		}
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

#region Courses Table setup

	private void ShowIndividualCourses() => IsIndividualShown = true;

	private void ShowGroupCourses() => IsIndividualShown = false;

	private void UpdateCoursesView()
	{
		if (_isIndividualShown)
		{
			SetupForCoursesTable<IndividualCoursesOfStudent>();
			SetupStudentIndividualCoursesColumns();
		}
		else
		{
			SetupForCoursesTable<GroupCoursesOfStudent>();
			SetupStudentGroupCoursesColumns();
		}
	}

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
			e.Accepted = individualCourse.Student == SelectedStudent
			             && individualCourse.Course.Title.Contains(CourseTitleSearchTextBox.Text)
			             && individualCourse.Indicator == IndicatorSearchComboBox.GetSelectedText();
			return;
		}

		if (e.Item is GroupCoursesOfStudent groupCourse)
		{
			e.Accepted = groupCourse.Student == SelectedStudent
			             && groupCourse.Group.Course.Title.Contains(CourseTitleSearchTextBox.Text)
			             && groupCourse.Indicator == IndicatorSearchComboBox.GetSelectedText();
			return;
		}

		throw new Exception($"Item is {e.Item.GetType().Name}!");
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

#region Events Handlers

	private void ShowIndividualCoursesButton_Click(object sender, RoutedEventArgs e) => ShowIndividualCourses();

	private void ShowGroupCoursesButton_Click(object sender, RoutedEventArgs e) => ShowGroupCourses();

	private void FullnameSearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => SetupStudentsDataGrid();

	private void OnPickedBirthdateChanged(object? sender, SelectionChangedEventArgs e) => SetupStudentsDataGrid();

	private void OnIndicatorSelected(object sender, SelectionChangedEventArgs e) => UpdateCoursesView();

	private void CourseTitleSearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => UpdateCoursesView();

	private void EnrollStudentButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureStudentSelected(out var selectedStudent))
		{
			NavigationService!.Navigate(new EnrollStudentOnCoursePage(selectedStudent!));
		}
	}

#endregion

#region Students CRUD

	private void OnStudentAdded(Student student)
	{
		Context.Students.Add(student);
		Context.SaveChanges();
	}

	private static void OnStudentEdited(Student student)
	{
		var oldStudent = Context.Students.Single((c) => c.Id == student.Id);
		oldStudent.Copy(student);
		Context.SaveChanges();
	}

	private void AddStudentButton_OnClick(object sender, RoutedEventArgs e)
	{
		var page = new EditStudentPage();
		page.Applied += OnStudentAdded;
		NavigationService!.Navigate(page);
	}

	private void EditStudentButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureStudentSelected(out var selectedStudent))
		{
			var page = new EditStudentPage(selectedStudent!);
			page.Applied += OnStudentEdited;
			NavigationService!.Navigate(page);
		}
	}

	private void RemoveStudentButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureStudentSelected(out var selectedStudent)
		    && MessageBoxUtils.ConfirmDeletion(of: selectedStudent!))
		{
			Context.Students.Remove(selectedStudent!);
			Context.SaveChanges();
		}
	}

	private bool EnsureStudentSelected(out Student? selectedStudent)
	{
		selectedStudent = StudentsDataGrid.SelectedItem as Student;

		if (selectedStudent is null)
		{
			MessageBoxUtils.AtFirstSelect("студента");
		}

		return selectedStudent is not null;
	}

#endregion
}