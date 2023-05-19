using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;

namespace OrganizerCore.Windows.Pages;

public partial class TypesOfLessonsListPage
{
	public TypesOfLessonsListPage() => InitializeComponent();

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private ObservableCollection<TypeOfLesson> TypesOfLessons
		=> (ObservableCollection<TypeOfLesson>)TypesOfLessonsDataGrid.ItemsSource;

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
		if (TypesOfLessonsDataGrid.SelectedItem is TypeOfLesson selectedType
		    && MessageBoxUtils.ConfirmDeletion(of: selectedType))
		{
			TypesOfLessons.Remove(selectedType);
			Save();
		}
	}

	private void TypesOfLessonsDataGrid_OnCellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
	{
		if (e.EditingElement is TextBox editedCell
		    && e.Row.DataContext is TypeOfLesson editedTypeOfLesson)
		{
			editedTypeOfLesson.Title = editedCell.Text;
			Save();
		}
	}

	private static void Save() => Context.SaveChanges();
}