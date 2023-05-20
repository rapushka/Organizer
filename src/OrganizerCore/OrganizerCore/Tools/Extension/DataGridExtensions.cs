using System;
using System.Windows.Controls;

namespace OrganizerCore.Tools.Extensions;

public static class DataGridExtensions
{
	public static void FocusOn<T>(this DataGrid @this, T item)
	{
		@this.SelectedItem = item;
		@this.ScrollIntoView(item ?? throw new ArgumentNullException(nameof(item)));
		@this.BeginEdit();
	}
}