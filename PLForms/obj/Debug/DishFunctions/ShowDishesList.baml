   M S B A M L   `   `   `  ����  Ratatouille*    $PLForms.DishFunctions.ShowDishesList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $
��show��5
      $��Stretch=�6   $	��Top=�6=   $	��449��6U       AutoGenerateColumns  .  $��
99,-5,10,0q�5   1      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        ID��,  &System.Windows.Controls.DataGridColumn   Header$ Id��5   L      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *DishID+6X     5      -   5        Name��$
 Name��5   R   $ * 6`    64   �� *
DishName+6`     5      -   5        	Price��$ Price��5   R   $ * 6a    64   �� *	DishPrice+6a     5      -   5        Size��$
 Size��5   P   $ * 6^    63   �� *
DishSize+6^     5      -   5        PreparingTime��$ PreparingTime��5   ^   $ * 6u    6<   �� *PreparingTime+6u     5      -   5        Kashrut��$ Kashrut��5   W   $
 0.8* 6h    66   �� *KashrutLevel+6h     5      -   5        	Situation��$ 	Situation��5   O   $
 0.6* 6b    68   �� *BS+6b   5      �� 5   
   .+�5      	� -	   5         	�Name$ 
All_Dishes��5      $��
All Dishes��6.    d� 	IsChecked$
 TrueY�6C   
�������6r   	� 5      -
   5        $ Exist_Dishes��5      $��Exist Dishes��60   
�������6f   	� 5      -   5        $ Close_Dishes��5      $��Close Dishes��60   
�������6f   5      5      5      