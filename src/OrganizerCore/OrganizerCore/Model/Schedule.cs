using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using OrganizerCore.Model.Views;

namespace OrganizerCore.Model;

public class Schedule : Table
{
	[Key] public int                         Id               { get; set; }
	public       IndividualCoursesOfStudent? IndividualCourse { get; set; }
	public       Group?                      Group            { get; set; }
	public       DateTime                    ScheduledTime    { get; set; }
	public       string                      Note             { get; set; } = null!;
	public       bool                        IsHeld           { get; set; }

	public ScheduleView View
		=> IndividualCourse is not null ? new ScheduleView(IndividualCourse, this)
			: Group is not null         ? new ScheduleView(Group!, this)
			                              : throw new NullReferenceException();

	[NotMapped]
	public object Lessor
	{
		get => (object?)IndividualCourse
		       ?? Group
		       ?? throw new NullReferenceException("schedule must contain at least one");
		set
		{
			if (value is Group group)
			{
				Group = group;
				return;
			}

			if (value is IndividualCoursesOfStudent individualCourse)
			{
				IndividualCourse = individualCourse;
				return;
			}

			throw new ArgumentException($"SelectedItem is unknown type ({value.GetType().Name})");
		}
	}

	public override string ToString()
	{
		var individualCourseEntry = IndividualCourse?.ToString() ?? string.Empty;
		var groupCourseEntry = Group?.ToString() ?? string.Empty;
		var scheduledTime = ScheduledTime.ToString(CultureInfo.InvariantCulture);
		var isHeld = IsHeld ? "[ПРОВЕДЕНО] " : string.Empty;

		return $"{isHeld}{individualCourseEntry}{groupCourseEntry} в {scheduledTime}";
	}
}