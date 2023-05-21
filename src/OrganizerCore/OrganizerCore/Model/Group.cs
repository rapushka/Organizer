using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizerCore.Model;

public class Group : Table
{
	[Key] public int      Id                      { get; set; }
	public       Course   Course                  { get; set; } = null!;
	public       string   Title                   { get; set; } = null!;
	public       DateTime BeginningDate           { get; set; }
	public       DateTime EndingDate              { get; set; }
	public       int      MinAge                  { get; set; }
	public       int      MaxAge                  { get; set; }
	public       int      MaxStudentsInGroupCount { get; set; }

	public override string ToString() => Title;
}