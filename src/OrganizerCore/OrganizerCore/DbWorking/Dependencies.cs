using System.Collections.Generic;
using System.Linq;
using OrganizerCore.Model;

namespace OrganizerCore.DbWorking;

public static class Dependencies
{
	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private static IEnumerable<Lesson> Lessons => Context.Lessons.AsEnumerable();
	private static IEnumerable<Topic>  Topics  => Context.Topics.AsEnumerable();

	public static List<string> For<T>(T table)
		where T : Table
		=> table.Visit
		(
			forTypeOfLesson: (tol) => Lessons.Where((l) => l.Type.Id == tol.Id).Select(Format).ToList(),
			forLesson: (_) => new List<string>(),
			forTopic: (t) => Lessons.Where((l) => l.Topic == t).Select(Format).ToList(),
			forCourse: ForCourse
		);

	private static List<string> ForCourse(Course c)
	{
		var topics = Topics.Where((t) => t.Course == c).ToList();
		var topicsNames = topics.Select(Format);
		var dependentLessons = topics.SelectMany(For);
		return topicsNames.Concat(dependentLessons).ToList();
	}

	private static string FromTable(string item, string tableName) => $"{item} из таблицы {tableName}";

	private static string Format(Lesson lesson) => FromTable(lesson.ToString(), "Занятия");

	private static string Format(Topic topic) => FromTable(topic.ToString(), "Темы");
}