using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools.Extensions;

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

		CoursesDataGrid.AddTextColumn("ID", nameof(Course.Id), Visibility.Collapsed);
		CoursesDataGrid.AddTextColumn("Название", nameof(Course.Title));
		CoursesDataGrid.AddTextColumn("Описание", nameof(Course.Description));
		CoursesDataGrid.AddTextColumn("Продолжительность", nameof(Course.Duration));
		CoursesDataGrid.AddTextColumn("Стоимость", nameof(Course.Price));
		CoursesDataGrid.AddTextColumn("Количество занятий", nameof(Course.LessonsCount));
	}

	private void SetupTopicsOfCourseDataGrid()
	{
		TopicsOfCourseDataGrid.Columns.Clear();

		TopicsOfCourseDataGrid.AddTextColumn("ID", nameof(Topic.Id), Visibility.Collapsed);
		TopicsOfCourseDataGrid.AddTextColumn("Название", nameof(Topic.Title));
		TopicsOfCourseDataGrid.AddTextColumn("Количество занятий", nameof(Topic.CountOfLessons));
	}

	private void CoursesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (CoursesDataGrid.SelectedItem is Course selectedCourse)
		{
			TopicsOfCourseDataGrid.ItemsSource = Context.Topics.Where((t) => t.Course == selectedCourse).ToList();
		}
	}

	private void AddCourseButton_Click(object sender, RoutedEventArgs e)
	{
		// NavigationService.Navigate(new AddCourse());
	}

	private void AddTopicButton_Click(object sender, RoutedEventArgs e) => EditTopic(new Topic());

	private void EditSelectedTopicButton_Click(object sender, RoutedEventArgs e)
	{
		if (TopicsOfCourseDataGrid.SelectedItem is Topic selectedTopic)
		{
			EditTopic(selectedTopic);
		}
	}

	private void EditTopic(Topic topic) => NavigationService!.Navigate(new TopicEditPage(topic));
}