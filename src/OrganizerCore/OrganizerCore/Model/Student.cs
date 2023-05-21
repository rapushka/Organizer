using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizerCore.Model;

public class Student : Table
{
	[Key] public int      Id               { get; set; }
	public       string   FullName         { get; set; } = null!;
	public       string   PhoneNumber      { get; set; } = null!;
	public       DateTime Birthdate        { get; set; }
	public       string   Email            { get; set; } = null!;
	public       string   ProxyFullName    { get; set; } = null!;
	public       string   ProxyPhoneNumber { get; set; } = null!;
}