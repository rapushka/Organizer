   M S B A M L   `   `   `  ����D  @Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Organizer	Organizer  5          Organizer.Schedule   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Organizer     5        N� Title$  Schedule��5	       � 	Resources 5
         ButtonRStyle1 �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding	 J� SnapsToDevicePixels
 �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6&   .�5      ��  � ��# � ��6+   �� 5       � ��$ 1q�6(   �� 5       � ��$ 1q�60   �� 5       � �� �#C5B2E26+   �� 5       � ��
 ���� 6,   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Bd��6!   $ 0��6-   #��z��6>   #��z��6j   #��z��5      # z��6G   	 . ._�5      �� #��z��6/   #��z��6c   # z
 5   !   #��z��6]   #	 z	 5   !   #��z��6]   5       5      P� 5       �@J�IsMouseOver . . �5    "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5!   "   $ Bd��6?    � �� �#ad9ac96O   5"      P� 5#       �@J�IsKeyboardFocused . . �5$   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5%   "   $ Bd��6?    � �� �#ad9ac96O   5&      P� 5'       � �� . . �5(   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5)   "   $ Bd��6?    � �� �#ad9ac96O   5*      P� 5+       � {� .  . �5,   "   �� # � ��6?    � ��5-      5/      51      52      53      .��55      �  � ColumnDefinitions 56   
   �� 57      $	��83* �6   �� 58      $
��313* �6   �� 59      $
��314* �6   �� 5:      $
��292* �6   �� 5;      $
��291* �6    � RowDefinitions 5=   
   �� 5>      $
��55.2 �6   �� 5?      $
��43.2 �6   �� 5@      $
��31.2 �6   �� 5A      $��* �6   �� 5B      $��62 �6   .+�5D   
   �� $��0��6   $��2��6   ._�5E      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5F      $	��Top=�5G      $��5,15,5,0q�5H      .+�5I      �� $$��Фамилия ученика:��6   $��18(�5J      $��Segoe UI Light)�6&   $	��153��6B   �� 5K      $��30��6   $�� ��5L      $	��227��5M      $��18(�5N      $��Segoe UI Light)�6(   $��5,0,0,0q�5O      5P      5Q      �� 5R   
   $��0��6   $��2��6   ._�5S      �� $ 
Horizontal=�6   $��Center=�5T      $	��Top=�5U      $��5,15,5,0q�5V      .+�5W      �� $��Группа:��6   $��18(�5X      $��Segoe UI Light)�6&   �� 5Y      $��30��6   $	��225��5Z      $��18(�5[      $��Segoe UI Light)�6'   $��5,0,0,0q�5\      5]      5^      �� 5_   
   $��0��6   $��3��6   ._�5`      �� $ 
Horizontal=�6   $
��Left=�5a      $	��Top=�5b      $��5,15,5,0q�5c      .+�5d      �� $��Дата с:��6   $��18(�5e      $��Segoe UI Light)�6&   (  "System.Windows.Controls.DatePicker  5f      $��18(�6   $��Segoe UI Light)�6+   $	��195��5g      $��13,0,0,0q�6)   5h      5i      �� 5j   
   $��0��6   $��4��6   ._�5k      �� $ Vertical=�6   $��Center=�5l      $	��Top=�5m      $��5,10,5,0q�5n      .+�5o      �� $��Проведено��6   $��18(�5p      $��Segoe UI Light)�6)   $	��123��5q      $��22��6'   �� 5r      $��Не проведено��6   $��18(�5s      $��Segoe UI Light)�6)   $	��153��5t      $��26��6'   5u      5v      �� 5w   
   $��3��6   $��1��6!   ._�5x      �� $ 
Horizontal=�6   $
��Left=�5y      $	��Top=�5z      $��5,0,0,0q�5{      .+�5|      �� $��Дата по:��6   $��18(�5}      $��Segoe UI Light)�6&   $��37��5~      $��82��6$     5      $��18(�6   $��Segoe UI Light)�6+   $	��190��5�      $��34��6)   5�      5�      �� 5�   
   $��2��6   $��3��6   ._�5�      �� $ 
Horizontal=�6   $��Center=�5�      $	��Top=�5�      $��5,5,5,0q�5�      .+�5�      �� $��Сегодня��6   $��18(�5�      $��Segoe UI Light)�6)   $	��123��5�      $��26��6'   �� 5�      $��Применить��6   $��18(�5�      $��Segoe UI Light)�6)   $	��123��5�      $��26��6'   5�      5�      �� 5�   
   $��3��6   $��5��6   ._�5�      �� $��Stretch=�6   $��Stretch=�5�      $ 
Horizontal=�5�      $��5q�5�      .+�5�      &   System.Windows.Controls.DataGrid  $
��1283��6   5�      5�      �� 5�   
   $��4��6   $��0��6   ._�5�      �� $��Center=�6   $��Center=�5�      .+�5�      �� $��40��6   $��40��6$   #���   5�      .��5�      �� $��30��6   $��выгрузить.ico��6(   $
��Fill=�6?   $��30��6N   5�      5�      5�      �� 5�   
   $��4��6   $��3��6   ._�5�      �� $��Center=�6   $��Center=�5�      .+�5�      �� $��Проведено��6   $	��250��5�      $��31��6%   #���   5�      $��18(�5�      $��Segoe UI Light)�6'   5�      5�      �� 5�   
   $��4��6   $��4��6   ._�5�      �� $��Center=�6   $��Center=�5�      .+�5�      �� -   5        $%��Добавить занятие��5�      $	��250��5�      $��31��6%   #���   5�      $��18(�5�      $��Segoe UI Light)�6'   6C   5�      5�      5�      5�      