using System.Windows;
using System.Windows.Controls;
using Organizer.DbWorking;
using OrganizerCore.Windows.Pages;

namespace OrganizerCore
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();

			DataBaseConnection.Instance.OpenDataBase();
		}

		private void ScheduleButton_Click(object sender, RoutedEventArgs e)
		{
			// OpenPage<Schedule>();
		}

		private void StudentsButton_Click(object sender, RoutedEventArgs e)
		{
			// OpenPage<Student>();
		}

		private void GroupsButton_Click(object sender, RoutedEventArgs e)
		{
			// OpenPage<Group>();
		}

		private void CoursesButton_Click(object sender, RoutedEventArgs e) => OpenPage<CoursesListPage>();

		private void OpenPage<TPage>()
			where TPage : Page, new()
			=> MainFrame.Content = new TPage();
	}
}