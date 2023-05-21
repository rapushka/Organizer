using System.Globalization;
using System.Windows;
using OrganizerCore.Model;
using OrganizerCore.Tools;

namespace OrganizerCore.Windows.Pages.Courses_Tab;

public partial class EditCoursePage
{
	private readonly Course _selectedCourse;

	public EditCoursePage(Course selectedCourse)
	{
		_selectedCourse = selectedCourse;
		InitializeComponent();
	}

	private void EditCoursePage_OnLoaded(object sender, RoutedEventArgs e) => Load();

	private void OkButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (TrySave())
		{
			NavigationService!.GoBack();
		}
	}

	private void Load()
	{
		TitleTextBox.Text = _selectedCourse.Title;
		DescriptionTextBox.Text = _selectedCourse.Description;
		LessonsCountTextBox.Text = _selectedCourse.LessonsCount.ToString();
		PriceTextBox.Text = _selectedCourse.Price.ToString(CultureInfo.InvariantCulture);
	}

	private bool TrySave()
	{
		var isValid = Validate(out var lessonsCount, out var price);

		if (isValid)
		{
			_selectedCourse.Title = TitleTextBox.Text;
			_selectedCourse.Description = DescriptionTextBox.Text;
			_selectedCourse.LessonsCount = lessonsCount;
			_selectedCourse.Price = price;
		}

		return isValid;
	}

	private bool Validate(out int lessonsCount, out decimal price)
	{
		var canParseLessonsCount = int.TryParse(LessonsCountTextBox.Text, out lessonsCount);
		var canParsePrice = decimal.TryParse(PriceTextBox.Text, out price);
		var canBeParsed = canParseLessonsCount && canParsePrice;
		if (canBeParsed == false)
		{
			MessageBoxUtils.ShowError
			(
				canParseLessonsCount
					? "Количество занятий должно быть целочисленным числом!"
					: "Стоимость должна быть числом"
			);
			return false;
		}

		return true;
	}
}