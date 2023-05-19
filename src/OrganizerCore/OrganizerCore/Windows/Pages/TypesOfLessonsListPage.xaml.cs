using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Organizer.DbWorking;
using Organizer.Model;
using OrganizerCore.Tools.Extensions;

namespace OrganizerCore.Windows.Pages;

public partial class TypesOfLessonsListPage
{
	public TypesOfLessonsListPage() => InitializeComponent();

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private void TypesOfLessonsListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		TypesOfLessonsDataGrid.ItemsSource = Context.TypesOfLessons.ToList();

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
		TypesOfLessonsDataGrid.Items.Add(newType);

		TypesOfLessonsDataGrid.SelectedItem = newType;
		TypesOfLessonsDataGrid.ScrollIntoView(newType);
		TypesOfLessonsDataGrid.BeginEdit();
	}

	private void EditButton_OnClick(object sender, RoutedEventArgs e) { }

	private void RemoveButton_OnClick(object sender, RoutedEventArgs e) { }

	private void TypesOfLessonsDataGrid_OnCellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
	{
		if (e.EditingElement is not TextBox editedCell
		    || e.Row.DataContext is not TypeOfLesson editedTypeOfLesson)
		{
			return;
		}

		var editedValue = editedCell.Text;
		editedTypeOfLesson.Title = editedValue;

		Context.Entry(editedTypeOfLesson).State = EntityState.Modified;
		Context.SaveChanges();
		MessageBox.Show(string.Join(", ", Context.TypesOfLessons.Select((tol) => tol.Title)));
	}
}