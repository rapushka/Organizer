using System.ComponentModel.DataAnnotations;
using System.Linq;
using OrganizerCore.DbWorking;

namespace OrganizerCore.Model;

public class GroupCoursesOfStudent : Table
{
	[Key] public int     Id        { get; set; }
	public       Student Student   { get; set; } = null!;
	public       Group   Group     { get; set; } = null!;
	public       string  Indicator { get; set; } = null!;

	public int LessonsCount => Group.Course.LessonsCount - CountOfHeldLessons;

	private int CountOfHeldLessons
		=> DataBaseConnection.Instance.CurrentContext.Schedules
		                     .Count((s) => s.GroupCourse == this && s.IsHeld);

	public override string ToString() => $"Курс {Group.Course} студента {Student} из группы {Group}";
}