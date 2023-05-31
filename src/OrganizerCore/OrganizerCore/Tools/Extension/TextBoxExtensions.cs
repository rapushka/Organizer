using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace OrganizerCore.Windows.Pages.Courses_Tab;

public static class TextBoxExtensions
{
	public static bool NumberEqualsTo(this TextBox @this, int number) => number.ToString().Contains(@this.Text);

	public static bool IsNotEmpty(this TextBox @this)    => string.IsNullOrEmpty(@this.Text) == false;
	public static bool IsNotEmpty(this ComboBox @this)   => string.IsNullOrEmpty(@this.Text) == false;
	public static bool IsNotEmpty(this DatePicker @this) => @this.SelectedDate is not null;
	public static bool IsNotEmpty(this DateTimePicker @this) => @this.Value is not null;
}