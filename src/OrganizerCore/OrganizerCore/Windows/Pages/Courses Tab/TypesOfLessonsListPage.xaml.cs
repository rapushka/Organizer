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
		TypesOfLessonsDataGrid.ItemsSource = DataBaseConnection.Instance.Observe<TypeOfLesson>();

		SetupTypesOfLessonsTable();
	}

	private void OkBase_OnClick(object sender, RoutedEventArgs e) => NavigationService!.GoBack();

	private void SetupTypesOfLessonsTable()
	{
		TypesOfLessonsDataGrid.Columns.Clear();

		TypesOfLessonsDataGrid.AddTextColumn("ID", nameof(TypeOfLesson.Id), Visibility.Collapsed);
		TypesOfLessonsDataGrid.AddTextColumn("Название", nameof(TypeOfLesson.Title));
	}

	private void AddButton_OnClick(object sender, RoutedEventArgs e)
	{
		var newType = new TypeOfLesson();
		TypesOfLessons.Add(newType);

		TypesOfLessonsDataGrid.FocusOn(newType);
	}

	private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (TypesOfLessonsDataGrid.SelectedItem is not TypeOfLesson selectedType)
		{
			MessageBoxUtils.AtFirstSelect("вид");
			return;
		}

		if (MessageBoxUtils.ConfirmDeletion(of: selectedType))
		{
			TypesOfLessons.Remove(selectedType);
			Save();
		}
	}

	private void TypesOfLessonsDataGrid_OnCellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
	{
		var editedCell = (TextBox)e.EditingElement;
		var editedTypeOfLesson = (TypeOfLesson)e.Row.DataContext;
		editedTypeOfLesson.Title = editedCell.Text;
		Save();
	}

	private static void Save() => Context.SaveChanges();
}