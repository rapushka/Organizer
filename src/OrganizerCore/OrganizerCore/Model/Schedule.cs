using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace OrganizerCore.Model;

public class Schedule : Table
{
	[Key] public int                         Id               { get; set; }
	public       IndividualCoursesOfStudent? IndividualCourse { get; set; }
	public       GroupCoursesOfStudent?      GroupCourse      { get; set; }
	public       DateTime                    ScheduledTime    { get; set; }
	public       string                      Note             { get; set; } = null!;
	public       bool                        IsHeld           { get; set; }

	public override string ToString()
	{
		var individualCourseEntry = IndividualCourse?.ToString() ?? string.Empty;
		var groupCourseEntry = GroupCourse?.ToString() ?? string.Empty;
		var scheduledTime = ScheduledTime.ToString(CultureInfo.InvariantCulture);
		var isHeld = IsHeld ? "[ПРОВЕДЕНО] " : string.Empty;

		return $"{isHeld}{individualCourseEntry}{groupCourseEntry} в {scheduledTime}";
	}
}