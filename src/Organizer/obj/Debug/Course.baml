   M S B A M L   `   `   `  ����D  @Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Organizer	Organizer  5          Organizer.Course   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Organizer     5        N� Title$  Course��5	       � 	Resources 5
         ButtonRStyle1 �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding	 J� SnapsToDevicePixels
 �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6&   .�5      ��  � ��# � ��6+   �� 5       � ��$ 1q�6(   �� 5       � ��$ 1q�60   �� 5       � �� �#C5B2E26+   �� 5       � ��
 ���� 6,   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Bd��6!   $ 0��6-   #��z��6>   #��z��6j   #��z��5      # z��6G   	 . ._�5      �� #��z��6/   #��z��6c   # z
 5   !   #��z��6]   #	 z	 5   !   #��z��6]   5       5      P� 5       �@J�IsMouseOver . . �5    "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5!   "   $ Bd��6?    � �� �#ad9ac96O   5"      P� 5#       �@J�IsKeyboardFocused . . �5$   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5%   "   $ Bd��6?    � �� �#ad9ac96O   5&      P� 5'       � �� . . �5(   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5)   "   $ Bd��6?    � �� �#ad9ac96O   5*      P� 5+       � {� .  . �5,   "   �� # � ��6?    � ��5-      5/      51      52      53      .��55      �  � ColumnDefinitions 56   
   �� 57      $
��500* �6   �� 58      $
��618* �6   �� 59      $
��500* �6    � RowDefinitions 5;   
   �� 5<      $��55 �6   �� 5=      $
��210* �6   �� 5>      $��55 �6   �� 5?      $
��191* �6   �� 5@      $��55 �6   .+�5B   
   �� $��0��6   $��2��6   ._�5C      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5D      $��Center=�5E      $��5,10,5,5q�5F      .+�5G      �� $��Наименование:��6   $��18(�5H      $��Segoe UI Light)�6*   $	��129��6F   �� 5I      $��30��6   $	��741��6&   $��18(�5J      $��Segoe UI Light)�6(   5K      5L      �� 5M   
   $��0��6   $��2��6   ._�5N      �� $ 
Horizontal=�6   $��Center=�5O      $��Center=�5P      $��5,10,5,5q�5Q      .+�5R      �� $��Стоимость:��6   $��18(�5S      $��Segoe UI Light)�6*   $��92��6F   �� 5T      $��30��6   $	��130��6&   $��18(�5U      $��Segoe UI Light)�6(   $��0,0,5,0q�5V      �� 5W      $��30��6   $	��130��6&   $��18(�5X      $��Segoe UI Light)�6(   5Y      5Z      �� 5[   
   $��1��6   $��3��6   ._�5\      �� $ 
Horizontal=�6   $��Stretch=�5]      $��Stretch=�5^      $��5,5,5,5q�5_      .+�5`      &   System.Windows.Controls.DataGrid  $
��1283��6   $��
0,0,0,-0.2q�6(   5a      5b      �� 5c   
   $��2��6   $��2��6   ._�5d      �� $ 
Horizontal=�6   $��Center=�5e      $��Center=�5f      $��5,5,5,5q�5g      .+�5h      �� -   5        $��Добавить курс��5h      $	��370��5i      $��31��6%   #���   5j      $��18(�5k      $��Segoe UI Light)�6'   5l      5m      5n      �� 5o   
   $��3��6   $��3��6   ._�5p      �� $ 
Horizontal=�6   $��Stretch=�5q      $��Stretch=�5r      $��5,5,5,5q�5s      .+�5t        $
��1283��6   $��
0,0,0,-0.2q�6(   5u      5v      �� 5w   
   $��4��6   $��2��6   ._�5x      �� $ 
Horizontal=�6   $��Center=�5y      $��Center=�5z      $��5,5,5,5q�5{      .+�5|      �� -   5        $%��Добавить занятие��5|      $	��370��5}      $��31��6%   #���   5~      $��18(�5      $��Segoe UI Light)�6'   5�      5�      5�      5�      5�      