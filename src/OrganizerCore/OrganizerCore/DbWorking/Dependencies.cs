using System.Collections.Generic;
using System.Linq;
using OrganizerCore.Model;

namespace OrganizerCore.DbWorking;

public static class Dependencies
{
	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	public static List<string> For(TypeOfLesson type)
		=> Context.Lessons
		          .Where((l) => l.Type.Id == type.Id)
		          .Select((l) => FromTable(l.ToString(), "Занятия"))
		          .ToList();

	private static string FromTable(string item, string tableName) => $"{item} из таблицы {tableName}";
}