   M S B A M L   `   `   `  ����F  BProjectMEJN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectMEJN.ViewsProjectMEJN.Views  5   	   "    ProjectMEJN.Views.SpelRegels   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ProjectMEJN.Views     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�6.    � Title$ 
SpelRegels��5
   	   $	��600��6   $	��700��6)    � DataContext 5   	   ��    ViewModelLocator �� Source# [   �� Path$ SpelregelsViewModel���5      
� 5   
   .��5      �  � Color$ 	#FF6D000E��6    � Offset$	 1.1Q�6-   � 5      $ #EC808D��6   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   ��  	 Titel#��[ 6   $��0��63   $��Center=�6@   $	��Top=�6]   $��
Spelregels��6u   6�   �� 5   
   $��1��6   	 �� Orientation$	 Vertical=�6"   $��Center=�6:   $��Center=�6W   $��600px��6r   
 � 	Resources
 5       �� 
TargetType �� Property �� Value��%
  '��       �� 5      " ��6   .�5      ��  � ��$
 Wrap=�65   6D   �� 5       �@��Padding$ 10q�60   6=   �� 5       � ��
 �����6C   �� 5        � ��$ 
Montserrat)�63   6H   �� 5!       � ��$ 12(�61   6>   5"      5#      .+�5$      �� $����Elke speler kiest een kleur en zijn pion wordt automatisch aan de rand van het speelbord geplaatst. Speler 1 begint als eerste. Hij begint het spel met te werpen met de dobbelsteen, daarna is speler 2 aan bod, dan speler 3 en dan speler 4.��6   6  �� 5%      $����Wanneer meerdere spelers een pion op het bord hebben staan, wordt het spel een tikje gevaarlijker. Indien een pion op een reeds bezet vakje terechtkomt, moet de pion die daar eerder stond het veld ruimen. De speler mag nog eens werpen met de dobbelsteen. De geslagen pion wordt teruggezet op zijn beginvak aan de rand van het speelbord. Dit betekent dat de 'geslagen speler' opnieuw 6 moet gooien en met die pion weer helemaal opnieuw moet beginnen. Snap je al waar de naam van het spel vandaan komt? De speler ��6   6!  �� 5&      $����Indien je eerste pion het echte speelbord heeft betreden, mag je tijdens jouw beurt weer met de dobbelsteen gooien en je pion verplaatsen. Hoe hoger je gooit, des te meer stappen je vooruit mag zetten en hoe eerder je bij het thuishonk bent. Heb je al een pion in het spel en gooi je weer 6? Dan mag je gewoon je pion 6 stappen vooruit zetten.��6   6y  �� 5'      $����Het einddoel van het spel is de thuishonk op het vakje 56 van het speelbord. Er gelden specifieke Mens Erger Je Niet! regels voor het binnenkomen in het thuishonk. Ben je na een heel rondje dichtbij het thuishonk? Dan moet de worp jouw pion exact op het vakje 56 laten eindigen. Zo niet, wordt je pion weer naar een beginvak geplaatst. Je moet dus weer 6 gooien om je pion op het bord te plaatsen. Wie als eerste zijn pion binnen kan krijgen, wint het bordspel.��6   6�  5)      �� 5*   
     ButtonStyle#��[ 6   $	��175��66   $��2��6B   $
��HOME��6O   ��6^   �� *BackHomeCommand+6�   5,      5-      