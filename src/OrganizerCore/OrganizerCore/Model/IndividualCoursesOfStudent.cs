using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizerCore.Model;

public class IndividualCoursesOfStudent : Table
{
	[Key] public int      Id            { get; set; }
	public       Course   Course        { get; set; } = null!;
	public       Student  Student       { get; set; } = null!;
	public       DateTime BeginningDate { get; set; }
	public       DateTime EndingDate    { get; set; }
	public       string   Indicator     { get; set; } = null!;
	public       int      LessonsCount  { get; set; }

	public override string ToString() => $"Курс {Course} студента {Student}";
}