using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Organizer.DbWorking;
using Organizer.Model;
using OrganizerCore.Tools.Extensions;
using static System.Windows.MessageBoxButton;
using static System.Windows.MessageBoxImage;

namespace OrganizerCore.Windows.Pages;

public partial class TypesOfLessonsListPage
{
	public TypesOfLessonsListPage() => InitializeComponent();

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private void TypesOfLessonsListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		TypesOfLessonsDataGrid.ItemsSource = DataBaseConnection.Instance.Observable<TypeOfLesson>();

		SetupTypesOfLessonsTable();
	}

	private void OkBase_OnClick(object sender, RoutedEventArgs e) => NavigationService!.GoBack();

	private void SetupTypesOfLessonsTable()
	{
		TypesOfLessonsDataGrid.Columns.Clear();

		TypesOfLessonsDataGrid.AddColumn("ID", nameof(TypeOfLesson.Id), Visibility.Collapsed);
		TypesOfLessonsDataGrid.AddColumn("Название", nameof(TypeOfLesson.Title));
	}

	private void AddButton_OnClick(object sender, RoutedEventArgs e)
	{
		var newType = new TypeOfLesson();

		if (TypesOfLessonsDataGrid.ItemsSource is ObservableCollection<TypeOfLesson> typesOfLessons)
		{
			typesOfLessons.Add(newType);

			TypesOfLessonsDataGrid.SelectedItem = newType;
			TypesOfLessonsDataGrid.ScrollIntoView(newType);
			TypesOfLessonsDataGrid.BeginEdit();
		}
	}

	private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (TypesOfLessonsDataGrid.SelectedItem is TypeOfLesson selectedType)
		{
			var dependentEntries = CheckForDependentEntries(selectedType);

			if (dependentEntries.Any())
			{
				var entries = string.Join(",\n", dependentEntries);

				MessageBox.Show($"В бд остались связаные записи!\n\n{entries}", "Отмена удаления");
			}
			else
			{
				var typesOfLessons = (ObservableCollection<TypeOfLesson>)TypesOfLessonsDataGrid.ItemsSource;
				typesOfLessons.Remove(selectedType);
			}
		}
	}

	private static List<string> CheckForDependentEntries(TypeOfLesson type)
		=> Context.Lessons.Where((l) => l.Type.Id == type.Id).Select((l) => $"{l} из таблицы Занятия").ToList();

	private void TypesOfLessonsDataGrid_OnCellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
	{
		if (e.EditingElement is not TextBox editedCell
		    || e.Row.DataContext is not TypeOfLesson editedTypeOfLesson)
		{
			return;
		}

		var editedValue = editedCell.Text;
		editedTypeOfLesson.Title = editedValue;

		Context.SaveChanges();
		MessageBox.Show(string.Join(", ", Context.TypesOfLessons.Select((tol) => tol.Title)));
	}
}