   M S B A M L   `   `   `  ����D  @Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Organizer	Organizer  5          Organizer.AddStudent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Organizer     5        N� Title$  
AddStudent��5	       � 	Resources 5
         ButtonRStyle1 �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding	 J� SnapsToDevicePixels
 �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6&   .�5      ��  � ��# � ��6+   �� 5       � ��$ 1q�6(   �� 5       � ��$ 1q�60   �� 5       � �� �#C5B2E26+   �� 5       � ��
 ���� 6,   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Bd��6!   $ 0��6-   #��z��6>   #��z��6j   #��z��5      # z��6G   	 . ._�5      �� #��z��6/   #��z��6c   # z
 5   !   #��z��6]   #	 z	 5   !   #��z��6]   5       5      P� 5       �@J�IsMouseOver . . �5    "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5!   "   $ Bd��6?    � �� �#ad9ac96O   5"      P� 5#       �@J�IsKeyboardFocused . . �5$   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5%   "   $ Bd��6?    � �� �#ad9ac96O   5&      P� 5'       � �� . . �5(   "   �� $ Bd��6@    � �� �	#80DADADA6P   �� 5)   "   $ Bd��6?    � �� �#ad9ac96O   5*      P� 5+       � {� .  . �5,   "   �� # � ��6?    � ��5-      5/      51      52      53      .��55      �  � ColumnDefinitions 56   
   �� 57      $
��162* �6   �� 58      $
��161* �6    � RowDefinitions 5:   
   �� 5;      $��41 �6   �� 5<      $��34 �6   �� 5=      $��42 �6   �� 5>      $
��40.8 �6   �� 5?      $��40 �6   �� 5@      $��36 �6   �� 5A      $��45 �6   �� 5B      $��36 �6   �� 5C      $��48 �6   �� 5D      $��42 �6   �� 5E      $��48 �6   �� 5F      $	��108 �6   .+�5H   
   �� $��0��6   $��2��6   ._�5I      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5J      $��Center=�5K      $��5,5,5,5q�5L      .+�5M      �� $&�� Данные об ученике��6   $��20(�5N      $��Segoe UI Light)�6&   5O      5P      �� 5Q   
   $��2��6   $��1��6%   ._�5R      �� $ 
Horizontal=�6   $��Center=�5S      $
��Left=�5T      $��5,0,5,0q�5U      .+�5V      �� $��Фамилия:��6   $��18(�5W      $��Segoe UI Light)�6*   $��26��5X      $��80��6(   �� 5Y      $��30��6   $
��1203��6&   $��18(�5Z      $��Segoe UI Light)�6(   5[      5\      �� 5]   
   $��2��6   $��2��6   ._�5^      �� $ 
Horizontal=�6   $��Center=�5_      $
��Left=�5`      $��5,0,0,0q�5a      .+�5b      �� $��Имя:��6   $��18(�5c      $��Segoe UI Light)�6*   $��21��5d      $��45��6(   �� 5e      $��30��6   $
��1238��6&   $��18(�5f      $��Segoe UI Light)�6(   5g      5h      �� 5i   
   $��3��6   $��2��6   ._�5j      �� $ 
Horizontal=�6   $��Center=�5k      $
��Left=�5l      $��5,0,0,0q�5m      .+�5n      �� $��Отчество:��6   $��18(�5o      $��Segoe UI Light)�6&   $��23��5p      $��83��6$   �� 5q      $��30��6   $
��1199��6&   $��18(�5r      $��Segoe UI Light)�6(   5s      5t      �� 5u   
   $��4��6   $��0��6   ._�5v      �� $ 
Horizontal=�6   $��Center=�5w      $
��Left=�5x      $��5,0,0,0q�5y      .+�5z      �� $ ��Дата рождения:��6   $��18(�5{      $��Segoe UI Light)�6*   $��23��5|      $	��133��6(   (  "System.Windows.Controls.DatePicker  5}      $��18(�6   $��Segoe UI Light)�6+   $	��507��5~      $��31��6)   5      5�      �� 5�   
   $��4��6   $��1��6   ._�5�      �� $ 
Horizontal=�6   $��Center=�5�      $
��Left=�5�      $��5,0,0,0q�5�      .+�5�      �� $��Телефон:��6   $��18(�5�      $��Segoe UI Light)�6*   $��23��5�      $��78��6(   �� 5�      $��30��6   $	��555��6&   $��18(�5�      $��Segoe UI Light)�6(   5�      5�      �� 5�   
   $��5��6   $��2��6   ._�5�      �� $ 
Horizontal=�6   $��Center=�5�      $
��Left=�5�      $��5,0,0,0q�5�      .+�5�      �� $(��"Электронная почта:��6   $��18(�5�      $��Segoe UI Light)�6*   $��23��5�      $	��161��6(   �� 5�      $��30��6   $
��1121��6&   $��18(�5�      $��Segoe UI Light)�6(   5�      5�      �� 5�   
   $��6��6   $��2��6   ._�5�      �� $ 
Horizontal=�6   $��Center=�5�      $��Center=�5�      $��5,5,5,5q�5�      .+�5�      �� $B��<Данные о доверенном лице ученика��6   $��20(�5�      $��Segoe UI Light)�6&   $��28��5�      $	��330��6$   5�      5�      �� 5�   
   $��7��6   $��2��6   ._�5�      �� $ 
Horizontal=�6   $��Center=�5�      $
��Left=�5�      $��5,0,0,0q�5�      .+�5�      �� $��Фамилия:��6   $��18(�5�      $��Segoe UI Light)�6*   $��24��5�      $��79��6(   �� 5�      $��30��6   $
��1203��6&   $��18(�5�      $��Segoe UI Light)�6(   5�      5�      �� 5�   
   $��8��6   $��2��6   ._�5�      �� $ 
Horizontal=�6   $��Center=�5�      $
��Left=�5�      $��5,0,0,0q�5�      .+�5�      �� $��Имя:��6   $��18(�5�      $��Segoe UI Light)�6*   $��28��5�      $��42��6(   �� 5�      $��30��6   $
��1240��6&   $��18(�5�      $��Segoe UI Light)�6(   5�      5�      �� 5�   
   $��9��6   $��2��6   ._�5�      �� $ 
Horizontal=�6   $��Center=�5�      $
��Left=�5�      $��5,0,0,0q�5�      .+�5�      �� $��Отчество:��6   $��18(�5�      $��Segoe UI Light)�6*   $��24��5�      $��82��6(   �� 5�      $��30��6   $
��1199��6&   $��14(�5�      $��Segoe UI Light)�6(   5�      5�      �� 5�   
   $��10��6   $��2��6   ._�5�      �� $ 
Horizontal=�6   $��Center=�5�      $
��Left=�5�      $��5,0,0,0q�5�      .+�5�      �� $��Телефон:��6   $��18(�5�      $��Segoe UI Light)�6*   $��25��5�      $��79��6(   �� 5�      $��30��6   $
��1200��6&   $��18(�5�      $��Segoe UI Light)�6(   5�      5�      �� 5�   
   $��11��6   $��1��6   ._�5�      �� $ 
Horizontal=�6   $	��Top=�5�      $��Center=�5�      $��0,20,0,0q�5�      .+�5�      �� $��Добавить��6   $	��313��5�      $��31��6%   #���   5�      $��18(�5�      $��Segoe UI Light)�6'   �� 5�      -   5        $��Отменить��5�      $	��313��5�      $��31��6%   #���   5�      $��18(�5�      $��Segoe UI Light)�6'   5�      5�      5�      5�      5�      