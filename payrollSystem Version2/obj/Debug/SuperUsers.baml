   M S B A M L   `   `   `  ����Q  MpayrollSystem Version2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:payrollSystem_Version2payrollSystem_Version2  5   	   '    !payrollSystem_Version2.SuperUsers   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:payrollSystem_Version2     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  USERS��5	      $��712.6��6   $��861.2��6&    � WindowStartupLocation$ CenterScreen=�65   .��5
      � ���	#FF374057$	��685��6"   $	��Top=�6/   $
��Left=�6G   $	��856��6b   $��0,-2,-1.6,0q�6n   .+�5   
   �� $
��Left=�6   $	��207��60   $��	54,64,0,0q�6=   $	��Top=�6P   $	��187��6h   .+�5      �� $��resources/users.png��6   $	��184��61   $��
0,0,-1.8,0q�6>   5      �� 5   
   -   5         ��Name$ label��5      $��MANAGE USERS��6   $
��Left=�66   $��
378,10,0,0q�6Q   $	��Top=�6e    J� RenderTransformOrigin$ -0.192,0.097&�6}   $	��229��6�   $��
Constantia)�6�   $��20(�6�   $
��Bold"�6�   ���	#FFD4F2E86�   �� 5   
   -   5        $ 
label_Copy��5      $��List of Users:��6$   $
��Left=�6=   $��
60,279,0,0q�6X   $	��Top=�6l   $ -0.192,0.097&�6�   $	��229��6�   $��
Constantia)�6�   $��20(�6�   $
��Bold"�6�   ���	#FFD4F2E86�   �� 5   
   -   5        $ label_Copy1��5      $
��Left=�6%   $��216,157,0,0q�6@   $	��Top=�6U   $ -0.192,0.097&�6m   $��95��6�   $��
Constantia)�6�   $��14(�6�   $
��Bold"�6�   ���	#FFD4F2E86�   �� 5   
   -   5        $ txtUsernameUsers��5      $��	Username:��6*   $
��Left=�6>   $��277,200,0,0q�6Y   $	��Top=�6n   $ -0.192,0.097&�6�   $��95��6�   $��
Constantia)�6�   $��14(�6�   $
��Bold"�6�   ���	#FFD4F2E86�   �� 5   
   -   5        $ label_Copy4��5      $
��Left=�6%   $��
219,77,0,0q�6@   $	��Top=�6T   $ -0.192,0.097&�6l   $��95��6�   $��
Constantia)�6�   $��14(�6�   $
��Bold"�6�   ���	#FFD4F2E86�   �� 5   
   -   5        $ label_Copy6��5      $��User Level:��6%   $
��Left=�6;   $	��Top=�6V   $ -0.192,0.097&�6n   $��96��6�   $��
Constantia)�6�   $��14(�6�   $
��Bold"�6�   ���	#FFD4F2E8$��278,161,0,0q�6�   �� 5   
   -   5         ��Name$ txtUsername��5      $
��Left=�6'   $��23��6B   $��401,203,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��216��6�   ���	#FF66798F���	#FF66798F���	#FFEAEAEA$��Cambria Math)�6�   $��14(�6�   �� 5   
   -   5         ��Name$ btnAdd��5      $	��ADD��6!   $
��Left=�6/   $��667,101,0,0q�6J   $	��Top=�6_   $	��133��6w   $��28��6�   ���	#FF21DEB5
�������$��Cambria Math)�6�   $��18(�6�   $
��Bold"�6�   ��6  Z�  J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF686868��6#   5      �� 5   
   -	   5        $ btnEdit��5      $��UPDATE��6"   $
��Left=�63   $��667,142,0,0q�6N   $	��Top=�6c   $	��133��6{   $��28��6�   ���	#FF5C93FB
�������$��Cambria Math)�6�   $
��Bold"�6�   $��18(�6�   ��6  Z�  5        5      $ 	#FF686868��6#   5      �� 5   
   -
   5        $ btnNew��5      $	��NEW��6!   $
��Left=�6/   $��667,183,0,0q�6J   $	��Top=�6_   $	��133��6w   $��28��6�   ���	#FFB87EF8
�������$��Cambria Math)�6�   $
��Bold"�6�   $��18(�6�   ��6  Z�  5         5!      $ 	#FF686868��6#   5#      �� 5$   
   -   5        $ 	BtnDelete��5$      $��DELETE��6$   $
��Left=�65   $��667,223,0,0q�6P   $	��Top=�6e   $	��133��6}   $��28��6�   ���	#FFFC768A
�������$
��Bold"�6�   $��18(�6�   $��Cambria Math)�6�   ��6  Z�  5%        5&      $ 	#FF686868��6#   5(      &   System.Windows.Controls.DataGrid  5)   
   -   5        	  Name$	 lvUsers��5)      
 � ToolTip$
 User details��6$   $��Cambria Math)�6R   $��16(�6l   $
��Bold"�6�   
�������$��Disabled=�6�   $��Stretch=�6  $	��332��6&  $	��Top=�63  $ 0.5,0.5&�6K  $��Right=�6k  $	��741��6�  $��
0,322,55,0q�6�  ��6;   Z�    VerticalGridLinesBrush 6�  Z�    HorizontalGridLinesBrush 6�  Z� ��5*      �� 5+       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5,      �  � Color$ 	#FF877BED��6#    � Offset$ 1Q�65   � 5-      $ 	#FFED89E7��6#   � 5.      $ 	#FFC37FF3��6#   $ 0.527Q�65   5/         Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ UserID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 65      
FontFamily$ Cambria Math)�6\      FontSize$ 14Q�6v      
FontWeight$
 Bold"�6�      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *UserID+6�     53      $
 Name��6%   $	 200 63   $ Cambria Math)�6X   $ 14Q�6r   $
 Bold"�6�    .  6?   �� *Name+6�     54      $ Username��6%   $	 200 67   $ Cambria Math)�6`   $ 14Q�6z   $
 Bold"�6�    .  6C   �� *
Username+6�     55      $
 Type��6%   $	 200 63   $ Cambria Math)�6X   $ 14Q�6r   $
 Bold"�6�    .  6?   �� *Type+6�   57      �� 58   
   -   5        $ txtUsernameUsers_Copy��58      $��	Password:��6/   $
��Left=�6C   $��283,240,0,0q�6^   $	��Top=�6s   $ -0.192,0.097&�6�   $��95��6�   $��
Constantia)�6�   $��14(�6�   $
��Bold"�6�   ���	#FFD4F2E86�   �� 59   
   -   5        $ txtName��59      $
��Left=�6#   $��26��6>   $��401,123,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��216��6�   ���	#FF66798F���	#FF66798F���	#FFEAEAEA$��Cambria Math)�6�   $��14(�6�   �� 5:   
   -   5        $ txtUsernameUsers_Copy1��5:      $��Name:��60   $
��Left=�6@   $��305,122,0,0q�6[   $	��Top=�6p   $ -0.192,0.097&�6�   $��95��6�   $��
Constantia)�6�   $��14(�6�   $
��Bold"�6�   ���	#FFD4F2E86�   �� 5;   
   -   5        $ txtUsernameUsers_Copy2��5;      $��UserID:��60   $
��Left=�6B   $��
297,84,0,0q�6]   $	��Top=�6q   $ -0.192,0.097&�6�   $��95��6�   $��
Constantia)�6�   $��14(�6�   $
��Bold"�6�   ���	#FFD4F2E86�   �� 5<   
   -   5        $ 	txtUserID��5<      $
��Left=�6%   $��25��6@   $��
400,86,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��216��6�   ���	#FF66798F���	#FF66798F���	#FFEAEAEA$��Cambria Math)�6�   $��14(�6�   {�.  6  �� 5=   
   -   5        $ txtPassword��5=      $
��Left=�6'   $��23��6B   $��401,241,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��216��6�   ���	#FF66798F���	#FF66798F���	#FFEAEAEA$��Cambria Math)�6�   $��14(�6�   �� 5>   
   -   5         ��Name$ 
cbUserType��5>      $
��Left=�6'   $��401,161,0,0q�6B   $	��Top=�6W   $	��216��6o   ���	#FFEBEBF3���	#FF66798F$��Cambria Math)�6�   $��14(�6�   $��27��6�    �� SelectedIndex$ 0��6�   $��0q�6  ��6�   Z� .@�5?      �� $��ADMINISTRATOR��6   $��30��64   $��	0,0,0.4,0q�6@   ���	#FF1B5E76$��0q�6�   $
 Select User Type��6�   ��6j   Z� 6�   �� 5@      $��HUMAN RESOURCES��6   $��30��66   $��	0,0,0.4,0q�6B   ���	#FF0D5C79$��0q�6�   ��6l   Z� 6�   �� 5A      $��PAYROLL MASTER��6   $��30��64   $��	0,0,0.4,0q�6@   ���	#FF0D5C79$��0q�6�   ��6j   Z� 6�   �� 5B      $��SUPER ADMIN��6   $��30��61   $��	0,0,0.4,0q�6=   ���	#FF0D5C79$��0q�6~   ��6g   Z� 6~   5C      �� 5D   
   -   5         ��Name$
 date��5D      ���	#FFD4F2E8$��16(�6:   $��40��6H   $
��Bold"�6T   $
��Left=�6f   $��Center=�6�   $	��264��6�   $��19,13,0,632q�6�   �� 6�   $�            ��6�   �� 6�   $�9/26/2019 2:50:36 AM��6�   6�   �� 5E   
   $��Center=�6   $��683,13,12,637q�60   .+�5F      '  !MaterialDesignThemes.Wpf.PopupBox  $��Stretch=�6&   $��111,5,8.8,5q�6D      PlacementMode$ BottomAndAlignRightEdges=�6Y      	StaysOpen .  ���	#FFFCFCFC   PopupContent. 5G      �� $	��150��6   .+�5H      �� -   5        $ btnHome1��5H      $
��Home��6/   ���	#FFD4AF376U   �� 5I      -   5        $ btnAbout��5I      $��About Us��6/   ���	#FFD4AF376Y   �� 5J      -   5        $ 
btnContact��5J      $��
Contact Us��61   ���	#FFD4AF376]   �� 5K      �� 5L      -   5        $ btnHelp��5L      $
��Help��6.   ���	#FFD4AF376T   5N      5O      5P      5Q      5R      