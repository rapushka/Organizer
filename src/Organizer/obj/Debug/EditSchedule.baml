   M S B A M L   `   `   `  ����D  @Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Organizer	Organizer  5          Organizer.EditSchedule   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Organizer     5        N� Title$  EditSchedule��5	       � 	Resources 5
         ButtonRStyle1 �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding	 J� SnapsToDevicePixels
 �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6&   .�5      ��  � ��# � ��6+   �� 5       � ��$ 1q�6(   �� 5       � ��$ 1q�60   �� 5       � �� �#C5B2E26+   �� 5       � ��
 ���� 6,   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Bd��6!   $ 0��6-   #��z��6>   #��z��6j   #��z��5      # z��6G   	 . ._�5      �� #��z��6/   #��z��6c   # z
 5   !   #��z��6]   #	 z	 5   !   #��z��6]   5       5      P� 5       �@J�IsMouseOver . . �5    "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5!   "   $ Bd��6?    � �� �#ad9ac96O   5"      P� 5#       �@J�IsKeyboardFocused . . �5$   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5%   "   $ Bd��6?    � �� �#ad9ac96O   5&      P� 5'       � �� . . �5(   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5)   "   $ Bd��6?    � �� �#ad9ac96O   5*      P� 5+       � {� .  . �5,   "   �� # � ��6?    � ��5-      5/      51      52      53      .��55      �  � RowDefinitions 56   
   �� 57      $��64 �6   �� 58      $��48 �6   �� 59      $��51 �6   �� 5:      $��48 �6   �� 5;      $��82 �6   �� 5<      $��267.2 �6   .+�5>   
   �� $��0��6   ._�5?      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5@      $
��Left=�5A      $��5,15,5,0q�5B      .+�5C      �� $=��7ФИО выбранного ученика/Группа��6   $��18(�5D      $��Segoe UI Light)�6*   5E      5F      �� 5G   
   $��1��6   ._�5H      �� $ 
Horizontal=�6   $��Center=�5I      $
��Left=�5J      $��5,5,5,0q�5K      .+�5L      �� $��
Курс: ��6   $��18(�5M      $��Segoe UI Light)�6*   5N      5O      �� 5P   
   $��2��6   ._�5Q      �� $ 
Horizontal=�6   $��Center=�5R      $
��Left=�5S      $��5,5,5,0q�5T      .+�5U      �� $��	Дата:��6   $��18(�5V      $��Segoe UI Light)�6*   $��25��5W      $��49��6(   (  "System.Windows.Controls.DatePicker  5X      $��18(�6   $��Segoe UI Light)�6+   $	��288��5Y      $��34��6)   5Z      5[      �� 5\   
   $��3��6   ._�5]      �� $ 
Horizontal=�6   $��Center=�5^      $
��Left=�5_      $��5,5,5,0q�5`      .+�5a      �� $��Время:��6   $��18(�5b      $��Segoe UI Light)�6*   $��25��5c      $��61��6(     5d      $��18(�6   $��Segoe UI Light)�6+   $	��275��5e      $��34��6)   5f      5g      �� 5h   
   $��4��6   ._�5i      �� $ 
Horizontal=�6   $��Center=�5j      $
��Left=�5k      $��5,5,5,0q�5l      .+�5m      �� $��Примечание:��6   $��18(�5n      $��Segoe UI Light)�6*   $��25��5o      $	��114��6(   �� 5p      $��68��6   $	��553��5q      $��18(�5r      $��Segoe UI Light)�6(   5s      5t      �� 5u   
   $��5��6   ._�5v      �� $ 
Horizontal=�6   $	��Top=�5w      $
��Left=�5x      $��5,20,5,0q�5y      .+�5z      �� $��Добавить��6   $	��323��5{      $��31��6%   #���   5|      $��18(�5}      $��Segoe UI Light)�6'   $��0,0,20,0q�5~      �� 5      -   5        $��Отменить��5      $	��323��5�      $��31��6%   #���   5�      $��18(�5�      $��Segoe UI Light)�6'   5�      5�      5�      5�      5�      