using System.Windows;
using Organizer.DbWorking;

namespace OrganizerCore
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataBaseConnection.Instance.OpenDataBase();
		}

		private void ScheduleButton_Click(object sender, RoutedEventArgs e)
		{
			// MainFrame.Content = new Schedule();
		}

		private void StudentsButton_Click(object sender, RoutedEventArgs e)
		{
			// MainFrame.Content = new Student();
		}

		private void GroupsButton_Click(object sender, RoutedEventArgs e)
		{
			// MainFrame.Content = new Group();
		}

		private void CoursesButton_Click(object sender, RoutedEventArgs e)
		{
			// MainFrame.Content = new Course();
		}
	}
}