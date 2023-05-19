using System.ComponentModel.DataAnnotations;
using System.Linq;
using Organizer.DbWorking;

namespace Organizer.Model;

public class Topic
{
	[Key] public int    Id     { get; set; }
	public       string Title  { get; set; } = null!;
	public       Course Course { get; set; } = null!;

	public int CountOfLessons => DataBaseConnection.Instance.CurrentContext.Lessons.Count((l) => l.Topic == this);
}