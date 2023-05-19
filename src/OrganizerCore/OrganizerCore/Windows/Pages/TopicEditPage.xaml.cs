using System.Windows.Controls;
using Organizer.Model;

namespace OrganizerCore.Windows.Pages;

public partial class TopicEditPage : Page
{
	private Topic _topic;

	public TopicEditPage(Topic topic)
	{
		_topic = topic;

		InitializeComponent();
	}
}