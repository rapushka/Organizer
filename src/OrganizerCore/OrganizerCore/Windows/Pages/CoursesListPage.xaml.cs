using System.Windows;
using System.Windows.Controls;

namespace OrganizerCore.Windows.Pages;

public partial class CoursesListPage : Page
{
	public CoursesListPage()
	{
		InitializeComponent();
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