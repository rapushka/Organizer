using System;
using System.Globalization;
using System.Windows;
using OrganizerCore.Model;
using OrganizerCore.Tools;

namespace OrganizerCore.Windows.Pages.Courses_Tab;

public partial class EditCoursePage
{
	private readonly Course _selectedCourse;

	public event Action<Course>? Applied;

	public EditCoursePage(Course selectedCourse)
	{
		_selectedCourse = selectedCourse.Copy();
		InitializeComponent();
	}

	public EditCoursePage()
	{
		_selectedCourse = new Course();
		InitializeComponent();
	}

	private void EditCoursePage_OnLoaded(object sender, RoutedEventArgs e) => Load();

	private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (TrySave())
		{
			Applied?.Invoke(_selectedCourse);
			ExitPage();
		}
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e) => ExitPage();

	private void ExitPage() => NavigationService!.GoBack();

	private void Load()
	{
		TitleTextBox.Text = _selectedCourse.Title;
		DescriptionTextBox.Text = _selectedCourse.Description;
		DurationTextBox.Text = _selectedCourse.Duration.ToString(CultureInfo.InvariantCulture);
		LessonsCountTextBox.Text = _selectedCourse.LessonsCount.ToString();
		PriceTextBox.Text = _selectedCourse.Price.ToString(CultureInfo.InvariantCulture);
	}

	private bool TrySave()
	{
		var isValid = Validate(out var duration, out var lessonsCount, out var price);

		if (isValid)
		{
			_selectedCourse.Title = TitleTextBox.Text;
			_selectedCourse.Description = DescriptionTextBox.Text;
			_selectedCourse.Duration = duration;
			_selectedCourse.LessonsCount = lessonsCount;
			_selectedCourse.Price = price;
		}

		return isValid;
	}

	private bool Validate(out float duration, out int lessonsCount, out decimal price)
	{
		var canParseDuration = float.TryParse(DurationTextBox.Text, out duration);
		var canParseLessonsCount = int.TryParse(LessonsCountTextBox.Text, out lessonsCount);
		var canParsePrice = decimal.TryParse(PriceTextBox.Text, out price);
		var canBeParsed = canParseDuration && canParseLessonsCount && canParsePrice;

		if (canBeParsed == false)
		{
			MessageBoxUtils.ShowError
			(
				canParseLessonsCount ? "Количество занятий должно быть целочисленным числом!"
				: canParsePrice      ? "Стоимость должна быть числом"
				: canParseDuration   ? "Продолжительность должна быть числом"
				                       : throw new InvalidOperationException("сообщение не найдено")
			);
		}

		return canBeParsed;
	}
}