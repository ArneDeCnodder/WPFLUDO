   M S B A M L   `   `   `  ����F  BProjectMEJN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMEJN.ViewsProjectMEJN.Views  5   	       ProjectMEJN.Views.Spelers   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ProjectMEJN.Views     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�6.    � Title$ Spelers��5
   	   $	��600��6   $	��700��6&    � DataContext 5   	   ��    ViewModelLocator �� Source# [   �� Path$ SpelersViewModel���5      
� 5   
   .��5      �  � Color$ 	#FF6D000E��6    � Offset$	 1.1Q�6-   � 5      $ #EC808D��6   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   ��  	 Titel#��[ 6   $��0��63   $��Center=�6@   $	��Top=�6]   $��Spelers��6u   6�   � 5   
   $��1��6   	 � ColumnDefinitions	 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5!      �� $��0��6   
 �� SelectionMode$
 Single=�5#      $	��300��5%      $	��320��6    $��
Montserrat)�6,   $��15(�6D   
���   �#��� ��6e   ��5"      �� *	Spelers+ �� SelectedItem 5$      �� *HuidigeSpeler+ �� View 5&      �� 5'      .P�5(      ��  �� Width$	 100��6)   $��Voornaam��5)   %    �� DisplayMemberBinding 5*   %   �� *
Voornaam+�� 5+      $	 100��6)   $��Familienaam��5,   %    5-   %   �� *Familienaam+5/      51      �� 53      $��1��6   $��Center=�6)   .+�54      �� $��Voornaam��6   $
��30,0q�6,   $��15(�6:   
�������$��
Montserrat)�6[   6u   �� 55      $��30,10q�6   $��10q�6)   $��
Montserrat)�66   ��56      �� *HuidigeSpeler.Voornaam+�� 57      $��Familienaam��6   $
��30,0q�6/   $��
Montserrat)�6>   $��15(�6V   
�������6y   �� 58      $��30,10q�6   $��10q�6*   $��
Montserrat)�67   ��59      �� *HuidigeSpeler.Familienaam+�� 5;        ButtonStyle#��[ 6   $��Wijzigen��5<      ��5=      �� *WijzigenCommand+�� 5>      #��[ 6   $��Verwijderen��6?   ��5?      �� *VerwijderenCommand+�� 5@      #��[ 6   $��	Toevoegen��6?   ��5A      �� *ToevoegenCommand+5B      5D      �� 5E   
   #��[ 6   $��2��66   $
��HOME��6C   ��6R   �� *BackHomeCommand+6x   5F      5G      