   M S B A M L   `   `   `  ����D  @Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Organizer	Organizer  5          Organizer.EditIndCourse   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Organizer     5        N� Title$  EditIndCourse��5	       � 	Resources 5
         ButtonRStyle1 �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding	 J� SnapsToDevicePixels
 �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6&   .�5      ��  � ��# � ��6+   �� 5       � ��$ 1q�6(   �� 5       � ��$ 1q�60   �� 5       � �� �#C5B2E26+   �� 5       � ��
 ���� 6,   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Bd��6!   $ 0��6-   #��z��6>   #��z��6j   #��z��5      # z��6G   	 . ._�5      �� #��z��6/   #��z��6c   # z
 5   !   #��z��6]   #	 z	 5   !   #��z��6]   5       5      P� 5       �@J�IsMouseOver . . �5    "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5!   "   $ Bd��6?    � �� �#ad9ac96O   5"      P� 5#       �@J�IsKeyboardFocused . . �5$   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5%   "   $ Bd��6?    � �� �#ad9ac96O   5&      P� 5'       � �� . . �5(   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5)   "   $ Bd��6?    � �� �#ad9ac96O   5*      P� 5+       � {� .  . �5,   "   �� # � ��6?    � ��5-      5/      51      52      53      .��55      �  � RowDefinitions 56   
   �� 57      $��55 �6   �� 58      $��55 �6   �� 59      $��55 �6   �� 5:      $��55 �6   �� 5;      $��55 �6   �� 5<      $
��351* �6   .+�5>   
   �� $��0��6   ._�5?      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5@      $
��Left=�5A      $��5,15,5,5q�5B      .+�5C      �� $0��*ФИО выбранного ученика��6   $��18(�5D      $��Segoe UI Light)�6*   5E      5F      �� 5G   
   $��1��6   ._�5H      �� $ 
Horizontal=�6   $��Center=�5I      $
��Left=�5J      $��5,5,5,5q�5K      .+�5L      �� $2��,Курс выбранного ученика��6   $��18(�5M      $��Segoe UI Light)�6*   5N      5O      �� 5P   
   $��2��6   ._�5Q      �� $ 
Horizontal=�6   $��Center=�5R      $
��Left=�5S      $��5,5,5,5q�5T      .+�5U      �� $��Дата начала:��6   $��18(�5V      $��Segoe UI Light)�6*   $��30��6F   $	��109��6R   (  "System.Windows.Controls.DatePicker  5W      $��18(�6   $��Segoe UI Light)�6+   $	��244��5X      $��34��6)   5Y      5Z      �� 5[   
   $��3��6   ._�5\      �� $ 
Horizontal=�6   $��Center=�5]      $
��Left=�5^      $��5,5,5,5q�5_      .+�5`      �� $"��Дата окончания:��6   $��18(�5a      $��Segoe UI Light)�6*   $��30��6F   $	��135��6R     5b      $��18(�6   $��Segoe UI Light)�6+   $	��218��5c      $��34��6)   5d      5e      �� 5f   
   $��4��6   ._�5g      �� $ 
Horizontal=�6   $��Center=�5h      $
��Left=�5i      $��5,5,5,5q�5j      .+�5k      �� $��Добавить��6   $	��353��5l      $��31��6%   #���   5m      $��18(�5n      $��Segoe UI Light)�6'   5o      5p      �� 5q   
   $��5��6   ._�5r      �� $ 
Horizontal=�6   $	��Top=�5s      $
��Left=�5t      $��5,5,5,5q�5u      .+�5v      �� -   5        $��Отменить��5v      $	��353��5w      $��31��6%   #���   5x      $��18(�5y      $��Segoe UI Light)�6'   6C   5z      5{      5|      5}      