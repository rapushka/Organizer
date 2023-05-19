using Microsoft.EntityFrameworkCore;
using Organizer.Model;

namespace Organizer.DbWorking
{
	public class ApplicationContext : DbContext
	{
		public DbSet<TypeOfLesson> TypesOfLessons { get; set; } = null!;
		public DbSet<Course>       Courses        { get; set; } = null!;
		public DbSet<Topic>        Topics         { get; set; } = null!;
		public DbSet<Lesson>       Lessons        { get; set; } = null!;

		public ApplicationContext()
		{
			Table<TypeOfLesson>.Value = TypesOfLessons;
			Table<Course>.Value = Courses;
			Table<Topic>.Value = Topics;
			Table<Lesson>.Value = Lessons;
		}

		public DbSet<T> GetTable<T>()
			where T : class
			=> Table<T>.Value;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlite("Data Source = Organizer.db");

		private static class Table<T>
			where T : class
		{
			public static DbSet<T> Value = null!;
		}
	}
}