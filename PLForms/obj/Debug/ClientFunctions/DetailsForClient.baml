   M S B A M L   `   `   `  ����=  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE  5   �    Ratatouille   PLForms.DetailsForClient   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   +BEclr-namespace:BE;assembly=BE     6�     � Title$  DetailsForClient��5   	   $	��300��6"   $	��400��6/   .��5      � .+�5   
   � -   5         �Name$ grid1��5      $	��Top=�6   $��	23,40,0,0q�66   $
��Left=�6I   $	��266��6e    � RowDefinitions 5      �� 5	      $
��Auto �6    �� 5
      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��Center=�6   $��0��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Address:��6r   �� 5      $��Center=�6   $��1��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $
��age:��6r   �� 5      $��Center=�6   $��2��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Credit Card Number:��6r   �� 5      $��Center=�6   $��3��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Current Location:��6r   �� 5      $��Center=�6   $��4��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Name:��6r   �� 5      -   5         ��Name$ AdressLabel��5      $��1��6)   $
��Left=�69   $��
10,5,-47,0q�6T   $	��Top=�6h   $	��120��6�   $��27��6�   ��6�   �� *	Address+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   �� 5      -   5        $ AgeLabel��5      $��1��6&   $
��Left=�66   $��
10,5,-51,0q�6Q   $��1��6e   $	��120��6r   ��6~   �� *age+$ TwoWay=� .  . �� 5      -   5        $ CreditCardNumberLabel��5      $��1��63   $
��Left=�6C   $��
10,2,-49,3q�6^   $��2��6r   $	��120��6   ��6�   �� *CreditCardNumber+$ TwoWay=� .  . �� 5      -   5        $ CurrentLocationLabel��5      $��1��62   $
��Left=�6B   $��
10,2,-49,3q�6]   $��3��6q   $	��120��6~   ��6�   �� *CurrentLocation+$ TwoWay=� .  . �� 5      -   5        $ 	NameLabel��5      $��1��6'   $
��Left=�67   $��
10,2,-49,3q�6R   $��4��6f   $	��120��6s   ��6   �� *Name+$ TwoWay=� .  . 5      5!      5"      