using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizerCore.Model;

public class Student : Table
{
	[Key] public int      Id               { get; set; }
	public       string   FullName         { get; set; } = null!;
	public       int      PhoneNumber      { get; set; }
	public       DateTime Birthdate        { get; set; }
	public       string   Email            { get; set; } = null!;
	public       string   ProxyFullName    { get; set; } = null!;
	public       int      ProxyPhoneNumber { get; set; }
}