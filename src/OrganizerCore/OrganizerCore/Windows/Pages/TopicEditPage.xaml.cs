using System.Linq;
using System.Windows;
using Organizer.DbWorking;
using Organizer.Model;
using OrganizerCore.Tools.Extensions;

namespace OrganizerCore.Windows.Pages;

public partial class TopicEditPage
{
	private readonly Topic _topic;

	public TopicEditPage(Topic topic)
	{
		_topic = topic;

		InitializeComponent();
	}

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private void Page_OnLoaded(object sender, RoutedEventArgs e)
	{
		CourseTitleTextBox.Text = _topic.Course.Title;
		TitleTextBox.Text = _topic.Title;
		LessonsDataGrid.ItemsSource = Context.Lessons.Where((l) => l.Topic == _topic).ToList();

		SetupLessonsTable();
	}

	private void SetupLessonsTable()
	{
		LessonsDataGrid.Columns.Clear();

		LessonsDataGrid.AddColumn("ID", nameof(Lesson.Id), Visibility.Collapsed);
		LessonsDataGrid.AddColumn("Номер занятия", nameof(Lesson.Number));
		LessonsDataGrid.AddColumn("Вид", $"{nameof(Lesson.Type)}.{nameof(TypeOfLesson.Title)}");
		LessonsDataGrid.AddColumn("Количество часов", nameof(Lesson.HoursAmount));
	}
}