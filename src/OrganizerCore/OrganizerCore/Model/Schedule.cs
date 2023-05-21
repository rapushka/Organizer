using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizerCore.Model;

public class Schedule : Table
{
	[Key] public int                         Id                         { get; set; }
	public       IndividualCoursesOfStudent? IndividualCoursesOfStudent { get; set; }
	public       GroupCoursesOfStudent?      GroupCoursesOfStudent      { get; set; }
	public       DateTime                    ScheduledTime              { get; set; }
	public       string                      Note                       { get; set; } = null!;
	public       bool                        IsHeld                     { get; set; }
}