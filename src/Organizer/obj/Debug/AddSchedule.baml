   M S B A M L   `   `   `  ����D  @Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Organizer	Organizer  5          Organizer.AddSchedule   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Organizer     5        N� Title$  AddSchedule��5	       � 	Resources 5
         ButtonRStyle1 �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding	 J� SnapsToDevicePixels
 �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6&   .�5      ��  � ��# � ��6+   �� 5       � ��$ 1q�6(   �� 5       � ��$ 1q�60   �� 5       � �� �#C5B2E26+   �� 5       � ��
 ���� 6,   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Bd��6!   $ 0��6-   #��z��6>   #��z��6j   #��z��5      # z��6G   	 . ._�5      �� #��z��6/   #��z��6c   # z
 5   !   #��z��6]   #	 z	 5   !   #��z��6]   5       5      P� 5       �@J�IsMouseOver . . �5    "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5!   "   $ Bd��6?    � �� �#ad9ac96O   5"      P� 5#       �@J�IsKeyboardFocused . . �5$   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5%   "   $ Bd��6?    � �� �#ad9ac96O   5&      P� 5'       � �� . . �5(   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5)   "   $ Bd��6?    � �� �#ad9ac96O   5*      P� 5+       � {� .  . �5,   "   �� # � ��6?    � ��5-      5/      51      52      53      .��55      �  � ColumnDefinitions 56   
   �� 57      $
��363* �6   �� 58      $
��283* �6    � RowDefinitions 5:   
   �� 5;      $��53 �6   �� 5<      $��49 �6   �� 5=      $
��305* �6   �� 5>      $��51 �6   �� 5?      $��52 �6   �� 5@      $��50 �6   .+�5B   
   �� $��0��6   $��2��6   ._�5C      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�5D      $
��Left=�5E      $��5,10,5,0q�5F      .+�5G      �� $��Вид курса:��6   $��18(�5H      $��Segoe UI Light)�6&   �� 5I      $
��1205��6   $��18(�5J      $��Segoe UI Light)�6)   $��27��6E   5K      5L      �� 5M   
   $��1��6   $��0��6   ._�5N      �� $ 
Horizontal=�6   $	��Top=�5O      $
��Left=�5P      $��5,5,5,0q�5Q      .+�5R      �� $��Фамилия:��6   $��18(�5S      $��Segoe UI Light)�6&   $��37��5T      $��85��6$   �� 5U      $��30��6   $	��632��5V      $��18(�5W      $��Segoe UI Light)�6(   5X      5Y      �� 5Z   
   $��1��6   $��1��6   ._�5[      �� $ 
Horizontal=�6   $	��Top=�5\      $
��Left=�5]      $��5,5,5,0q�5^      .+�5_      �� $��Группа:��6   $��18(�5`      $��Segoe UI Light)�6&   $��37��5a      $��75��6$   �� 5b      $��30��6   $	��Top=�5c      $	��476��5d      $��18(�5e      $��Segoe UI Light)�6(   5f      5g      �� 5h   
   $��2��6   $��0��6   ._�5i      �� $ Vertical=�6   $��Stretch=�5j      $��Stretch=�5k      $��5,5,5,0q�5l      .+�5m      �� $��Ученики��6   $��18(�5n      $��Segoe UI Light)�6+   &   System.Windows.Controls.DataGrid  5o      $	��164��6   $	��715��6(   �� 5p      $��
Курсы��6   $��18(�5q      $��Segoe UI Light)�6+     5r      $��86��6   $	��715��6'   $��	1,0,0.8,0q�63   5s      5t      �� 5u   
   $��2��6   $��1��6   ._�5v      �� $ Vertical=�6   $	��Top=�5w      $
��Left=�5x      $��5,5,5,0q�5y      .+�5z      �� $��Группы��6   $��18(�5{      $��Segoe UI Light)�6+     5|      $	��274��6   $	��551��6(   5}      5~      �� 5   
   $��3��6   $��0��6   ._�5�      �� $ 
Horizontal=�6   $	��Top=�5�      $
��Left=�5�      $��5,5,5,0q�5�      .+�5�      �� $��	Дата:��6   $��18(�5�      $��Segoe UI Light)�6&   $��37��5�      $��54��6$   (  "System.Windows.Controls.DatePicker  5�      $��18(�6   $��Segoe UI Light)�6+   $	��162��5�      $��34��6)   �� 5�      $��Время:��6   $��18(�5�      $��Segoe UI Light)�6&   $��37��5�      $��69��6$   $��20,0,0,0q�5�        5�      $��18(�6   $��Segoe UI Light)�6+   $	��162��5�      $��34��6)   5�      5�      �� 5�   
   $��3��6   $��1��6   ._�5�      �� $ 
Horizontal=�6   $	��Top=�5�      $
��Left=�5�      $��5,5,5,0q�5�      .+�5�      �� $��	Дата:��6   $��18(�5�      $��Segoe UI Light)�6&   $��37��5�      $��54��6$     5�      $��18(�6   $��Segoe UI Light)�6+   $	��162��5�      $��34��6)   �� 5�      $��Время:��6   $��18(�5�      $��Segoe UI Light)�6&   $��37��5�      $��69��6$   $��20,0,0,0q�5�        5�      $��18(�6   $��Segoe UI Light)�6+   $	��162��5�      $��34��6)   5�      5�      �� 5�   
   $��4��6   $��0��6   ._�5�      �� $ 
Horizontal=�6   $	��Top=�5�      $
��Left=�5�      $��5,5,5,0q�5�      .+�5�      �� $��Примечание:��6   $��18(�5�      $��Segoe UI Light)�6&   $��33��5�      $	��125��6$   �� 5�      $��42��6   $	��553��6&   $��18(�5�      $��Segoe UI Light)�6(   5�      5�      �� 5�   
   $��4��6   $��1��6   ._�5�      �� $ 
Horizontal=�6   $	��Top=�5�      $
��Left=�5�      $��5,5,5,0q�5�      .+�5�      �� $��Примечание:��6   $��18(�5�      $��Segoe UI Light)�6&   $��37��5�      $	��125��6$   �� 5�      $��42��6   $	��430��6&   $��18(�5�      $��Segoe UI Light)�6(   5�      5�      �� 5�   
   $��5��6   $��0��6   ._�5�      �� $ 
Horizontal=�6   $	��Top=�5�      $
��Left=�5�      $��5,5,5,0q�5�      .+�5�      �� $��Добавить��6   $	��356��5�      $��31��6%   #���   5�      $��18(�5�      $��Segoe UI Light)�6'   �� 5�      -   5        $��Отменить��5�      $	��356��5�      $��31��6%   #���   5�      $��18(�5�      $��Segoe UI Light)�6'   5�      5�      5�      �� 5�   
   $��5��6   $��1��6   ._�5�      �� $ 
Horizontal=�6   $	��Top=�5�      $
��Left=�5�      $��5,5,5,0q�5�      .+�5�      �� $��Добавить��6   $	��277��5�      $��31��6%   #���   5�      $��18(�5�      $��Segoe UI Light)�6'   �� 5�      -   5        $��Отменить��5�      $	��278��5�      $��31��6%   #���   5�      $��18(�5�      $��Segoe UI Light)�6'   5�      5�      5�      5�      5�      