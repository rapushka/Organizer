using System.ComponentModel.DataAnnotations;

namespace OrganizerCore.Model
{
	public class TypeOfLesson
	{
		[Key] public int    Id    { get; set; }
		public       string Title { get; set; } = null!;
	}
}