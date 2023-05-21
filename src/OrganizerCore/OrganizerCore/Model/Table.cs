using System;

namespace OrganizerCore.Model;

public class Table
{
	public T Visit<T>
	(
		Func<TypeOfLesson, T> forTypeOfLesson,
		Func<Lesson, T> forLesson,
		Func<Topic, T> forTopic
	)
	{
		if (this is TypeOfLesson typeOfLesson)
		{
			return forTypeOfLesson(typeOfLesson);
		}

		if (this is Lesson lesson)
		{
			return forLesson(lesson);
		}

		if (this is Topic topic)
		{
			return forTopic(topic);
		}

		throw new InvalidOperationException($"Unknown {nameof(Table)} type. Is {GetType().Name}");
	}
}