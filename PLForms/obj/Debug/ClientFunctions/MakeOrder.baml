   M S B A M L   `   `   `  ����=  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE  5      = 9BL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BL;assembly=BLBL 5      F BRatatouille, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PLFormsPLForms 5      '   !PLForms.ClientFunctions.MakeOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +BEclr-namespace:BE;assembly=BE     5      +BLclr-namespace:BL;assembly=BL     5      'localclr-namespace:PLForms     5      $��791.597��5	      $	��484��6/     � 	Resources  5
      $ PLForms.DishNumber_To_DishName   DishNumber_To_DishName% PLForms.DishNumber_To_DishPrice  DishNumber_To_DishPrice$ PLForms.DishNumber_To_DishSize  DishNumber_To_DishSize( "PLForms.DishNumber_To_KashrutLevel  DishNumber_To_KashrutLevel* $PLForms.DishNumber_To_PrepairingTime   DishNumber_To_PrepairingTime��%�   &	        &	      &	 &     &	 9     &	 L       5   
   6'     5   
   6(     5   
   6'     5   
   6+     5   
   6-   5      ��5      �� 5   
    �� ImageSource$; 5/Ratatouille;component/Images/MakeOrderBackground.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $	��27* �6   �� 5      $	��73* �6   .+�5   
   � -   5         �Name$ ClientDetails��5      .+�5      � -   5        $ 
ClientName��5      $
��Left=�6'   $��	40,10,0,0q�6B   $	��Top=�6U   $	��187��6m   $��35��6y    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $
��Auto �6'    5      �� 5       $
��Auto �6$   .+�5"      �� $��Name:��6   $��0��6(   $
��Left=�68   $��3q�6S   $��0��6^   $��Center=�6k   �� 5#      -   5         ��Name$ nameTextBox��5#      $��1��6/   $
��Left=�6?   $��23��6Z   $��Center=�6g   $	��120��6�   ��6�   �� *Name+5$      � 5%      -   5        $ 	ClientAge��5%      $
��Left=�6&   $��
250,10,0,0q�6A   $	��Top=�6U    5&      �� 5'      $
��Auto �6'   �� 5(      $
��Auto �6'    5*      �� 5+      $
��Auto �6$   .+�5-      �� $
��age:��6   $��0��6'   $
��Left=�67   $��3q�6R   $��0��6]   $��Center=�6j   �� 5.      -   5        $ 
ageTextBox��5.      $��1��6.   $
��Left=�6>   $��23��6Y   $��3q�6e   $��0��6p   $��Center=�6�   $	��120��6�   ��6}   �� *age+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   5/      � 50      -   5        $ ClientAddress��50      $
��Left=�6*   $��	40,50,0,0q�6E   $	��Top=�6X    51      �� 52      $
��Auto �6'   �� 53      $
��Auto �6'    55      �� 56      $
��Auto �6$   .+�58      �� $��Address:��6   $��0��6+   $
��Left=�6;   $��3q�6V   $��0��6a   $��Center=�6n   
�������6�   �� 59      -   5        $ addressTextBox��59      $��1��62   $
��Left=�6B   $��23��6]   $��3q�6i   $��0��6t   $��Center=�6�   $	��120��6�   ��6�   �� *	Address+$ TwoWay=� .  . 6�   5:      � 5;      -   5        $ ClientCurrentLocation��5;      $
��Left=�62   $��
250,50,0,0q�6M   $	��Top=�6a    5<      �� 5=      $
��Auto �6'   �� 5>      $
��Auto �6'    5@      �� 5A      $
��Auto �6$   .+�5C      �� $��Current Location:��6   $��0��64   $
��Left=�6D   $��3q�6_   $��0��6j   $��Center=�6w   ���	#FF8B8B8B6�   �� 5D      -	   5        $ currentLocationTextBox��5D      $��1��6:   $
��Left=�6J   $��23��6e   $��3q�6q   $��0��6|   $��Center=�6�   $	��120��6  ��6�   �� *CurrentLocation+$ TwoWay=� .  . 6  5E      � 5F      -
   5        $ ClientCreditCard��5F      $
��Left=�6-   $��	40,90,0,0q�6H   $	��Top=�6[    5G      �� 5H      $
��Auto �6'   �� 5I      $
��Auto �6'    5K      �� 5L      $
��Auto �6$   .+�5N      �� $��Credit Card Number:��6   $��0��66   $
��Left=�6F   $��3q�6a   $��0��6l   $��Center=�6y   ���	#FF8B8B8B6�   �� 5O      -   5        $ creditCardNumberTextBox��5O      $��1��6;   $
��Left=�6K   $��23��6f   $��3q�6r   $��0��6}   $��Center=�6�   $	��120��6  ��6�   �� *CreditCardNumber+$ TwoWay=� .  . 6  5P      �� 5Q      -   5        	 ��Name$	 ClientDetailsAdding��5Q      $��Use this client's detail��62   $
��Left=�6U   $��
350,95,0,0q�6p   $	��Top=�6�   $
��auto��6�   ��5R      �� 5S      
 �� Triggers
 5T      �� 5U       �� Binding 6*   ��  �� ElementName$ nameTextBox�� �� Path$
 Text� �� Value  6a   .a�5V   "   ��  �� Property � {� �� Value .  6E   5W      �� 5X       6*   �� $ 
ageTextBox��$
 Text�  6`   .a�5Y   "   ��  � {� .  6E   5Z      �� 5[       6*   �� $ addressTextBox��$
 Text�  6d   .a�5\   "   ��  � {� .  6E   5]      �� 5^       6*   �� $ currentLocationTextBox��$
 Text�  6l   .a�5_   "   ��  � {� .  6E   5`      �� 5a       6*   �� $ creditCardNumberTextBox��$
 Text�  6m   .a�5b   "   ��  � {� .  6E   5c      5e      5g      � 5h      -   5        $ grid1��5h      $
��Left=�6"   $��488,10,-3,0q�6=   $	��Top=�6R   $
��auto��6j    5i      �� 5j      $
��Auto �6$   �� 5k      $
��Auto �6$   .+�5m      �� $��Kashrut Level:��6   $��0��61   $
��Left=�6A   $��3q�6\   $��0��6g   $��Center=�6t   �� 5n      -   5         ��Name$ kashrutLevelComboBox��5n      $��1��69   $��Center=�6F   $
��Auto��6c   $��Center=�6q   $	��120��6�   {�.  6�   5o      �� 5p      -   5        $	 KashrutAdding��5p      $��Use this kashrut��6,   $
��Left=�6G   $��
488,79,0,0q�6b   $	��Top=�6v   $	��120��6�   {�.  6�   5q      � 5r   
   -   5        $ OrderDetailes��5r      $��1��6&    5s      �� 5t      $��* �6    �� 5u      $��* �6    .+�5w      &   System.Windows.Controls.DataGrid  -   5          Name$ 
DishesMenu��5w         AutoGenerateColumns .     EnableRowVirtualization .    RowDetailsVisibilityMode$ VisibleWhenSelected=�6~    �� IsTextSearchEnabled .    
IsReadOnly . $��	0,0,428,0q�6�   {�.  ���	#FFF0F0F0��6f   ��    Columns 5x      0  *System.Windows.Controls.DataGridTextColumn  5y      -   5        dishNameColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 	Dish Name��5y   ^      Width5	  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader	 6q   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6A   �� *
DishName+6q     5z      -   5        dishPriceColumn��$ 
Dish Price��5z   `   $ SizeToHeader	 6t    6B   �� *	DishPrice+6t     5{      -   5        dishSizeColumn��$ 	Dish Size��5{   ^   $ SizeToHeader	 6q    6A   �� *
DishSize+6q     5|      -   5        kashrutLevelColumn��$ Kashrut Level��5|   f   $ SizeToHeader	 6}    6E   �� *KashrutLevel+6}     5}      -   5        preparingTimeColumn��$ Preparing Time��5}   h   $ SizeToHeader	 6�    6F   �� *PreparingTime+6�   5      �� 5�      -   5        $	 AddDishesButton��5�      $
��Left=�6.   $��
369,96,0,0q�6I   $	��Top=�6]   $��75��6u   $��75��6�   {�.  .��5�      �� {�.  $��Center=�6.   $��Center=�6I   �� 6h   $	�add��6l   �� 6y   �� 6�   $
�this��6�   �� 6�   �� 6�   $
�dish��6�   �� 6�   �� 6�   $�to order��6�    �� TextAlignment$ Center=�6�   6�   5�      �� 5�      -   5        $ AmountTextBox��5�      $
��Left=�6-   $��23��6H   $��
369,26,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $��75��6�   {�.  6�   �� 5�      -   5         ��Name$ Amount��5�      $��Amount��6$   $
��Left=�65   $��	369,0,0,0q�6P   $	��Top=�6c   $��75��6{   $��Center=�6�   �� 5�      -   5        $ 	PriceShow��5�      $��0 ₪��6'   $
��Left=�65   $��
412,65,0,0q�6P   $	��Top=�6d   
���   �
�������$��51��6�   $��Center=�6�   $��Center=�6�   {�.  6�   �� 5�      -   5        $ Price��5�      $��Price:��6#   $
��Left=�64   $��
369,65,0,0q�6O   $	��Top=�6c   $��Center=�6{   �� 5�      -   5        $ TotalPriceShow��5�      $��0 ₪��6,   $
��Left=�6:   $��504,106,0,0q�6U   $	��Top=�6j   
���   �
�������$��68��6�   $��1��6�    J� RenderTransformOrigin$ 0.471,2&�6�   $��Center=�6�   $��Center=�6  �� 5�      -   5        $ 
Totalprice��5�      $��Total Price:��6(   $
��Left=�6?   $��
504,73,0,0q�6Z   $	��Top=�6n   $��1��6�   $��Center=�6�   �� 5�      -   5        $	 
RemoveDish��5�      $
��Left=�6)   $��
412,40,0,0q�6D   $	��Top=�6X   $��75��6p   $��86��6{   $��1��6�   {�.  .��5�      �� $��18(�6   {�.  $��Center=�6<     �� TextAlignment$  Center=�6Y   �� 6r   $�Remove��6v   �� 6�   �� 6�   $
�this��6�   �� 6�   �� 6�   $
�dish��6�   6�   5�        5�      -   5        $ OrderedDishes��5�       .   . $��1��6�   $ VisibleWhenSelected=�6�   ���	#FF688CAF . $��	0,0,385,0q�6�   {�.  ��6i   ��  5�        5�      -    5        dishNameColumn1��$ 	Dish Name��5�   �   $ SizeToHeader	 6�    6B   �� *
DishNumber+! �� 	Converter#! [  6�     5�      -!   5        dishPriceColumn1��$ 
Dish Price��5�   �   $ SizeToHeader	 6�    6C   �� *
DishNumber+#! [ 6�     5�      -"   5        dishSizeColumn1��$ 	Dish Size��5�   �   $ SizeToHeader	 6�    6B   �� *
DishNumber+#! [ 6�     5�      -#   5        kashrutLevelColumn1��$ Kashrut Level��5�   �   $ SizeToHeader	 6�    6F   �� *
DishNumber+#! [ 6�     5�      -$   5        preparingTimeColumn1��$ Preparing Time��5�   �   $ SizeToHeader	 6�    6G   �� *
DishNumber+#! [ 6�     5�      -%   5        amountColumn1��$ Amount��5�   @   $ SizeToHeader	 6u    6P   �� *AmountSameDishes+6u   5�        5�      -&   5        $ Branches��5�       .   . $ VisibleWhenSelected=�6|   $��	472,0,0,0q�6�   {�.   . ��6d   ��  5�        5�      -'   5        addressColumn��$ Address��5�   \   $ SizeToHeader	 6m    6@   �� *	Address+6m     5�      -(   5        kashrutLevelColumn2��$ Kashrut Level��5�   g   $ SizeToHeader	 6~    6F   �� *KashrutLevel+6~     5�      -)   5        
nameColumn��$
 Name��5�   V   $ SizeToHeader	 6d    6=   �� *Name+6d     5�      -*   5        numberColumn��$ Number��5�   Z   $ SizeToHeader	 6j    6?   �� *Number+6j     5�      -+   5        phoneNumberColumn��$ Phone Number��5�   d   $ SizeToHeader	 6z    6D   �� *PhoneNumber+6z   5�      �� 5�      -,   5        $	 OrderButton��5�      $��Order!��6*   $
��Left=�6;   $	��Top=�6V   $	��163��6n   $��76��6z   $��1��6�   $��52(�6�   $��French Script MT)�6�   $��
619,91,0,0q�6�   {�.  6�   �� 5�      --   5        $	 ContinueToBranch��5�      $ ��Continue to brach selecton��6/   $
��Left=�6T   $��412,137,0,0q�6o   $��1��6�   $	��Top=�6�   $	��180��6�   $��33��6�   $��14(�6�   {�.  6�   5�      5�      5�      