using System.Collections.Generic;
using System.Linq;
using OrganizerCore.Model;

namespace OrganizerCore.DbWorking;

public static class Dependencies
{
	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private static IEnumerable<Lesson> Lessons => Context.Lessons.AsEnumerable();
	private static IEnumerable<Topic>  Topics  => Context.Topics.AsEnumerable();
	private static IEnumerable<IndividualCoursesOfStudent> IndividualCourses => Context.IndividualCourses.AsEnumerable();
	private static IEnumerable<GroupCoursesOfStudent> GroupCourses => Context.GroupCourses.AsEnumerable();

	public static List<string> For<T>(T table)
		where T : Table
		=> table.Visit
		(
			forTypeOfLesson: (tol) => Lessons.Where((l) => l.Type.Id == tol.Id).Select(Format).ToList(),
			forLesson: (_) => new List<string>(),
			forTopic: (t) => Lessons.Where((l) => l.Topic == t).Select(Format).ToList(),
			forCourse: ForCourse,
			forStudent: ForStudent
		);

	private static List<string> ForStudent(Student s)
	{
		var individualCourses = IndividualCourses.Where((ic) => ic.Student == s).Select(Format).ToList();
		var groupCourses = GroupCourses.Where((ic) => ic.Student == s).Select(Format).ToList();
		return individualCourses;
	}

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

	private static string Format(Student student) => FromTable(student.ToString(), "Студенты");

	private static string Format(IndividualCoursesOfStudent course)
		=> FromTable(course.ToString(), "Индивидуальные курсы студентов");
	
	private static string Format(GroupCoursesOfStudent course)
		=> FromTable(course.ToString(), "Груповые курсы студентов");
}