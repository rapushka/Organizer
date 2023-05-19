using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Organizer.DbWorking;
using Organizer.Model;

namespace OrganizerCore.Windows.Pages;

public partial class CoursesListPage
{
	public CoursesListPage() => InitializeComponent();

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private void Page_Loaded(object sender, RoutedEventArgs e)
	{
		var courses = Context.Courses.ToList();

		CoursesDataGrid.ItemsSource = courses;

		ApplyCustomColumns();
	}

	private void ApplyCustomColumns()
	{
		SetupCoursesDataGrid();
		SetupTopicsOfCourseDataGrid();
	}

	private void SetupCoursesDataGrid()
	{
		CoursesDataGrid.Columns.Clear();

		CoursesDataGrid.AddColumn("ID", nameof(Course.Id), Visibility.Collapsed);
		CoursesDataGrid.AddColumn("Название", nameof(Course.Title));
		CoursesDataGrid.AddColumn("Описание", nameof(Course.Description));
		CoursesDataGrid.AddColumn("Продолжительность", nameof(Course.Duration));
		CoursesDataGrid.AddColumn("Стоимость", nameof(Course.Price));
		CoursesDataGrid.AddColumn("Количество занятий", nameof(Course.LessonsCount));
	}

	private void SetupTopicsOfCourseDataGrid()
	{
		TopicsOfCourseDataGrid.Columns.Clear();

		TopicsOfCourseDataGrid.AddColumn("ID", nameof(Topic.Id), Visibility.Collapsed);
		TopicsOfCourseDataGrid.AddColumn("Название", nameof(Topic.Title));
	}

	private void AddLessonButton_Click(object sender, RoutedEventArgs e)
	{
		// NavigationService.Navigate(new View_Subject());
	}

	private void AddCourseButton_Click(object sender, RoutedEventArgs e)
	{
		// NavigationService.Navigate(new AddCourse());
	}

	private void CoursesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (CoursesDataGrid.SelectedItem is Course selectedCourse)
		{
			TopicsOfCourseDataGrid.ItemsSource = Context.Topics.Where((t) => t.Course == selectedCourse).ToList();
		}
	}
}

public static class DataGridExtensions
{
	public static void AddColumn
		(this DataGrid @this, string header, string binding, Visibility visibility = Visibility.Visible)
	{
		@this.Columns.Add
		(
			new DataGridTextColumn
			{
				Header = header,
				Binding = new Binding(binding),
				Visibility = visibility,
			}
		);
	}
}