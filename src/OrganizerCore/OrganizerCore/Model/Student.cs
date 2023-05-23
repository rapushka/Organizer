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

	public int Age => Birthdate.Age();
	
	public Student Copy()
		=> new()
		{
			Id = Id,
			FullName = FullName,
			PhoneNumber = PhoneNumber,
			Birthdate = Birthdate,
			Email = Email,
			ProxyFullName = ProxyFullName,
			ProxyPhoneNumber = ProxyPhoneNumber,
		};

	public void Copy(Student other)
	{
		FullName = other.FullName;
		PhoneNumber = other.PhoneNumber;
		Birthdate = other.Birthdate;
		Email = other.Email;
		ProxyFullName = other.ProxyFullName;
		ProxyPhoneNumber = other.ProxyPhoneNumber;
	}

	public override string ToString() => $"{FullName} ({Age} лет)";
}