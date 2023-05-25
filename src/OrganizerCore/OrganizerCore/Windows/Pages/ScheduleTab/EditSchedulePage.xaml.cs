﻿using System;
using System.Windows;
using System.Windows.Controls;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using OrganizerCore.Tools;

namespace OrganizerCore.Windows.Pages.ScheduleTab;

public partial class EditSchedulePage
{
	private readonly Schedule _schedule;

	public EditSchedulePage(Schedule schedule)
	{
		_schedule = schedule;
		InitializeComponent();
	}

	private void Page_Load(object sender, RoutedEventArgs e) => Load();

	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private CourseTypeShow CourseTypeShow
	{
		set
		{
			if (value is CourseTypeShow.All)
			{
				ShowAllRadioButton.IsChecked = true;
			}
			else if (value is CourseTypeShow.Individual)
			{
				OnlyIndividualRadioButton.IsChecked = true;
			}
			else if (value is CourseTypeShow.Group)
			{
				OnlyGroupRadioButton.IsChecked = true;
			}
		}
	}

	private void RadioButton_Click(object sender, RoutedEventArgs e) { }

	private void CourseComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) { }

#region Save-Load

	private void Load()
	{
		CourseTypeShow = CourseTypeShow.All;
		CourseComboBox.SelectedItem = _schedule.View.Course;
		LessonComboBox.SelectedItem = _schedule.View.Lesson;
		DateTimePicker.Value = _schedule.ScheduledTime;
		NoteTextBox.Text = _schedule.Note;
	}

	private void Save()
	{
		_schedule.View.Course = (Course)CourseComboBox.SelectedItem;
		SetLesson();
		_schedule.ScheduledTime = DateTimePicker.Value ?? DateTime.MinValue;
		_schedule.Note = NoteTextBox.Text;
	}

	private void SetLesson()
	{
		if (LessonComboBox.SelectedItem is Group group)
		{
			_schedule.Group = group;
		}
		else if (LessonComboBox.SelectedItem is IndividualCoursesOfStudent individualCourse)
		{
			_schedule.IndividualCourse = individualCourse;
		}
		else
		{
			throw new Exception($"SelectedItem is unknown type ({LessonComboBox.SelectedItem.GetType().Name})");
		}
	}

#endregion

#region Apply/Cancel

	private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
	{
		try
		{
			Save();
			Context.SaveChanges();
			NavigationService!.GoBack();
		}
		catch (NullReferenceException)
		{
			MessageBoxUtils.ShowError("Не все поля установлены");
		}
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DataBaseConnection.Instance.ResetAll();
		NavigationService!.GoBack();
	}

#endregion

	private void DateTimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e) { }
}

public enum CourseTypeShow
{
	All,
	Individual,
	Group,
}