using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Organizer.DbWorking;
using Organizer.Model;

namespace OrganizerCore.Windows.Pages;

public partial class CoursesListPage
{
	public CoursesListPage()
	{
		InitializeComponent();
	}

	private void Page_Loaded(object sender, RoutedEventArgs e)
	{
		var dbContext = DataBaseConnection.Instance.CurrentContext;
		var courses = dbContext.Courses.ToList();

		// Assign data to DataGrid
		CoursesDataGrid.ItemsSource = courses;

		ApplyCustomColumnDefinitions();
	}

	private void ApplyCustomColumnDefinitions()
	{
		CoursesDataGrid.Columns.Clear();

		AddColumn("ID", nameof(Course.Id), Visibility.Collapsed);
		AddColumn("Название", nameof(Course.Title));
		AddColumn("Описание", nameof(Course.Description));
		AddColumn("Продолжительность", nameof(Course.Duration));
		AddColumn("Стоимость", nameof(Course.Price));
		AddColumn("Количество занятий", nameof(Course.LessonsCount));
	}

	private void AddColumn(string header, string binding, Visibility visibility = Visibility.Visible)
	{
		var column = new DataGridTextColumn
		{
			Header = header,
			Binding = new Binding(binding),
			Visibility = visibility,
		};
		CoursesDataGrid.Columns.Add(column);
	}

	private void AddLessonButton_Click(object sender, RoutedEventArgs e)
	{
		// NavigationService.Navigate(new View_Subject());
	}

	private void AddCourseButton_Click(object sender, RoutedEventArgs e)
	{
		// NavigationService.Navigate(new AddCourse());
	}
}