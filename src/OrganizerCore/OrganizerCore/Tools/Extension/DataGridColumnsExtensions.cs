using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace OrganizerCore.Tools.Extensions;

public static class DataGridColumnsExtensions
{
	public static void AddTextColumn
	(
		this DataGrid @this,
		string header,
		string binding,
		Visibility visibility = Visibility.Visible
	)
		=> @this.Columns.Add
		(
			new DataGridTextColumn
			{
				Header = header,
				Binding = new Binding(binding),
				Visibility = visibility,
			}
		);

	public static void AddComboBoxColumn<TProperty>
	(
		this DataGrid @this,
		string header,
		string binding,
		IEnumerable<TProperty> itemsSource,
		string displayMemberPath,
		string selectedValuePath,
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

	public static void AddComboBoxEnumColumn
	(
		this DataGrid @this,
		string header,
		string binding,
		string[] itemsSource,
		Visibility visibility = Visibility.Visible
	)
	{
		var comboBoxColumn = new DataGridTemplateColumn
		{
			Header = header,
			Visibility = visibility,
		};

		var dataTemplate = new DataTemplate(typeof(ComboBox));
		var comboBoxFactory = new FrameworkElementFactory(typeof(ComboBox));
		comboBoxFactory.SetValue(ItemsControl.ItemsSourceProperty, itemsSource);

		comboBoxFactory.SetValue(Selector.SelectedItemProperty, new Binding(binding));
		comboBoxFactory.SetValue(ItemsControl.DisplayMemberPathProperty, "");

		dataTemplate.VisualTree = comboBoxFactory;

		comboBoxColumn.CellEditingTemplate = dataTemplate;
		comboBoxColumn.CellTemplate = dataTemplate;

		@this.Columns.Add(comboBoxColumn);
	}
}