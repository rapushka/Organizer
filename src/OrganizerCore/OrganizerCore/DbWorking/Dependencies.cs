using System.Collections.Generic;
using System.Linq;
using OrganizerCore.Model;

namespace OrganizerCore.DbWorking;

public static class Dependencies
{
	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	private static IEnumerable<Lesson> Lessons => Context.Lessons.AsEnumerable();
	private static IEnumerable<Topic>  Topics  => Context.Topics.AsEnumerable();
	private static IEnumerable<IndividualCoursesOfStudent> IndividualCourses
		=> Context.IndividualCourses.AsEnumerable();
	private static IEnumerable<GroupCoursesOfStudent> GroupCourses => Context.GroupCourses.AsEnumerable();

	private static IEnumerable<Schedule> Schedules => Context.Schedules.AsEnumerable();

	public static List<string> For<T>(T table)
		where T : Table
		=> table.Visit
		(
			forTypeOfLesson: (tol) => Lessons.Where((l) => l.Type.Id == tol.Id).Select(Format).ToList(),
			forLesson: Nothing,
			forTopic: (t) => Lessons.Where((l) => l.Topic == t).Select(Format).ToList(),
			forCourse: ForCourse,
			forStudent: ForStudent,
			forIndividualCourse: (ic) => Schedules.Where((s) => s.IndividualCourse == ic).Select(Format).ToList(),
			forGroupCourse: Nothing,
			forSchedule: Nothing,
			forGroup: ForGroups
		);

	private static List<string> ForCourse(Course course)
	{
		var topics = Topics.Where((t) => t.Course == course).ToList();
		var topicsNames = topics.Select(Format);
		var dependentLessons = topics.SelectMany(For);

		return topicsNames.Concat(dependentLessons).ToList();
	}

	private static List<string> ForStudent(Student student)
	{
		var ourIndividualCourses = IndividualCourses.Where((ic) => ic.Student == student).ToList();
		var individualCourses = ourIndividualCourses.Select(Format).ToList();
		var groupCourses = GroupCourses.Where((ic) => ic.Student == student).Select(Format).ToList();
		var schedules = ourIndividualCourses.SelectMany(For);

		return individualCourses.Concat(groupCourses).Concat(schedules).ToList();
	}

	private static List<string> ForGroups(Group group)
	{
		var groupCourses = GroupCourses.Where((gc) => gc.Group == group).Select(Format).ToList();
		var schedules = Schedules.Where((s) => s.Group == group).Select(Format).ToList();

		return groupCourses.Concat(schedules).ToList();
	}

	private static List<string> Nothing(Table _) => new();

	private static string FromTable(string item, string tableName) => $"{item} из таблицы {tableName}";

	private static string Format(Lesson lesson) => FromTable(lesson.ToString(), "Занятия");

	private static string Format(Topic topic) => FromTable(topic.ToString(), "Темы");

	private static string Format(IndividualCoursesOfStudent course)
		=> FromTable(course.ToString(), "Индивидуальные курсы студентов");

	private static string Format(GroupCoursesOfStudent course)
		=> FromTable(course.ToString(), "Груповые курсы студентов");

	private static string Format(Schedule schedule) => FromTable(schedule.ToString(), "Расписания");
}