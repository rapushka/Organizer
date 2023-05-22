using System.Windows;
using System.Windows.Controls;
using OrganizerCore.Model;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public partial class EnrollStudentOnCoursePage : Page
{
	public EnrollStudentOnCoursePage(Student selectedStudent)
	{
		InitializeComponent();
	}

	private void ButtonBase_OnClick(object sender, RoutedEventArgs e) => NavigationService!.GoBack();
}