using System.ComponentModel.DataAnnotations;
using System.Linq;
using OrganizerCore.DbWorking;

namespace OrganizerCore.Model;

public class Topic : Table
{
	[Key] public int    Id     { get; set; }
	public       string Title  { get; set; } = null!;
	public       Course Course { get; set; } = null!;

	public float CountOfLessons => DataBaseConnection.Instance.CurrentContext.Lessons
	                                                 .Where((l) => l.Topic == this)
	                                                 .Sum((l) => l.HoursAmount);

	public override string ToString() => $"Тема {Title} курса {Course.Title}";
}