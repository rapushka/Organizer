using System;
using System.Globalization;
using System.Windows;
using OrganizerCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Windows.Pages.Courses_Tab;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public partial class EditStudentPage
{
	private readonly Student _student;

	public event Action<Student>? Applied;

	public EditStudentPage(Student student)
	{
		_student = student.Copy();
		InitializeComponent();
	}

	public EditStudentPage()
	{
		_student = new Student();
		InitializeComponent();
	}

	private void Page_OnLoaded(object sender, RoutedEventArgs e) => Load();

	private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (TrySave())
		{
			Applied?.Invoke(_student);
			ExitPage();
		}
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e) => ExitPage();

	private void ExitPage() => NavigationService!.GoBack();

	private void Load()
	{
		FullNameTextBox.Text = _student.FullName;
		PhoneNumberTextBox.Text = _student.PhoneNumber;
		BirthdateTextBox.Text = _student.Birthdate.ToString(CultureInfo.InvariantCulture);
		EmailTextBox.Text = _student.Email;
		ProxyFullNameTextBox.Text = _student.ProxyFullName;
		ProxyPhoneNumberTextBox.Text = _student.ProxyPhoneNumber;
	}

	private bool TrySave()
	{
		var isValid = Validate(out var birthdate);

		if (isValid)
		{
			_student.FullName = FullNameTextBox.Text;
			_student.PhoneNumber = PhoneNumberTextBox.Text;
			_student.Birthdate = birthdate;
			_student.Email = EmailTextBox.Text;
			_student.ProxyFullName = ProxyFullNameTextBox.Text;
			_student.ProxyPhoneNumber = ProxyPhoneNumberTextBox.Text;
		}

		return isValid;
	}

	private bool Validate(out DateTime birthdate)
	{
		var canParseDuration = DateTime.TryParse(BirthdateTextBox.Text, out birthdate);

		if (IsNoEmpty == false)
		{
			MessageBoxUtils.ShowError("Не все поля заполнены!");
			return false;
		}

		if (canParseDuration == false)
		{
			MessageBoxUtils.ShowError("Дата рождения введена некорректно!");
		}

		return canParseDuration;
	}

	private bool IsNoEmpty
		=> FullNameTextBox.IsNotEmpty()
		   && PhoneNumberTextBox.IsNotEmpty()
		   && BirthdateTextBox.IsNotEmpty()
		   && EmailTextBox.IsNotEmpty();
}