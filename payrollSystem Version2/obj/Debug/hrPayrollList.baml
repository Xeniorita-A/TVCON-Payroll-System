   M S B A M L   `   `   `  ����Q  MpayrollSystem Version2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:payrollSystem_Version2payrollSystem_Version2  5   	   *    $payrollSystem_Version2.hrPayrollList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:payrollSystem_Version2     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  PAYROLL��5	      $��750.0��6   $��1200.0��6'    � WindowStartupLocation$ CenterScreen=�66   .��5
      � ���	#FF374057$��-1,-6,-0.8,0.6q�6"   .+�5   
   �� $
��Left=�6   $��42��60   $��1073,109,0,0q�6<   $	��Top=�6R   $��47��6j    J� RenderTransformOrigin$ 1.093,0.542&�6u   .+�5      �� $��resources/search.png��6   $��
-3,0,0.6,0q�62   $��38��6F   5      �� 5   
   -   5         ��Name$ label1_Copy3��5      $��Search:��6&   $
��Left=�68   $��25��6S   $��745,119,0,0q�6_   $	��Top=�6t   $��66��6�   $��14(�6�   $��Cambria Math)�6�   ���	#FFD4F2E86�   �� 5   
   -   5         ��Name$ 	txtSearch��5      $
��Left=�6%   $��32��6@   $��816,114,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��254��6�   $ 0.412,-0.03&�6�   ���	#FF76798A
�������$��Cambria Math)�6  $��16(�6%  �� 5   
   -   5         ��Name$
 date��5      ���	#FFD4F2E8$��16(�6:   $��40��6H   $
��Bold"�6T   $
��Left=�6f   $��Center=�6�   $	��264��6�   $��13,16,0,670.2q�6�   $ 0.502,0.479&�6�   �� 6�   $�            ��6�   �� 6�   $�9/26/2019 2:50:36 AM��6  6"  �� 5   
   $��Center=�6   $��973,21,18.4,670.2q�60   .+�5      '  !MaterialDesignThemes.Wpf.PopupBox  $��Stretch=�6&   $��111,5,8.6,5q�6D      PlacementMode$ BottomAndAlignRightEdges=�6Y      	StaysOpen .  ���	#FFFCFCFC	   PopupContent.	 5      �� $	��150��6   .+�5      �� -   5        
 ��Name$
 btnHome1��5      $
��Home��6/   ���	#FFD4AF376U   �� 5      -   5        $
 btnAbout��5      $��About Us��6/   ���	#FFD4AF376Y   �� 5      -   5        $
 
btnContact��5      $��
Contact Us��61   ���	#FFD4AF376]   �� 5      �� 5      -   5        $
 btnHelp��5      $
��Help��6.   ���	#FFD4AF376T   5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	lvPayroll��5      $��0,0,57.4,61.2q�6&   ���	#FFFCFCF8$��Cambria Math)�6k   $��Normal"�6�   $��Disabled=�5      $��Stretch=�6O    � ToolTip$ Payroll of Employees��6t   $	��482��6�   $��Bottom=�6�   $ 0.5,0.5&�6�   $��Right=�6�   $
��1079��6�   $��14(�6J   � IsSharedSizeScope . $   HorizontalScrollBarVisibility$ Visible=�6v  ��5   =   Z�    VerticalGridLinesBrush 5     Z�    HorizontalGridLinesBrush 6&  Z� ��5      �� 5        �� EndPoint$ 0.5,0&�6&    �� 
StartPoint$ 0.5,1&�67   .��5!      �  � Color$ 	#FF40E6B8��6#    � Offset$ 0Q�65   � 5"      $ 	#FF1AD4BC��6#   $ 0.109Q�65   � 5#      $ 	#FF16C8C9��6#   $ 0.297Q�65   � 5$      $ 	#FF2FB1C6��6#   $ 1Q�65   5%         Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ Date Issued��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 110 6Z      
FontFamily$ Cambria Math)�6f      FontSize$ 14Q�6�      
FontWeight$
 Bold"�6�      
IsReadOnly .    CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
DateIssued+6�     5)      $ Employee ID��6%   $	 100 6R   $ Cambria Math)�6^   $ 14Q�6x   $
 Bold"�6�    .  .   6:   �� *EID+6�     5*      $ no. of Days��6%   $	 100 6W   $ Cambria Math)�6c   $ 14Q�6}   $
 Bold"�6�    .  .   6:   �� *
Num_days+6�     5+      $ Days on Leave��6%   $	 110 6V   $ Cambria Math)�6b   $ 14Q�6|   $
 Bold"�6�    .  .   6<   �� *Leave+6�     5,      $ 	Rate Wage��6%   $	 130 6U   $ Cambria Math)�6a   $ 14Q�6{   $
 Bold"�6�    .  .   68   �� *
RateWage+6�     5-      $ OT hours��6%   $	 100 6S   $ Cambria Math)�6_   $ 14Q�6y   $
 Bold"�6�    .  .   67   �� *	OThours+6�     5.      $ Overtime Pay��6%   $	 120 6X   $ Cambria Math)�6d   $ 14Q�6~   $
 Bold"�6�    .  .   6;   �� *
Overtime+6�     5/      $ Night Differential��6%   $	 135 6g   $ Cambria Math)�6s   $ 14Q�6�   $
 Bold"�6�    .  .   6A   �� *NightDifferential+6�     50      $ 
Philhealth��6%   $	 120 6X   $ Cambria Math)�6d   $ 14Q�6~   $
 Bold"�6�    .    
Foreground �	#FFF6ECEC .   69   �� *
Philhealth+6�     51      $ Holliday Pay��6%   $	 125 6W   $ Cambria Math)�6c   $ 14Q�6}   $
 Bold"�6�    .  .   6;   �� *	HollPay+6�     52      $ 	Basic Pay��6%   $	 120 6V   $ Cambria Math)�6b   $ 14Q�6|   $
 Bold"�6�    .  .   68   �� *	Basic_Pay+6�     53      $ Cash Advance��6%   $	 120 6W   $ Cambria Math)�6c   $ 14Q�6}   $
 Bold"�6�    .  .   6;   �� *	Cash_ad+6�     54      $ 
Philhealth��6%   $	 120 6X   $ Cambria Math)�6d   $ 14Q�6~   $
 Bold"�6�    �	#FFF6ECEC .   69   �� *
Philhealth+6�     55      $ Withholding Tax��6%   $	 130 6a   $ Cambria Math)�6m   $ 14Q�6�   $
 Bold"�6�    .  .   6>   �� *WithholdingTax+6�     56      $	 SSS��6%   $	 120 6J   $ Cambria Math)�6V   $ 14Q�6p   $
 Bold"�6~    .  .   62   �� *SSS+6�     57      $ Pag-ibig��6%   $	 120 6S   $ Cambria Math)�6_   $ 14Q�6y   $
 Bold"�6�    .  .   67   �� *	Pagibig+6�     58      $ Other Deduction1��6%   $	 120 6V   $ Cambria Math)�6b   $ 14Q�6|   $
 Bold"�6�    .  .   6?   �� *d1+6�     59      $ Amount��6%   $	 100 6M   $ Cambria Math)�6Y   $ 14Q�6s   $
 Bold"�6�    .  .   65   �� *da1+6�     5:      $ Other Deduction2��6%   $	 120 6V   $ Cambria Math)�6b   $ 14Q�6|   $
 Bold"�6�    .  .   6?   �� *d2+6�     5;      $ Amount��6%   $	 100 6M   $ Cambria Math)�6Y   $ 14Q�6s   $
 Bold"�6�    .  .   65   �� *da2+6�     5<      $ Other Deduction3��6%   $	 120 6V   $ Cambria Math)�6b   $ 14Q�6|   $
 Bold"�6�    .  .   6?   �� *d3+6�     5=      $ Amount��6%   $	 100 6M   $ Cambria Math)�6Y   $ 14Q�6s   $
 Bold"�6�    .  .   65   �� *da3+6�     5>      $ Total Deduction��6%   $	 120 6Y   $ Cambria Math)�6e   $ 14Q�6   $
 Bold"�6�    .  .   6>   �� *totald+6�     5?      $ 
Net Income��6%   $	 120 6X   $ Cambria Math)�6d   $ 14Q�6~   $
 Bold"�6�   
 ����� .   69   �� *
Net_income+6�     5@      $ Pay Day��6%   $	 110 6Q   $ Cambria Math)�6]   $ 14Q�6w   $
 Bold"�6�    .  .   66   �� *PayDay+6�   5B      �� 5C   
   -	   5        $ label��5C      $��P��6   $
��Left=�6+   $��	61,32,0,0q�6F   $	��Top=�6Y   $	��135��6q   $��71��6~   $��Javanese Text)�6�   $
��Bold"�6�   $��90(�6�   ���	#FFD4AF376�   �� 5D   
   -
   5        $ label1��5D      $��ayroll��6    $
��Left=�61   $��116,102,0,0q�6L   $	��Top=�6a   $��69��6y   $	��135��6�   ���	#FFD4AF37$��Cambria Math)�6�   $��50(�6�   �� 5E   
   -   5        $ label1_Copy��5E      $
��List��6%   $
��Left=�64   $��
244,95,0,0q�6O   $	��Top=�6c   $��73��6{   $	��122��6�   ���	#FFF6F5F3$��Cambria Math)�6�   $��60(�6�   5G      5H      