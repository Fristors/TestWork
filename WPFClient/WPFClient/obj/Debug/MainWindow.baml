   M S B A M L   `   `   `  ����D  @WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPFClient	WPFClient  5   	       WPFClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WPFClient     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��Center=�6I   .+�5      �� $��Событие��6   �� 5      -   5         ��Name$ EventCB��5      $	��100��6(   64   5      �� 5   
   -   5         ��Name$	 Btn��5      $��0��6   $��
Старт��6+   $��Center=�6;   $��Center=�6X   $	��5 0q�6s   $��16(�6�   $��Times New Roman)�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ GridList��5      "   VerticalScrollBarVisibility$
 Auto=�5         AutoGenerateColumns .  $
��Left=�5      $��10(�5         
IsReadOnly . $��5q�5      $��1��5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 35 5         Header$ X��5       1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      �� *XPos+5         5!      $
 * 5"      $ Y��5$       5#      �� *YPos+5$        5%      $
 * 5&      $ Тип��5(       5'      �� *	TypeEvent+5(        5)      $
 * 5*      $ 
Время��5,       5+      �� *
DateTime+5,      5.      5/      50      