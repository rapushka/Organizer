using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace OrganizerCore.DbWorking;

public static class DbSetExtensions
{
	public static ObservableCollection<T> Observe<T>(this DbSet<T> @this)
		where T : class
		=> @this.Local.ToObservableCollection();
}