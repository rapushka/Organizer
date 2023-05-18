using System.ComponentModel.DataAnnotations;

namespace Organizer.Model
{
	public class TypeOfClass
	{
		[Key] public int    Id    { get; set; }
		public       string Title { get; set; } = null!;
	}
}