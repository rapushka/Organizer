using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using OrganizerCore.Model.Views;

namespace OrganizerCore.Model;

public class Schedule : Table
{
	[Key] public int                        Id               { get; set; }
	public       IndividualCoursesOfStudent IndividualCourse { get; set; } = null!;
	public       Group                      Group            { get; set; } = null!;
	public       DateTime                   ScheduledTime    { get; set; }
	public       string                     Note             { get; set; } = null!;
	public       bool                       IsHeld           { get; set; }
	public       bool                       IsGroup          { get; set; }

	public ScheduleView View
		=> IsGroup
			? new ScheduleView(Group, this)
			: new ScheduleView(IndividualCourse, this);

	[NotMapped]
	public object Lessor
	{
		get => IsGroup ? Group : IndividualCourse;
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
		var lessorEntry = IsGroup ? Group.ToString() : IndividualCourse.ToString();
		var scheduledTime = ScheduledTime.ToString(CultureInfo.InvariantCulture);
		var isHeld = IsHeld ? "[ПРОВЕДЕНО] " : string.Empty;

		return $"{isHeld}{lessorEntry} в {scheduledTime}";
	}
}