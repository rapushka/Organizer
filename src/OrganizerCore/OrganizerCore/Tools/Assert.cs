using System;

namespace OrganizerCore.Windows.Pages;

public static class Assert
{
	public static void ThatIs<T>(object source)
	{
		if (source is null)
		{
			throw new NullReferenceException("The variable is null");
		}

		if (source is not T)
		{
			throw new Exception($"{source} is not {typeof(T).Name} (is {source.GetType().Name}");
		}
	}
}