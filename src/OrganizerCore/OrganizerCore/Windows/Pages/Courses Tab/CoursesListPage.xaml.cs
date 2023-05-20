using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;

namespace OrganizerCore.Windows.Pages;

public partial class CoursesListPage
{
	public CoursesListPage() => InitializeComponent();

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private ObservableCollection<Topic> TopicsOfCourse => DataBaseConnection.Instance.Observe<Topic>();

	private Course SelectedCourse => (Course)CoursesDataGrid.SelectedItem;

	private void Page_Loaded(object sender, RoutedEventArgs e)
	{
		var courses = Context.Courses.ToList();

		CoursesDataGrid.ItemsSource = courses;

		DataGridsSetup();
	}

	private void DataGridsSetup()
	{
		SetupCoursesColumns();
		SetupTopicsOfCoursesList();
		SetupTopicsOfCourseColumns();
	}

	private void SetupCoursesColumns()
	{
		CoursesDataGrid.Columns.Clear();

		CoursesDataGrid.AddTextColumn("ID", nameof(Course.Id), Visibility.Collapsed);
		CoursesDataGrid.AddTextColumn("Название", nameof(Course.Title));
		CoursesDataGrid.AddTextColumn("Описание", nameof(Course.Description));
		CoursesDataGrid.AddTextColumn("Продолжительность", nameof(Course.Duration));
		CoursesDataGrid.AddTextColumn("Стоимость", nameof(Course.Price));
		CoursesDataGrid.AddTextColumn("Количество занятий", nameof(Course.LessonsCount));
	}

	private void SetupTopicsOfCoursesList()
	{
		var lessonsViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<Topic>(),
		};

		lessonsViewSource.Filter += LessonsViewSource_Filter;
		TopicsOfCourseDataGrid.ItemsSource = lessonsViewSource.View;
	}

	private void LessonsViewSource_Filter(object sender, FilterEventArgs e)
		=> e.Accepted = (e.Item as Topic)?.Course == SelectedCourse;

	private void SetupTopicsOfCourseColumns()
	{
		TopicsOfCourseDataGrid.Columns.Clear();

		TopicsOfCourseDataGrid.AddTextColumn("ID", nameof(Topic.Id), Visibility.Collapsed);
		TopicsOfCourseDataGrid.AddTextColumn("Название", nameof(Topic.Title));
		TopicsOfCourseDataGrid.AddTextColumn("Количество занятий", nameof(Topic.CountOfLessons));
	}

	private void CoursesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		=> TopicsOfCourseDataGrid.ItemsSource = Context.Topics.Where((t) => t.Course == SelectedCourse).ToList();

	private void AddCourseButton_Click(object sender, RoutedEventArgs e)
	{
		// NavigationService.Navigate(new AddCourse());
	}

	private void AddTopicButton_Click(object sender, RoutedEventArgs e)
	{
		if (CoursesDataGrid.SelectedItem is not Course selectedCourse)
		{
			MessageBoxUtils.ShowError("Сначала выберите курс!");
			return;
		}

		var topic = new Topic
		{
			Course = selectedCourse,
		};

		TopicsOfCourse.Add(topic);
		EditTopic(topic);
	}

	private void EditSelectedTopicButton_Click(object sender, RoutedEventArgs e)
	{
		if (EnsureCourseSelected(out var selectedTopic))
		{
			EditTopic(selectedTopic!);
		}
	}

	private bool EnsureCourseSelected(out Topic? selectedTopic)
	{
		selectedTopic = TopicsOfCourseDataGrid.SelectedItem as Topic;
		if (selectedTopic is null)
		{
			MessageBoxUtils.ShowError("Сначала выберите тему!");
		}

		return selectedTopic is null;
	}

	private void EditTopic(Topic topic) => NavigationService!.Navigate(new TopicEditPage(topic));

	private void CoursesDataGrid_OnLostFocus(object sender, RoutedEventArgs e) => Context.SaveChanges();
}