using System.ComponentModel.DataAnnotations;

namespace Organizer.Model;

public class Topic
{
	[Key] public int    Id     { get; set; }
	public       string Title  { get; set; } = null!;
	public       Course Course { get; set; } = null!;
}