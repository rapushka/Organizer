   M S B A M L   `   `   `  ����  OrganizerCore>    8OrganizerCore.Windows.Pages.ScheduleTab.EditSchedulePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gDotNetProjects.Wpf.Extended.Toolkit, Version=4.5.71.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5        $	��600��5      $	��560��6     N� Title$  EditSchedulePage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��4* �6   .+�5   
   �� $��0��6   $��0��6%   $��2��5       �� Orientation$ 
Horizontal=�5      .+�5      �� $ Vertical=�6   $��Center=�5      $��Center=�5      $��25,0,0,0q�5      .+�5      	� -   5         	�Name$ ShowAllRadioButton��5      $��18(�5      $��Segoe UI Light)�6,   $	��225��5       $��22��6*   $��Все��5!       	� 	GroupName$ 
HeldStatus��5"       d� 	IsChecked$
 TrueY�65   5#      	� 5$      -   5        $ OnlyIndividualRadioButton��5$      $��18(�5%      $��Segoe UI Light)�6,   $	��225��5&      $��22��6*   $"��Индивидуальные��5'      $ 
HeldStatus��5(      5)      	� 5*      -   5        $ OnlyGroupRadioButton��5*      $��18(�5+      $��Segoe UI Light)�6,   $	��225��5,      $��22��6*   $��Груповые��5-      $ 
HeldStatus��5.      5/      50      �� 52      $��Center=�53      .+�54      �� $��Right=�55      $ 
Horizontal=�56      .+�57      ��  
  Header#���   58      $��	Курс:��59      �� 5:      -   5        $��CourseComboBox��5;       �� 
IsEditable$
 True��5<      $��27��5=      $	��250��5>      $��18(�5@      $��Segoe UI Light)�6'   5A      �� 5B      $��Right=�5C      $ 
Horizontal=�5D      .+�5E      �� #���   5F      $��Занятие:��5G      �� 5H      -   5        $��LessonComboBox��5I      $
 True��5J      $��29��5K      $	��250��5L      $��18(�5M      $��Segoe UI Light)�6'   5N      5O      5P      �� 5S   
   $��0��6   $��1��6$   #���   5T      $��Right=�5U      $	��Top=�5V      $��15q�5W      $��Дата и время:��5X      &   Xceed.Wpf.Toolkit.DateTimePicker  5Y   
   -   5          Name$ DateTimePicker��5Z      $��1��5Y      $��1��6.   $��15,13,15,12q�5[      $��18(�5]      $��Segoe UI Light)�6,   �� 5_   
   $��0��6   $��2��6$   #���   5`      $��Right=�5a      $	��Top=�5b      $��15q�5c      $��Заметки:��5d      �� 5e   
   -   5        $��NoteTextBox��5f      $��1��5e      $��2��6"     TextBox#���  5g      $��15q�5h      	 �� MaxLines$		 100��5i      �� 5l   
   $��0��6   $��3��6%   $��2��5m      $ 
Horizontal=�5n      $��Center=�5o      .+�5p      �� -	   5          PurpleButton#���  5q      $��Применить��5r      $	��125��5s   -   �� 5t      -
   5        #���  5u      $��Отменить��5v      $	��125��5w   .   5x      5y      5z      