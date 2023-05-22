using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizerCore.Model;

public class GroupCoursesOfStudent : Table
{
	[Key] public int     Id        { get; set; }
	public       Student Student   { get; set; } = null!;
	public       Group   Group     { get; set; } = null!;
	public       string  Indicator { get; set; } = null!;

	public int LessonsCount => throw new NotImplementedException();

	public override string ToString() => $"Курс {Group.Course} студента {Student} из группы {Group}";
}