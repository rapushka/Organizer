using System;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Organizer.DbWorking
{
	public class DataBaseConnection
	{
		private static DataBaseConnection? _instance;

		private DataBaseConnection() { }

		public static DataBaseConnection Instance => _instance ??= new DataBaseConnection();

		private ApplicationContext? _currentContext;

		public ApplicationContext CurrentContext => _currentContext ?? throw new NullReferenceException();

		public ObservableCollection<T> Observable<T>()
			where T : class
			=> CurrentContext.GetTable<T>().Local.ToObservableCollection();

		public bool IsConnected => _currentContext is not null;

		public ApplicationContext OpenDataBase()
		{
			_currentContext = new ApplicationContext();
			_currentContext.Database.Migrate();
			_currentContext.Database.EnsureCreated();

			_currentContext.TypesOfLessons.Load();
			_currentContext.Courses.Load();
			_currentContext.Topics.Load();

			return _currentContext;
		}
	}
}