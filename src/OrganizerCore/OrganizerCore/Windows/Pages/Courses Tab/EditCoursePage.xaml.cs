using OrganizerCore.Model;

namespace OrganizerCore.Windows.Pages.Courses_Tab;

public partial class EditCoursePage
{
	private Course _selectedCourse;

	public EditCoursePage(Course selectedCourse)
	{
		_selectedCourse = selectedCourse;
		InitializeComponent();
	}
}