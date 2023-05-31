using System;
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

	public static void AtFirstSelect(string item) => ShowError($"Сначала выберите {item}!");

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

	public static void ShowInfo(string message)
		=> MessageBox.Show
		(
			messageBoxText: message,
			caption: "Успех",
			button: OK,
			icon: Information
		);

	public static void ShowException(Exception ex, string message = "Не удалось сохранить изменения!")
		=> ShowError($"{message}\n{ex.InnerException?.Message ?? ex.Message}");
}