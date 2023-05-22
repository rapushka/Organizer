using System.Windows.Controls;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public static class ComboBoxExtensions
{
	public static string GetSelectedText(this ComboBox @this) => ((ComboBoxItem)@this.SelectedItem).Content.ToString()!;
}