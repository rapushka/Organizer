using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;

namespace OrganizerCore.Windows.Pages.GroupsTab;

public partial class GroupsListPage
{
	public GroupsListPage() => InitializeComponent();

	private static IEnumerable<Course> Courses => DataBaseConnection.Instance.Observe<Course>();

	private void GroupsListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		UpdateViewTable();
	}

	private void UpdateViewTable()
	{
		SetupStudentsDataGrid();
		SetupStudentsColumns();
	}

#region Groups Table setup

	private void SetupStudentsDataGrid()
	{
		var studentsViewSource = new CollectionViewSource
		{
			Source = DataBaseConnection.Instance.Observe<Group>(),
		};

		studentsViewSource.Filter += FilterGroups;
		GroupsDataGrid.ItemsSource = studentsViewSource.View;
	}

	private void SetupStudentsColumns()
	{
		GroupsDataGrid.Columns.Clear();

		GroupsDataGrid.AddTextColumn("ID", nameof(Group.Id), Visibility.Collapsed);
		GroupsDataGrid.AddTextColumn("Название", nameof(Group.Title));
		GroupsDataGrid.AddComboBoxColumn
		(
			header: "Курс",
			binding: nameof(Group.Course),
			itemsSource: Courses,
			displayMemberPath: nameof(Course.Title),
			selectedValuePath: nameof(Course.Id)
		);
		GroupsDataGrid.AddTextColumn("Дата начала", nameof(Group.BeginningDate));
		GroupsDataGrid.AddTextColumn("Дата окончания", nameof(Group.EndingDate));
		GroupsDataGrid.AddTextColumn("Минимальный возраст", nameof(Group.MinAge));
		GroupsDataGrid.AddTextColumn("Максимальный возраст", nameof(Group.MaxAge));
		GroupsDataGrid.AddTextColumn("Количество мест", nameof(Group.MaxStudentsInGroupCount));
	}

	private void FilterGroups(object sender, FilterEventArgs e)
	{
		var group = (Group)e.Item;

		var fitsByTitle = group.Title.Contains(GroupTitleTextBox.Text);
		var fitsByCourse = group.Course.Title.Contains(CourseTitleTextBox.Text);

		e.Accepted = fitsByTitle && fitsByCourse;
	}

#endregion

	private void Search_OnTextChanged(object sender, TextChangedEventArgs e) => UpdateViewTable();

#region Group CRUD

	private void AddButton_OnClick(object sender, RoutedEventArgs e)
	{
		var group = new Group
		{
			Title = string.Empty,
			Course = Courses.First(),
		};
		DataBaseConnection.Instance.CurrentContext.Groups.Add(group);
		NavigationService!.Navigate(new EditGroupPage(group));
	}

	private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureSelectedGroup(out var group)
		    && MessageBoxUtils.ConfirmDeletion(group!))
		{
			DataBaseConnection.Instance.Observe<Group>().Remove(group!);
		}
	}

	private void EditButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureSelectedGroup(out var group))
		{
			NavigationService!.Navigate(new EditGroupPage(group!));
		}
	}

	private bool EnsureSelectedGroup(out Group? group)
	{
		group = GroupsDataGrid.SelectedItem as Group;
		if (group is null)
		{
			MessageBoxUtils.AtFirstSelect("группу");
		}

		return group is not null;
	}

#endregion
}