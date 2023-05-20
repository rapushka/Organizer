using System.Collections.Generic;
using System.Linq;
using OrganizerCore.Model;

namespace OrganizerCore.DbWorking;

public static class Dependencies
{
	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private static IEnumerable<Lesson> Lessons => Context.Lessons.AsEnumerable();

	public static List<string> For<T>(T table)
		where T : Table
		=> table.Visit
		(
			forTypeOfLesson: (t) => Lessons.Where((l) => l.Type.Id == t.Id).Select(Format).ToList(),
			forLesson: (_) => new List<string>()
		);

	private static string FromTable(string item, string tableName) => $"{item} из таблицы {tableName}";

	private static string Format(Lesson lesson) => FromTable(lesson.ToString(), "Занятия");
}