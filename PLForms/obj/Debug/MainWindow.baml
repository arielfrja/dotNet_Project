   M S B A M L   `   `   `  ����  Ratatouille    PLForms.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Main Window��5   	   $	��400��6   $	��600��6*   .��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $	��17* �6    � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ LaChefEnter��5      $��1��6&   $��1��66   $��0q�6C    J� IsHitTestVisible . ��5      �� 5      $��Images/La chef.png��6   5      �� 5   
   -   5        $ LaClientEnter��5      $��1��6(    . ��5      �� 5      $��Images/La client.jpg��6   $
��Fill=�66   $	��271��6E   5      �� 5   
   -   5         ��Name$ 
StaffLabel��5      $��Staff��6$   $��1��64   $��36(�6D   $��Center=�6R   $��Center=�6o   $	��300��6�   $��60��6�   
���   �$��French Script MT)�6�   $
��Bold"�6�   
���   �$��5q�6  ��5      �� 5       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5      � 	 � Color$	 #964B00��6#   
 � Offset$
 0.092Q�63   � 5       $	 #E5AA70��6#   $
 0.544Q�63   5!      5#      �� 5$   
   -   5        $ ClientLabel��5$      $��Client��6%   $��Center=�66   $��36(�6S   $	��300��6a   $��Center=�6m   $��60��6�   $
��Bold"�6�   $��French Script MT)�6�   $��5q�6�   
���   ���5%      �� 5&      $ 0.5,1&�6&   $ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5'      � $	 #964B00��6#   $
 0.092Q�63   � 5(      $	 #E5AA70��6#   $
 0.544Q�63   5)      5,      5.      5/      