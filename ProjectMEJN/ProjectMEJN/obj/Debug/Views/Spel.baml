   M S B A M L   `   `   `  ����F  BProjectMEJN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMEJN.ViewsProjectMEJN.Views  5   	       ProjectMEJN.Views.Spel   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ProjectMEJN.Views     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�6.    � Title$
 Spel��5
   	   $	��600��6   $	��700��6$    � DataContext 5   	   ��    ViewModelLocator �� Source# [   �� Path$ SpelViewModel���5      
� 5   
   .��5      �  � Color$ 	#FF6D000E��6    � Offset$	 1.1Q�6-   � 5      $ #EC808D��6   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   ��  	 Titel#��[ 6   $��0��63   $��Center=�6@   $	��Top=�6]   $��Historiek van de spellen��6u   6�   � 5   
   $��1��6   	 � ColumnDefinitions	 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5"      �� -   5        
 ��Name$
 ListViewSpel��5#      $��0��5"       �� SelectionMode$ Single=�5%      $	��300��5'      $	��320��6    $��
Montserrat)�6,   $��15(�6D   
���   �#��� ��6e   ��5$      �� *	Spellen+ �� SelectedItem 5&      �� *
HuidigSpel+ �� View 5(      �� 5)      .P�5*      ��  �� Width$
 auto��6)   $��	Naam Spel��5+   %    �� DisplayMemberBinding 5,   %   �� *Naam+�� 5-      $
 auto��6)   $��Datum van het spel��5.   %    5/   %   �� *Datum+51      53      �� 55      $��1��6   $��Center=�6)   .+�56      �� $��Naam van het spel��6   $
��30,0q�65   $��15(�6C   
�������$��
Montserrat)�6d   6~   �� 57      $��30,10q�6   $��10q�6)   $��
Montserrat)�66   ��58      �� *HuidigSpel.Naam+�� 59      $��Datum��6   $
��30,0q�6)   $��
Montserrat)�68   $��15(�6P   
�������6s   (  "System.Windows.Controls.DatePicker  5;      $��30,10q�6   $��
Montserrat)�6,      SelectedDate 6D   �� *HuidigSpel.Datum+6p   �� 5=        ButtonStyle#��[ 6   $��Wijzigen��5>      ��5?      �� *WijzigenCommand+�� 5@      #��[ 6   $��Verwijderen��6?   ��5A      �� *VerwijderenCommand+�� 5B      #��[ 6   $��	Toevoegen��6?   ��5C      �� *ToevoegenCommand+5D      5F      �� 5G   
   #��[ 6   $��2��6   $��SPEEL��6�   {�66   ��  �� ElementName$ ListViewSpel��$ SelectedItems.Count���6�   �� *VoegToeSpelers+6�   5H      5I      