using System.Windows;

namespace OrganizerCore.Windows.Pages.ScheduleTab;

public partial class FullSchedulePage
{
	private bool _showHeld;
	private bool _showNotHeld;

	public FullSchedulePage() => InitializeComponent();

	private void FullSchedulePage_OnLoaded(object sender, RoutedEventArgs e) => SetupTable();

#region Table

	private void SetupTable()
	{
		
	}
	
#endregion

	private void UploadButton_OnClick(object sender, RoutedEventArgs e) { }

	private void HeldButton_OnClick(object sender, RoutedEventArgs e) { }

	private void ScheduleLessonButton_OnClick(object sender, RoutedEventArgs e) { }

	private void RadioButton_Checked(object sender, RoutedEventArgs e)
	{
		var all = ShowAllRadioButton.IsChecked!.Value;
		var onlyHeld = OnlyHeldRadioButton.IsChecked!.Value;
		var onlyNotHeld = OnlyNotHeldRadioButton.IsChecked!.Value;

		_showHeld = all || onlyHeld;
		_showNotHeld = all || onlyNotHeld;
	}
}