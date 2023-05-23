using System;

namespace OrganizerCore.Model;

public class Table
{
	public T Visit<T>
	(
		Func<TypeOfLesson, T> forTypeOfLesson,
		Func<Lesson, T> forLesson,
		Func<Topic, T> forTopic,
		Func<Course, T> forCourse,
		Func<Student, T> forStudent,
		Func<IndividualCoursesOfStudent, T> forIndividualCourse,
		Func<GroupCoursesOfStudent, T> forGroupCourse,
		Func<Schedule, T> forSchedule,
		Func<Group, T> forGroup
	)
		=> this switch
		{
			TypeOfLesson typeOfLesson => forTypeOfLesson(typeOfLesson),
			Lesson lesson => forLesson(lesson),
			Topic topic => forTopic(topic),
			Course course => forCourse(course),
			Student student => forStudent(student),
			IndividualCoursesOfStudent individualCourse => forIndividualCourse(individualCourse),
			GroupCoursesOfStudent groupCourse => forGroupCourse(groupCourse),
			Schedule schedule => forSchedule(schedule),
			Group group => forGroup(group),
			_ => throw new InvalidOperationException($"Unknown {nameof(Table)} type. Is {GetType().Name}"),
		};
}