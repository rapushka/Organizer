using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public partial class StudentsListPage
{
	public StudentsListPage() => InitializeComponent();

	private void IndividualCoursesButton_Click(object sender, RoutedEventArgs e) { }

	private void GroupCoursesButton_Click(object sender, RoutedEventArgs e) { }

	private void FullnameSearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => SetupStudentsDataGrid();

	private void OnPickedBirthdateChanged(object? sender, SelectionChangedEventArgs e) => SetupStudentsDataGrid();

	private void StudentsListPage_OnLoaded(object sender, RoutedEventArgs e) => SetupStudentsDataGrid();

	private void SetupStudentsDataGrid()
	{
		var studentsViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<Student>(),
		};

		studentsViewSource.Filter += FilterStudentsByFullnameSearch;
		StudentsDataGrid.ItemsSource = studentsViewSource.View;
	}

	private void FilterStudentsByFullnameSearch(object sender, FilterEventArgs e)
		=> e.Accepted = ((Student)e.Item).FullName.Contains(FullnameSearchTextBox.Text);
}