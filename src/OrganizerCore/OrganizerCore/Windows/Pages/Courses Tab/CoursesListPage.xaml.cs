using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;
using OrganizerCore.Windows.Pages.Courses_Tab;

namespace OrganizerCore.Windows.Pages;

public partial class CoursesListPage
{
	public CoursesListPage() => InitializeComponent();

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private static ObservableCollection<Topic> Topics => DataBaseConnection.Instance.Observe<Topic>();

	private static ObservableCollection<Course> Courses => DataBaseConnection.Instance.Observe<Course>();

	private Course SelectedCourse => (Course)CoursesDataGrid.SelectedItem;

	private void Page_Loaded(object sender, RoutedEventArgs e) => DataGridsSetup();

	private void DataGridsSetup()
	{
		SetupCoursesList();
		SetupCoursesColumns();
		SetupTopicsOfCoursesList();
		SetupTopicsOfCourseColumns();
	}

	private void SetupCoursesList()
	{
		var coursesViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<Course>(),
		};

		coursesViewSource.Filter += FilterCoursesByTitleSearch;
		CoursesDataGrid.ItemsSource = coursesViewSource.View;
	}

	private void FilterCoursesByTitleSearch(object sender, FilterEventArgs e)
		=> e.Accepted = ((Course)e.Item).Title.Contains(SearchByNameTextBox.Text);

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

		lessonsViewSource.Filter += FilterTopicsBySelectedCourse;
		TopicsOfCourseDataGrid.ItemsSource = lessonsViewSource.View;
	}

	private void FilterTopicsBySelectedCourse(object sender, FilterEventArgs e)
		=> e.Accepted = ((Topic)e.Item).Course == SelectedCourse;

	private void SetupTopicsOfCourseColumns()
	{
		TopicsOfCourseDataGrid.Columns.Clear();

		TopicsOfCourseDataGrid.AddTextColumn("ID", nameof(Topic.Id), Visibility.Collapsed);
		TopicsOfCourseDataGrid.AddTextColumn("Название", nameof(Topic.Title));
		TopicsOfCourseDataGrid.AddTextColumn("Количество занятий", nameof(Topic.CountOfLessons));
	}

	private void SearchByTitleTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => SetupCoursesList();

	private void CoursesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		=> SetupTopicsOfCoursesList();

	private void AddCourseButton_Click(object sender, RoutedEventArgs e)
	{
		var newCourse = new Course();
		Courses.Add(newCourse);
		EditCourse(newCourse);
	}

	private void EditSelectedCourseButton_Click(object sender, RoutedEventArgs e)
	{
		if (EnsureCourseSelected(out var selectedCourse))
		{
			EditCourse(selectedCourse);
		}
	}

	private void EditCourse(Course? selectedCourse) => NavigationService!.Navigate(new EditCoursePage(selectedCourse!));

	private void AddTopicButton_Click(object sender, RoutedEventArgs e)
	{
		if (EnsureCourseSelected(out var selectedCourse) == false)
		{
			return;
		}

		var topic = new Topic
		{
			Course = selectedCourse!,
		};

		Topics.Add(topic);
		EditTopic(topic);
	}

	private bool EnsureCourseSelected(out Course? selectedCourse)
	{
		selectedCourse = CoursesDataGrid.SelectedItem as Course;

		if (selectedCourse is null)
		{
			MessageBoxUtils.AtFirstSelect("курс");
		}

		return selectedCourse is not null;
	}

	private void EditSelectedTopicButton_Click(object sender, RoutedEventArgs e)
	{
		if (EnsureTopicSelected(out var selectedTopic))
		{
			EditTopic(selectedTopic!);
		}
	}

	private void RemoveSelectedTopicButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureTopicSelected(out var selectedTopic)
		    && MessageBoxUtils.ConfirmDeletion(of: selectedTopic!))
		{
			Topics.Remove(selectedTopic!);
			Context.SaveChanges();
		}
	}

	private bool EnsureTopicSelected(out Topic? selectedTopic)
	{
		selectedTopic = TopicsOfCourseDataGrid.SelectedItem as Topic;
		if (selectedTopic is null)
		{
			MessageBoxUtils.AtFirstSelect("тему");
		}

		return selectedTopic is not null;
	}

	private void EditTopic(Topic topic) => NavigationService!.Navigate(new TopicEditPage(topic));

	private void CoursesDataGrid_OnLostFocus(object sender, RoutedEventArgs e) => Context.SaveChanges();
}