   M S B A M L   `   `   `  ����Q  MpayrollSystem Version2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:payrollSystem_Version2payrollSystem_Version2  5   	   *    $payrollSystem_Version2.AdminEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:payrollSystem_Version2     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Employee List��5	   	   $��739.27��6   $��1193.677��6/    � 
ResizeMode$ CanResizeWithGrip=�6@    � WindowStartupLocation$ CenterScreen=�6_   .��5
      � $��0,0,0.2,0.2q�6   .+�5   
   � ���	#FF374057$��
0,0,0,-2.6q�6&   .+�5      �� $
��Left=�6   $��57��64   $��1073,85,0,0q�6@   $	��Top=�6U   $��57��6m    J� RenderTransformOrigin$ 1.093,0.542&�6x   .+�5      �� $��resources/search.png��6   $��-3,0,-0.2,0q�66   $��53��6K   5      �� 5      -   5         ��Name$ label1_Copy3��5      $��Search Employee:��6*   $
��Left=�6E   $��43��6`   $��
573,99,0,0q�6l   $	��Top=�6�   $	��194��6�   $��24(�6�   $��Cambria Math)�6�   ���	#FFD4F2E86�   �� 5      -   5         ��Name$ 	txtSearch��5      $
��Left=�6)   $��29��6D   $��772,103,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��298��6�   $ 0.412,-0.03&�6�   ���	#FF76798A
�������$��Cambria Math)�6  $��16(�6)  &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
dtgemplist��5      $��0,0,39.2,78.2q�6+   
�������$��Cambria Math)�6s   $��Normal"�6�   $��Visible=�5      $��Stretch=�6L    � ToolTip$ Employee Details��6q   $	��438��6�   $��Bottom=�6�   $ 0.5,0.5&�6�   $��Right=�6�   $
��1113��6�   $��14(�6C  	   
IsReadOnly	 . 
 �� IsTextSearchEnabled
 .    CanUserResizeRows .     RowDetailsVisibilityMode$ Visible=�6�  ��5   B   Z�    VerticalGridLinesBrush 5   �   Z�    HorizontalGridLinesBrush 6  Z� z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.225Q�6*   T� 5      5      ��5      �� 5       �� EndPoint$ 0.5,0&�6*    �� 
StartPoint$ 0.5,1&�6;   .��5      �  � Color$ 	#FF27C8FD��6'    � Offset$ 0Q�69   � 5       $ 	#FF50A0FD��6'   $ 0.339Q�69   � 5!      $ 	#FF5A84F5��6'   $ 0.661Q�69   � 5"      $ 	#FF6589FD��6'   $ 1Q�69   5#         Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ 
EmployeeID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6\      
FontFamily$ Cambria Math)�6h      FontSize$ 14Q�6�      
FontWeight$
 Bold"�6�      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
EmployeeID+6�     5(      $
 Name��6)   $	 180 6P   $ Cambria Math)�6\   $ 14Q�6v   $
 Bold"�6�    .  67   �� *Name+6�     5)      $ Gender��6)   $ 80 6T   $ Cambria Math)�6_   $ 14Q�6y   $
 Bold"�6�    .  69   �� *Gender+6�     5*      $	 Age��6)   $ 70 6N   $ Cambria Math)�6Y   $ 14Q�6s   $
 Bold"�6�    .  66   �� *Age+6�     5+      $ Birthday��6)   $	 110 6Y   $ Cambria Math)�6e   $ 14Q�6   $
 Bold"�6�    .  6;   �� *	Birthdate+6�     5,      $ Address��6)   $	 400 6V   $ Cambria Math)�6b   $ 14Q�6|   $
 Bold"�6�    .  6:   �� *	Address+6�     5-      $ Status��6)   $ 80 6T   $ Cambria Math)�6_   $ 14Q�6y   $
 Bold"�6�    .  69   �� *Status+6�     5.      $ Contact��6)   $	 120 6V   $ Cambria Math)�6b   $ 14Q�6|   $
 Bold"�6�    .  6:   �� *	Contact+6�     5/      $ Emergency Contact��6)   $	 130 6a   $ Cambria Math)�6m   $ 14Q�6�   $
 Bold"�6�    .  6D   �� *
Econtact+6�     50      $ Position��6)   $	 110 6X   $ Cambria Math)�6d   $ 14Q�6~   $
 Bold"�6�    .  6;   �� *
Position+6�     51      $ 
Daily Rate��6)   $ 90 6[   $ Cambria Math)�6f   $ 14Q�6�   $
 Bold"�6�    .  6=   �� *	Dailyrate+6�     52      $ Work Status��6)   $	 100 6]   $ Cambria Math)�6i   $ 14Q�6�   $
 Bold"�6�    .  6>   �� *
WorkStatus+6�     53      $ 
Hired Date��6)   $	 110 6W   $ Cambria Math)�6c   $ 14Q�6}   $
 Bold"�6�    .  6=   �� *Hired+6�   55      �� 57      $��Center=�6   $��1013,15,13.2,662.2q�64   .+�58      '  !MaterialDesignThemes.Wpf.PopupBox  $��Stretch=�6*   $��111,5,8.8,5q�6H      PlacementMode$ BottomAndAlignRightEdges=�6]      	StaysOpen .  ���	#FFFCFCFC   PopupContent. 59      �� $	��150��6!   .+�5:      �� -   5         ��Name$ btnHome��5:   !   $
��Home��62   ���	#FFD4AF376X   �� 5;      -   5        $ btnAbout��5;   !   $��About Us��63   ���	#FFD4AF376]   �� 5<      -   5        $ 
btnContact��5<   !   $��
Contact Us��65   ���	#FFD4AF376a   �� 5=      �� 5>      -   5        $
��Help��5>   !   ���	#FFD4AF376G   5?      5@      5A      �� 5B      -   5          ��Name$
  date��5B      ���	#FFD4F2E8$��16(�6>   $��40��6L   $
��Bold"�6X   $
��Left=�6j   $��Center=�6�   $	��264��6�   $��33,26,0,646.2q�6�   �� 6�   $�            ��6�   �� 6�   $�9/26/2019 2:50:36 AM��6�   6  �� 5C      -	   5        $ label��5C      $��E��6#   $
��Left=�6/   $��	35,42,0,0q�6J   $	��Top=�6]   $	��116��6u   $��67��6�   $��Javanese Text)�6�   $
��Bold"�6�   $��72(�6�   ���	#FFD4AF376�   �� 5D      -
   5        $ label1��5D      $��mployee��6$   $
��Left=�66   $��	86,92,0,0q�6Q   $	��Top=�6d   $��50��6|   $	��143��6�   ���	#FFD4AF37$��Cambria Math)�6�   $��36(�6�   �� 5E      -   5        $ label1_Copy��5E      $
��List��6)   $
��Left=�68   $��
221,85,0,0q�6S   $	��Top=�6g   $��52��6   $	��122��6�   ���	#FFF6F5F3$��Cambria Math)�6�   $��48(�6�   5G      5H      5I      