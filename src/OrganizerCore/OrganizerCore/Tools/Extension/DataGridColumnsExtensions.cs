using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace OrganizerCore.Tools.Extensions;

public static class DataGridColumnsExtensions
{
	private const string Empty = "";

	public static void AddTextColumn
	(
		this DataGrid @this,
		string header,
		string binding,
		Visibility visibility = Visibility.Visible,
		bool isReadonly = false
	)
		=> @this.Columns.Add
		(
			new DataGridTextColumn
			{
				Header = header,
				Binding = new Binding(binding),
				Visibility = visibility,
				IsReadOnly = isReadonly,
			}
		);

	public static void AddComboBoxColumn<TProperty>
	(
		this DataGrid @this,
		string header,
		string binding,
		IEnumerable<TProperty> itemsSource,
		string displayMemberPath = Empty,
		string selectedValuePath = Empty,
		Visibility visibility = Visibility.Visible
	)
		=> @this.Columns.Add
		(
			new DataGridComboBoxColumn
			{
				Header = header,
				SelectedItemBinding = new Binding(binding),
				ItemsSource = itemsSource,
				DisplayMemberPath = displayMemberPath,
				SelectedValuePath = selectedValuePath,
				Visibility = visibility,
			}
		);
}