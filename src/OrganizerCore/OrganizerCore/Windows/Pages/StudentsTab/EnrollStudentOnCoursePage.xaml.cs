using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public partial class EnrollStudentOnCoursePage
{
	private readonly string[] _indicators = { "Неудовлетворительно", "Удовлетворительно", "Хорошо" };
	private readonly Student _student;

	public EnrollStudentOnCoursePage(Student student)
	{
		_student = student;

		InitializeComponent();
	}

	private static IEnumerable<Course> Courses => DataBaseConnection.Instance.Observe<Course>();

	private static IEnumerable<Group> Groups => DataBaseConnection.Instance.Observe<Group>();

	private static ObservableCollection<IndividualCoursesOfStudent> IndividualCourses
		=> DataBaseConnection.Instance.Observe<IndividualCoursesOfStudent>();

	private static ObservableCollection<GroupCoursesOfStudent> GroupCourses
		=> DataBaseConnection.Instance.Observe<GroupCoursesOfStudent>();

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private static string GroupDotCourseName => $"{nameof(GroupCoursesOfStudent.Group)}.{nameof(Group.Course)}";

	private static string IndividualLessonsCountName => nameof(IndividualCoursesOfStudent.LessonsCount);
	private static string GroupLessonsCountName      => nameof(GroupCoursesOfStudent.LessonsCount);

	private void OnPageLoad(object sender, RoutedEventArgs e)
	{
		StudentViewTextBlock.Text = _student.ToString();

		UpdateTablesView();
	}

	private void UpdateTablesView()
	{
		SetupIndividualDataGrid();
		SetupIndividualCoursesColumns();
		SetupGroupDataGrid();
		SetupGroupCoursesColumns();
	}

#region Individual courses table setup

	private void SetupIndividualDataGrid()
	{
		var studentsViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<IndividualCoursesOfStudent>(),
		};

		studentsViewSource.Filter += FilterIndividualCourses;
		IndividualCoursesDataGrid.ItemsSource = studentsViewSource.View;
	}

	private void FilterIndividualCourses(object sender, FilterEventArgs e)
	{
		var individualCourses = (IndividualCoursesOfStudent)e.Item;

		var fitsByName = individualCourses.Course.Title.Contains(CourseTitleSearchTextBox.Text);

		e.Accepted = individualCourses.Student == _student && fitsByName;
	}

	private void SetupIndividualCoursesColumns()
	{
		IndividualCoursesDataGrid.Columns.Clear();

		IndividualCoursesDataGrid.AddTextColumn("ID", nameof(IndividualCoursesOfStudent.Id), Visibility.Collapsed);
		IndividualCoursesDataGrid.AddComboBoxColumn
		(
			header: "Курс",
			binding: nameof(IndividualCoursesOfStudent.Course),
			itemsSource: Courses,
			displayMemberPath: nameof(Course.Title),
			selectedValuePath: nameof(Course.Id)
		);
		IndividualCoursesDataGrid.AddTextColumn("Дата начала", nameof(IndividualCoursesOfStudent.BeginningDate));
		IndividualCoursesDataGrid.AddTextColumn("Дата окончания", nameof(IndividualCoursesOfStudent.EndingDate));
		IndividualCoursesDataGrid.AddComboBoxColumn
		(
			header: "Показатель",
			binding: nameof(IndividualCoursesOfStudent.Indicator),
			itemsSource: _indicators
		);
		IndividualCoursesDataGrid.AddTextColumn("Количество занятий", IndividualLessonsCountName, isReadonly: true);
	}

#endregion

#region Group courses table setup

	private void SetupGroupDataGrid()
	{
		var studentsViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<GroupCoursesOfStudent>(),
		};

		studentsViewSource.Filter += FilterGroupCourses;
		GroupCoursesDataGrid.ItemsSource = studentsViewSource.View;
	}

	private void FilterGroupCourses(object sender, FilterEventArgs e)
	{
		var groupCourses = (GroupCoursesOfStudent)e.Item;

		var isForSelectedStudent = groupCourses.Student == _student;
		var fitsByCourseName = groupCourses.Group.Course.Title.Contains(CourseTitleSearchTextBox.Text);
		var fitsByGroupTitle = groupCourses.Group.Title.Contains(GroupTitleSearchTextBox.Text);

		e.Accepted = isForSelectedStudent && fitsByCourseName && fitsByGroupTitle;
	}

	private void SetupGroupCoursesColumns()
	{
		GroupCoursesDataGrid.Columns.Clear();

		GroupCoursesDataGrid.AddTextColumn("ID", nameof(GroupCoursesOfStudent.Id), Visibility.Collapsed);
		GroupCoursesDataGrid.AddComboBoxColumn
		(
			header: "Группа",
			binding: nameof(GroupCoursesOfStudent.Group),
			itemsSource: Groups,
			displayMemberPath: nameof(Group.Title),
			selectedValuePath: nameof(Group.Id)
		);
		GroupCoursesDataGrid.AddTextColumn("Курс", GroupDotCourseName, isReadonly: true);
		GroupCoursesDataGrid.AddComboBoxColumn
		(
			header: "Показатель",
			binding: nameof(GroupCoursesOfStudent.Indicator),
			itemsSource: _indicators
		);
		GroupCoursesDataGrid.AddTextColumn("Количество занятий", GroupLessonsCountName, isReadonly: true);
	}

#endregion

#region Individual courses CRUD

	private void AddIndividualButton_OnClick(object sender, RoutedEventArgs e)
	{
		var newCourse = new IndividualCoursesOfStudent
		{
			Course = Courses.First(),
			Student = _student,
			Indicator = _indicators.First(),
		};
		IndividualCourses.Add(newCourse);
		IndividualCoursesDataGrid.FocusOn(newCourse);
	}

	private void RemoveIndividualButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (IndividualCoursesDataGrid.SelectedItem is not IndividualCoursesOfStudent course)
		{
			MessageBoxUtils.AtFirstSelect("индивидуальный курс ученика");
			return;
		}

		IndividualCourses.Remove(course);
	}

#endregion

#region Group courses CRUD

	private void AddGroupButton_OnClick(object sender, RoutedEventArgs e)
	{
		var newCourse = new GroupCoursesOfStudent
		{
			Group = Groups.First(),
			Student = _student,
			Indicator = _indicators.First(),
		};
		GroupCourses.Add(newCourse);
		GroupCoursesDataGrid.FocusOn(newCourse);
	}

	private void RemoveGroupButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (GroupCoursesDataGrid.SelectedItem is not GroupCoursesOfStudent course)
		{
			MessageBoxUtils.AtFirstSelect("груповой курс ученика");
			return;
		}

		GroupCourses.Remove(course);
	}

#endregion

#region Event Handlers

	private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
	{
		Context.SaveChanges();
		NavigationService!.GoBack();
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DataBaseConnection.Instance.ResetAll();
		NavigationService!.GoBack();
	}

	private void OnFiltersTextChanged(object sender, TextChangedEventArgs e) => UpdateTablesView();

#endregion
}