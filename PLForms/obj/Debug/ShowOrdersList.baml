   M S B A M L   `   `   `  ����F  BRatatouille, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PLFormsPLForms  5          PLForms.ShowOrdersList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:PLForms     5        � 	Resources  5	      (  "PLForms.BranchNumber_To_BranchName   BranchNumber_To_BranchName"  PLForms.Client_To_ClientName  Client_To_ClientName  PLForms.OrderId_To_Profit  OrderId_To_Profit%  PLForms.Client_To_ClientAddress  Client_To_ClientAddress(  "PLForms.Client_To_ClientCreditCard  Client_To_ClientCreditCard��%�   &	        &	      &	 &     &	 9     &	 L       5
   
   6,     5   
   6&     5   
   6#     5   
   6(     5   
   6+   5      .��5      � .+�5   
   � .+�5      &   System.Windows.Controls.DataGrid  -   5        $
��show��5      $��Stretch=�6#   $	��Top=�6A   $	��449��6Y      AutoGenerateColumns .  $��
99,-5,10,0q�5   1      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        ID��,  &System.Windows.Controls.DataGridColumn   Header$ Id��5   Q      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6]   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 65   �� *	orderID+6]     5      -   5        
BranchName��$ Branch Name��5   �   $ *	 6�    6>   �� *BranchNumber+ �� 	Converter# [  6�     5      -   5        Address��$ Address order��5   �   $ *	 6�    6:   �� *client+# [ 6�     5      -   5        Name��$ Client Name��5   �   $
 0.8*	 6�    67   �� *client+# [ 6�     5      -   5        
CreditCard��$ Client credit card��5   �   $
 0.8*	 6�    6=   �� *client+# [ 6�     5      -   5        	Situation��$ 	Situation��5   S   $
 0.6*	 6f    6<   �� *OS+6f     5      -   5        Date��$ 
Order Date��5   P   $ *	 6d    67   �� *date+6d     5      -	   5        
Profit��$ Profit��5   �   $
 0.6*	 6�    69   �� *	orderID+# [ 6�   5      �� 5       .+�5!      	� -
   5         	�Name$ 
All_Orders��5!      $��
All Orders��62    d� 	IsChecked$
 TrueY�6G   
�������
�������6�   	� 5"      -   5        $ Ordered_Orders��5"      $��Ordered Orders��66   
�������
�������6v   	� 5#      -   5        $ Sent_Orders��5#      $��Sent Orders��63   
�������
�������6o   	� 5$      -   5        $ Cancel_Order��5$      $��Cancel Orders��64   
�������
�������6r   5%      5(      5*      5+      