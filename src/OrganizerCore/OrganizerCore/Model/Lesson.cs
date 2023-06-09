﻿using System.ComponentModel.DataAnnotations;

namespace OrganizerCore.Model;

public class Lesson : Table
{
	[Key] public int          Id          { get; set; }
	public       TypeOfLesson Type        { get; set; } = null!;
	public       Topic        Topic       { get; set; } = null!;
	public       int          Number      { get; set; }
	public       float        HoursAmount { get; set; }

	public override string ToString() => $"Занятие {Number} по теме {Topic.Title}, курса {Topic.Course.Title}";
}