using System.Windows;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;

namespace OrganizerCore.Windows.Pages.GroupsTab;

public partial class EditGroupPage
{
	private readonly Group _group;

	public EditGroupPage(Group group)
	{
		_group = group;

		InitializeComponent();
	}

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
	{
		Context.SaveChanges();
		NavigationService!.GoBack();
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DataBaseConnection.Instance.ResetAll();
		NavigationService!.GoBack();
	}
}