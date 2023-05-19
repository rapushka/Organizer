using System.Linq;
using System.Windows;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;

namespace OrganizerCore.Tools;

public static class MessageBoxUtils
{
	public static bool ConfirmDeletion(TypeOfLesson of)
	{
		var dependentEntries = Dependencies.For(of);

		if (dependentEntries.Any())
		{
			var entries = string.Join(",\n", dependentEntries);

			var result = MessageBox.Show
			(
				messageBoxText: $"В бд остались связаные записи:\n{entries}\n\nПродолжить?",
				caption: "Предупреждение",
				button: MessageBoxButton.YesNo,
				icon: MessageBoxImage.Warning
			);
			if (result != MessageBoxResult.Yes)
			{
				return false;
			}
		}

		return true;
	}
}