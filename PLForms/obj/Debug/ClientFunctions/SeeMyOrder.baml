   M S B A M L   `   `   `  ����=  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE  5      F BRatatouille, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PLFormsPLForms 5      )   #PLForms.ClientFunctions.SeeMyOrders   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +BEclr-namespace:BE;assembly=BE     5      'localclr-namespace:PLForms     5      $	��500��5      $	��792��6,     � 	Resources  5	      " PLForms.Client_To_ClientName   Client_To_ClientName  Button_Style �� 
TargetType �� Triggers �� Binding �� ElementName �� Path �� Value �� Property �� Value��%�   &	        &	        5
   
   6%   �� 5   
   " ��6%    5      �� 5       6   �� $! detailsForTheClientDataGrid��$ SelectedIndex� -16n   .a�5      ��  � {� .  62   5      5      5      ��5      �� 5   
   	 �� ImageSource$;	 5/Ratatouille;component/Images/MakeOrderBackground.jpg��6   .��5      � $	��505��6   $	��792��6   
 � RowDefinitions
 5   
   �� 5      $	��67* �6   �� 5      $
��233* �6   .+�5   
   �� $)��#Enter your Credit card number here:��6   $
��Left=�6>   $��
303,27,0,0q�6Y   $	��Top=�6m    J� RenderTransformOrigin$ 0.855,0.865&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$! detailsForTheClientDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��140,10,139,178q�6t   $��1��6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ��6�   ��    Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      -   5        orderNumberColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Order Number��5!   \      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.9* 6r      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *	orderID+6     5"      -   5        Branch_Number��$ Branch Number��5"   ]   $
 0.9* 6t    6<   �� *BranchNumber+6t     5#      -   5        kashrutLevel��$ Kashrut��5#   \   $
 0.6* 6m    6;   �� *kashrutLevel+6m     5$      -   5        
ClientName��$ Client Name��5$   �   $
 0.8* 6�    69   �� *client+ �� 	Converter# [  6�     5%      -   5        oSColumn��$ OS��5%   N   $
 0.6* 6Z    67   �� *OS+6Z     5&      -   5        date��$
 Date��5&   L   $
 0.8* 6Z    63   �� *date+6Z   5(      �� 5)   
   -   5         ��Name$! SelectedCreditCard_ComboBox��5)      $
��Left=�68   $��
303,58,0,0q�6S   $	��Top=�6g   $	��200��6   ��6�   �� 6�   �� 5*   
   -	   5        $��Details of client��5*      $��Center=�6-   $��352,264,352,106q�6J   $��1��6c   $��Center=�6p   $��88��6�   #��[ 6�   6�   �� 5+   
   -
   5        $��Dishes of order ��5+      $
��Left=�6,   $��140,264,0,0q�6G   $��1��6\   $	��Top=�6i   $��88��6�   $ 
-3.319,3.1&�6�   #��[ 6�   6�   �� 5,   
   -   5        $��Cancel order��5,      $
��Left=�6(   $��565,264,0,0q�6C   $��1��6X   $	��Top=�6e   $��88��6}   #��[ 6�   6�   �� 5-   
   -   5         ��Name$ Refresh��5-      $�� ��6"   $
��Left=�6-   $��375,309,0,0q�6H   $	��Top=�6]   $��50��6u   $��32��6�   #��[ 6�   $��1��6�   ��5.      �� 5/      $/	 )/Ratatouille;component/Images/Refresh.png��6   51      55      56      