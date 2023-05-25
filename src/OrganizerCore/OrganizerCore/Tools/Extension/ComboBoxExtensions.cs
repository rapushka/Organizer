using System.Windows.Controls;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public static class ComboBoxExtensions
{
	public static string GetSelectedText(this ComboBox @this)
		=> (@this.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;
}