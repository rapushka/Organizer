using System.ComponentModel.DataAnnotations;

namespace OrganizerCore.Model;

public class Course
{
	[Key] public int     Id           { get; set; }
	public       string  Title        { get; set; } = null!;
	public       string  Description  { get; set; } = null!;
	public       float   Duration     { get; set; }
	public       decimal Price        { get; set; }
	public       int     LessonsCount { get; set; }
}