using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Organizer.DbWorking;
using Organizer.Model;
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
		TopicsOfCourseDataGrid.AddColumn("Количество занятий", nameof(Topic.CountOfLessons));
	}

	private void EditSelectedTopicButton_Click(object sender, RoutedEventArgs e)
	{
		if (TopicsOfCourseDataGrid.SelectedItem is Topic selectedTopic)
		{
			EditTopic(selectedTopic);
		}
	}

	private void AddTopicButton_Click(object sender, RoutedEventArgs e) => EditTopic(new Topic());

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

	private void EditTopic(Topic topic) => NavigationService!.Navigate(new TopicEditPage(topic));
}