using System;

namespace OrganizerCore.Model;

public static class DateTimeExtensions
{
	public static int Age(this DateTime @this) => DateTime.Today.DeltaYears(@this);

	public static int DeltaYears(this DateTime @this, DateTime other) => @this.Subtract(other).Days / 365;
}