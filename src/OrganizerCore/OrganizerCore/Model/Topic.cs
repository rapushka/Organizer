using System.ComponentModel.DataAnnotations;
using System.Linq;
using OrganizerCore.DbWorking;

namespace OrganizerCore.Model;

public class Topic : Table
{
	[Key] public int    Id     { get; set; }
	public       string Title  { get; set; } = null!;
	public       Course Course { get; set; } = null!;

	public int CountOfLessons => DataBaseConnection.Instance.CurrentContext.Lessons.Count((l) => l.Topic == this);

	public override string ToString() => $"Тема {Title} курса {Course.Title}";
}