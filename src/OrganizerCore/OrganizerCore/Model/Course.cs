using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizerCore.Model;

public class Course : Table
{
	[Key] public int     Id          { get; set; }
	public       string  Title       { get; set; } = null!;
	public       string  Description { get; set; } = null!;
	public       float   Duration    { get; set; }
	public       decimal Price       { get; set; }

	public int LessonsCount => throw new NotImplementedException();

	public Course Copy()
		=> new()
		{
			Id = Id,
			Title = Title,
			Description = Description,
			Duration = Duration,
			Price = Price,
		};

	public void Copy(Course other)
	{
		Title = other.Title;
		Description = other.Description;
		Duration = other.Duration;
		Price = other.Price;
	}

	public override string ToString() => Title;
}