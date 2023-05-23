using System;

namespace OrganizerCore.Windows.Pages.ScheduleTab;

public static class DateTimeExtensions
{
	public static bool IsBetween(this DateTime @this, DateTime? min, DateTime? max)
		=> @this >= (min ?? DateTime.Now) && @this <= (max ?? DateTime.Now);

	public static bool IsToday(this DateTime @this) => @this.Date == DateTime.Today;
}