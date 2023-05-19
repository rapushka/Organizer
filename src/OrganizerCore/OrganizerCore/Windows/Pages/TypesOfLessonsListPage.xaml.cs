using System.Linq;
using System.Windows;
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

		SetupTypesOfLessons();
	}

	private void OkBase_OnClick(object sender, RoutedEventArgs e) => NavigationService!.GoBack();

	private void SetupTypesOfLessons()
	{
		TypesOfLessonsDataGrid.Columns.Clear();

		TypesOfLessonsDataGrid.AddColumn("ID", nameof(TypeOfLesson.Id), Visibility.Collapsed);
		TypesOfLessonsDataGrid.AddColumn("Название", nameof(TypeOfLesson.Title));
	}
}