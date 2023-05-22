using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools.Extensions;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public partial class EnrollStudentOnCoursePage
{
	private Student _student;

	public EnrollStudentOnCoursePage(Student student)
	{
		_student = student;

		InitializeComponent();
	}

	private static IEnumerable<Course> Courses => DataBaseConnection.Instance.Observe<Course>();

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private void OnPageLoad(object sender, RoutedEventArgs e)
	{
		StudentViewTextBlock.Text = _student.ToString();
		
		SetupIndividualCoursesColumns();
		SetupStudentsDataGrid();
	}

#region Individual courses

	private void SetupStudentsDataGrid()
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
		IndividualCoursesDataGrid.AddComboBoxEnumColumn
		(
			header: "Показатель",
			binding: nameof(IndividualCoursesOfStudent.Indicator),
			itemsSource: new[] { "Неудовлетворительно", "Удовлетворительно", "Хорошо" }
		);
	}

#endregion

	private void ButtonBase_OnClick(object sender, RoutedEventArgs e) => NavigationService!.GoBack();
}