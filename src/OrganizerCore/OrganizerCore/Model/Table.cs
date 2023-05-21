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
		Func<Student, T> forStudent
	)
		=> this switch
		{
			TypeOfLesson typeOfLesson => forTypeOfLesson(typeOfLesson),
			Lesson lesson => forLesson(lesson),
			Topic topic => forTopic(topic),
			Course course => forCourse(course),
			Student student => forStudent(student),
			_ => throw new InvalidOperationException($"Unknown {nameof(Table)} type. Is {GetType().Name}"),
		};
}