   M S B A M L   `   `   `  ����F  BProjectMEJN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMEJN.ViewsProjectMEJN.Views  5   	   &     ProjectMEJN.Views.SpelSpelerPion   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ProjectMEJN.Views     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�6.    � Title$ SpelSpelerPion��5
   	   $	��550��6    $	��800��6-    � DataContext 5   	   ��    ViewModelLocator �� Source# [   �� Path$ SpelSpelerPionViewModel���5      
� 5   
   .��5      �  � Color$ 	#FF6D000E��6    � Offset$	 1.1Q�6-   � 5      $ #EC808D��6   5      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   	 � RowDefinitions	 5   
   �� 5      $��* �6   6)   �� 5      $��2* �6   6*   �� 5      $��* �6   6)   .+�5    
   �� $��0��6   $��2��6"   $��Center=�67   $	��Top=�6T   .+�5!      ��  	 Titel#��[ 6   
 �� Padding$
 0q�68   $%��Selecteer spelers voor het spel��6D   6m   �� 5"      -   5        $��button��5"        ButtonStyle#��[ 6#   $	��110��6H   $��15(�6T   $	��Top=�6c   $��REFRESH��5#      ��5"   {   �� *RefreshCommand+5#      5$      �� 5'   
   $��0��6   $��1��6    $��30 0 0 0q�6-   
�������.��6R   Overzicht van alle spelers:6o   �� 5(   
   -   5         ��Name$ 	listView1��5(   0   $��0��6   $��1��6#   $��30q�6C    �� SelectionMode$ Single=�5*      $��
Montserrat)�5,      $��15(�6+   
���   �#��� ��6L   ��5)      �� *	Spelers+ �� SelectedItem 5+      �� *HuidigeSpelspeler+ �� View 5-      �� 5.      .P�5/      ��  �� Width$
 auto��6%   $��Voornaam��50   %    �� DisplayMemberBinding 51   %   �� *
Voornaam+�� 52      $
 auto��6%   $��Familienaam��53   %    54   %   �� *Familienaam+56      58      �� 5:   
   $��2��6   $��0��6"   $��Center=�62   $��	30 0 30 0q�6M   .+�5;      �� 
�������$#��Zijn er 4 spelers toegevoegd?��6'   6Q   �� 5<      
�������$��Progressbar:��6'   6@   � 5=      $��30��6    � Maximum$ 4Q�6X    � Value 6'   �� *SpelSpelers.Count+ �� Mode$ OneWay=�6f   5>      �� 5@   
   $��1��6   $��1��6%   $��Center=�62   .+�5B      �� -   5        $��button1��5B      #��[ 6$   $��15(�6I   $"��>> Voeg Speler 1 toe (Groen)��5C      {�5B   W   ��  �� ElementName$ 	listView1��$ SelectedItems.Count���6�   �� *Inschrijven1Command+5C      �� 5D      -   5        $��button2��5D      #��[ 6$   $��15(�6I   $	��Top=�6�   $��	3 10 3 10q�6�   $"��>> Voeg Speler 2 toe (Blauw)��5E      {�5D   W   �� $ 	listView1��$ SelectedItems.Count���6�   �� *Inschrijven2Command+5E      �� 5F      -   5        $��button3��5F      #��[ 6$   $��15(�6I   $	��Top=�6�   $��	3 10 3 10q�6�   $!��>> Voeg Speler 3 toe (Geel)��5G      {�5F   W   �� $ 	listView1��$ SelectedItems.Count���6�   �� *Inschrijven3Command+5G      �� 5H      -   5        $��button4��5H      #��[ 6$   $��15(�6I   $	��Top=�6�   $��	3 10 3 10q�6�   $!��>> Voeg Speler 4 toe (Rood)��5I      {�5H   W   �� $ 	listView1��$ SelectedItems.Count���6�   �� *Inschrijven4Command+5I      5K      �� 5L   
   $��1��6   $��2��6!   $��START HET SPEL��6.   #��[ 6G   $��30q�6l   ��6x   �� *OpenSpelbordCommand+6�   5N      5O      