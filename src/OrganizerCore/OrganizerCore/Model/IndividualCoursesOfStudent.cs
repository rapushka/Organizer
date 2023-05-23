using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using OrganizerCore.DbWorking;

namespace OrganizerCore.Model;

public class IndividualCoursesOfStudent : Table
{
	[Key] public int      Id            { get; set; }
	public       Course   Course        { get; set; } = null!;
	public       Student  Student       { get; set; } = null!;
	public       DateTime BeginningDate { get; set; }
	public       DateTime EndingDate    { get; set; }
	public       string   Indicator     { get; set; } = null!;

	public float LessonsCount => Course.LessonsCount - CountOfHeldLessons;

	private int CountOfHeldLessons
		=> DataBaseConnection.Instance.CurrentContext.Schedules
		                     .Count((s) => s.IndividualCourse == this && s.IsHeld);

	public override string ToString() => $"Курс {Course} студента {Student}";
}