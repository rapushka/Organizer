using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace OrganizerCore.Tools.Extensions;

public static class DataGridExtensions
{
	public static void AddColumn
		(this DataGrid @this, string header, string binding, Visibility visibility = Visibility.Visible)
	{
		@this.Columns.Add
		(
			new DataGridTextColumn
			{
				Header = header,
				Binding = new Binding(binding),
				Visibility = visibility,
			}
		);
	}
}