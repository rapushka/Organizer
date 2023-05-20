using System;

namespace OrganizerCore.Model;

public class Table
{
	public T Visit<T>
	(
		Func<TypeOfLesson, T> forTypeOfLesson,
		Func<Lesson, T> forLesson
	)
	{
		if (this is TypeOfLesson exceptionLogEntry)
		{
			return forTypeOfLesson(exceptionLogEntry);
		}

		if (this is Lesson simpleLogEntry)
		{
			return forLesson(simpleLogEntry);
		}

		throw new InvalidOperationException($"Unknown {nameof(Table)} type. Is {GetType().Name}");
	}
}