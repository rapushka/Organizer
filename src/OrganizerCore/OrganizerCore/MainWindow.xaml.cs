using Organizer.DbWorking;

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
	}
}