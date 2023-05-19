using System.Linq;
using System.Windows;
using Organizer.DbWorking;
using Organizer.Model;

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
	}
}