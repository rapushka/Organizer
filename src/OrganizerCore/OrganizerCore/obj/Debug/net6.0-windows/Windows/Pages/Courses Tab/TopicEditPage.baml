   M S B A M L   `   `   `  ����  OrganizerCore/    )OrganizerCore.Windows.Pages.TopicEditPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          N� Title$  TopicEditPage��5      $	��550��6   $	��500��6*   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��5* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6$   $��2��5       �� TextAlignment$ Center=�5      $��18(�5      $��Segoe UI Light)�5      $��10q�5      $��Тема��5      �� 5!   
   $��0��6   $��1��6$   $ Right=�5"       
  Header#��[  5#      $��	Курс:��5%      �� 5&   
   -   5         ��Name$ CourseTitleTextBlock��5'      $��1��5&      $��1��6$   $��Center=�5(      #��[  5)      $#��[Название курса]��5*      �� 5,   
   $��0��6   $��2��6$   $ Right=�5-      #��[  5.      $��Название:��5/      �� 50   
   -   5         ��Name$ TitleTextBox��51      $��1��50      $��2��6"   $��Center=�52      $��10q�53      $��18(�54      $��Segoe UI Light)�55      $!��[Название темы]��57      �� 59   
   $��0��6   $��3��6$   $��2��5:      #��[  5;      $��Bottom=�5<      $��
10,10,10,0q�5=      $��Занятия:��5>      &   System.Windows.Controls.DataGrid  5?   
   -   5          Name$ LessonsDataGrid��5A      $��0��5?      $��4��6#   $��2��5@      $��18(�5B      $��Segoe UI Light)�5C         CanUserAddRows$ False��5D      $��10q�5F      �� 5H   
   $��0��6   $��5��6%   $��2��5I       �� Orientation$ 
Horizontal=�5J      $��Center=�5K      .+�5L      �� -   5          PurpleButton#��[ 5L      $��Добавить��5N      $	��110��6)   �� 5O      -   5        #��[ 5O      $��Удалить��5Q      $	��110��6'   �� 5R      -   5        #��[ 5R      $8��2Редактировать Виды занятий��5T      5V      �� 5W   
   $��0��6   $��6��6%   $��2��5X      $ 
Horizontal=�5Y      $��Center=�5Z      .+�5[      �� -   5        #��[ 5[      $��Применить��5]      $	��150��6)   �� 5^      -	   5        #��[ 5^      $��Отмена��5`      $	��150��6'   5a      5b      5c      