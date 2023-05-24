using System;
using System.Windows;
using System.Windows.Controls;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;

namespace OrganizerCore.Windows.Pages.ScheduleTab;

public partial class EditSchedulePage
{
	private Schedule _schedule;

	public EditSchedulePage(Schedule schedule)
	{
		_schedule = schedule;
		InitializeComponent();
	}

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private void RadioButton_Click(object sender, RoutedEventArgs e) { }

	private void CourseComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) { }

#region Save/Cancel

	private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
	{
		try
		{
			Context.SaveChanges();
			NavigationService!.GoBack();
		}
		catch (Exception ex)
		{
			MessageBoxUtils.ShowError(ex.Message);
			throw;
		}
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DataBaseConnection.Instance.ResetAll();
		NavigationService!.GoBack();
	}

#endregion
}