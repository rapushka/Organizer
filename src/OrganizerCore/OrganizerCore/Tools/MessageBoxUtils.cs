using System.Collections.Generic;
using System.Linq;
using System.Windows;
using OrganizerCore.DbWorking;
using OrganizerCore.Model;
using static System.Windows.MessageBoxButton;
using static System.Windows.MessageBoxImage;
using static System.Windows.MessageBoxResult;

namespace OrganizerCore.Tools;

public static class MessageBoxUtils
{
	private static MessageBoxButton OK => MessageBoxButton.OK;

	public static bool ConfirmDeletion<T>(T of)
		where T : Table
	{
		var dependentEntries = Dependencies.For(of);

		if (dependentEntries.Any() == false)
		{
			return true;
		}

		var entries = string.Join(",\n", dependentEntries);

		return ShowEnsure($"В базе данных остались связаные записи:\n{entries}\n\nПродолжить?");
	}

	public static bool ShowEnsure(string message)
	{
		var result = MessageBox.Show
		(
			messageBoxText: message,
			caption: "Предупреждение",
			button: YesNo,
			icon: Warning
		);
		return result == Yes;
	}

	public static void ShowError(string message)
		=> MessageBox.Show
		(
			messageBoxText: message,
			caption: "Ошибка",
			button: OK,
			icon: Error
		);
}