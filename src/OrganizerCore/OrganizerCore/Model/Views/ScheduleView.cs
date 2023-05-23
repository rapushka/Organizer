using System;

namespace OrganizerCore.Model.Views;

// | Дата-Время | Курс | Занятие | Примечание | Проведено |
public class ScheduleView
{
	private readonly bool _isGroup;
	private readonly Group? _group;
	private readonly IndividualCoursesOfStudent? _individualCourse;
	private readonly Schedule _schedule;

	public ScheduleView(IndividualCoursesOfStudent individualCourse, Schedule schedule)
	{
		_isGroup = false;
		_individualCourse = individualCourse;
		_schedule = schedule;
	}

	public ScheduleView(Group group, Schedule schedule)
	{
		_isGroup = true;
		_group = group;
		_schedule = schedule;
	}

	public DateTime ScheduledTime => _schedule.ScheduledTime;
	public string   CourseTitle   => Course.Title;
	public string   LessonType    => _isGroup ? _group!.Title : _individualCourse!.Student.FullName;
	public string   Note          => _schedule.Note;
	public bool     IsHeld        => _schedule.IsHeld;

	private Course Course => _isGroup ? _group!.Course : _individualCourse!.Course;
}