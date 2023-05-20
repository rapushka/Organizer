using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools.Extensions;

namespace OrganizerCore.Windows.Pages;

public partial class TopicEditPage
{
	private readonly Topic _topic;

	public TopicEditPage(Topic topic)
	{
		_topic = topic;

		InitializeComponent();
	}

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private static IEnumerable<TypeOfLesson> TypesOfLessons => DataBaseConnection.Instance.Observe<TypeOfLesson>();

	private static ObservableCollection<Lesson> Lessons => DataBaseConnection.Instance.Observe<Lesson>();

	private void Page_OnLoaded(object sender, RoutedEventArgs e)
	{
		CourseTitleTextBox.Text = _topic.Course.Title;
		TitleTextBox.Text = _topic.Title;

		ShowLessonsOnlyForCurrentTopic();
		SetupLessonsColumns();
	}

	private void EditLessonsTypesListButton_OnClick(object sender, RoutedEventArgs e)
		=> NavigationService!.Navigate(new TypesOfLessonsListPage());

	private void OkButton_OnClick(object sender, RoutedEventArgs e) => NavigationService!.GoBack();

	private void AddLessonButton_OnClick(object sender, RoutedEventArgs e)
	{
		var newLesson = new Lesson
		{
			Type = TypesOfLessons.First(),
			Topic = _topic,
		};
		Lessons.Add(newLesson);

		LessonsDataGrid.FocusOn(newLesson);
	}

	private void TitleTextBox_OnLostFocus(object sender, RoutedEventArgs e)
	{
		_topic.Title = TitleTextBox.Text;
		Context.SaveChanges();
	}

	private void ShowLessonsOnlyForCurrentTopic()
	{
		var lessonsViewSource = new CollectionViewSource
		{
			Source = Lessons,
		};
		lessonsViewSource.Filter += LessonsViewSource_Filter;
		LessonsDataGrid.ItemsSource = lessonsViewSource.View;
	}

	private void LessonsViewSource_Filter(object sender, FilterEventArgs e)
		=> e.Accepted = (e.Item as Lesson)?.Topic == _topic;

	private void SetupLessonsColumns()
	{
		LessonsDataGrid.Columns.Clear();

		LessonsDataGrid.AddTextColumn("ID", nameof(Lesson.Id), Visibility.Collapsed);
		LessonsDataGrid.AddTextColumn("Номер занятия", nameof(Lesson.Number));
		LessonsDataGrid.AddComboBoxColumn
		(
			header: "Вид",
			binding: nameof(Lesson.Type),
			itemsSource: TypesOfLessons,
			displayMemberPath: nameof(TypeOfLesson.Title),
			selectedValuePath: nameof(TypeOfLesson.Id)
		);

		LessonsDataGrid.AddTextColumn("Количество часов", nameof(Lesson.HoursAmount));
	}
}