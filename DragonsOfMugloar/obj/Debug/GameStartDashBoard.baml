   M S B A M L   `   `   `  ����K  GDragonsOfMugloar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DragonsOfMugloarDragonsOfMugloar  5      )    #DragonsOfMugloar.GameStartDashBoard   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:DragonsOfMugloar     5        N� Title$  GameStartDashBoard��5	      .��5      � $��0,0,-628,-119q�6   ���	#FFDED7BC � ColumnDefinitions 5   
   �� 5      $
��263* �6   �� 5      $��1139* �6   .+�5   
   �� -   5         ��Name$ StartNewGameButton��5      $��Start new game!��6-   $
��Left=�6G   $��
86,475,0,0q�6b   $	��Top=�6v   $	��165��6�   $��47��6�   ���	#FFC9B97D6�   �� 5   
   -   5         ��Name$ GameDataJsonTextBox��5      $
��Left=�6/   $	��115��6J   $��	51,38,0,0q�6W    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��211��6�   �� 5   
   -   5        $$ CheckGameReputationJsonTextBox��5      $
��Left=�6:   $	��131��6U   $��
51,176,0,0q�6b   $
 Wrap=�6v   $	��Top=�6�   $	��211��6�   �� 5   
   -   5         ��Name$ StartingLivesLabel��5      $
��Left=�60   $��16(�6K   $��
119,57,0,0q�6Y   $
��Wrap=�6m   $	��Top=�6�   �� 6�   $�Current ��6�   �� 6�   $�l��6�   �� 6�   $�ives:��6�   6�   �� 5   
   -   5        $ StartingGoldLabel��5      $
��Left=�6/   $��16(�6J   $��
116,93,0,0q�6X   $
��Wrap=�6l   $	��Top=�6�   �� 6�   $�Current ��6�   �� 6�   $
�gold��6�   �� 6�   $�:��6�   6�   �� 5   
   -   5        $ StartingDragonLevelLabel��5      $��16(�66   $
��Left=�6E   $��116,132,0,0q�6`   $
��Wrap=�6u   $	��Top=�6�   �� 6�   $�Dragon ��6�   �� 6�   $�level��6�   �� 6�   $�:��6�   6�   �� 5   
   -   5        $ StartingScoreLabel��5      $��16(�60   $
��Left=�6>   $��111,172,0,0q�6Y   $
��Wrap=�6n   $	��Top=�6�   �� 6�   $�Current��6�   �� 6�   $� score:��6�   6�   �� 5   
   -   5        $ StartingHighScoreLabel��5      $��16(�64   $
��Left=�6B   $��134,210,0,0q�6]   $
��Wrap=�6r   $	��Top=�6�    J� RenderTransformOrigin$ 0.415,0.517&�6�   �� 6�   $�Highsco��6�   �� 6�   $�r��6�   �� 6�   $�e��6�   �� 6�   $�:��6�   6  �� 5   
   -	   5        $ StartingTurnNumberLabel��5      $��16(�65   $
��Left=�6C   $��115,242,0,0q�6^   $
��Wrap=�6s   $��Turn number:��6�   $	��Top=�6�   �� 5   
   -
   5        $$ StartingGameAdventureNameLabel��5      $��16(�6<   $
��Left=�6J   $��	45,36,0,0q�6f   $
��Wrap=�6y   $	��Top=�6�   �� 6�   $�Game adventure name:��6�   6�   �� 5    
   -   5        $! GameAdventureNameValueLabel��5       $��16(�69   $
��Left=�6G   $��
210,38,0,0q�6b   $
��Wrap=�6v   $	��Top=�6�   $	��106��6�   $��2��6�   �� 5!   
   -   5        $ GameLivesValueLabel��5!      $
��Left=�61   $��16(�6L   $��
232,57,0,0q�6Z   $
��Wrap=�6n   $�� ��6�   $	��Top=�6�   �� 5"   
   -   5        $ GameGoldValueLabel��5"      $��16(�60   $
��Left=�6>   $��
232,96,0,0q�6Y   $
��Wrap=�6m   $�� ��6�   $	��Top=�6�   �� 5#   
   -   5        $ GameDragonLevelValue��5#      $
��Left=�62   $��16(�6M   $��232,134,0,0q�6[   $
��Wrap=�6p   $�� ��6�   $	��Top=�6�   �� 5$   
   -   5        $ GameScoreValueLabel��5$      $��16(�61   $
��Left=�6?   $��232,173,0,0q�6Z   $
��Wrap=�6o   $�� ��6�   $	��Top=�6�   �� 5%   
   -   5        $ GameHighScoreValueLabel��5%      $��16(�65   $
��Left=�6C   $��232,210,0,0q�6^   $
��Wrap=�6s   $�� ��6�   $	��Top=�6�   �� 5&   
   -   5        $ GameTurnValueLabel��5&      $��16(�60   $
��Left=�6>   $��232,242,0,0q�6Y   $
��Wrap=�6n   $�� ��6�   $	��Top=�6�   �� 5'   
   -   5        $ CheckGameReputationButton��5'      $��Check reputation!��64   $
��Left=�6P   $��	13,36,0,0q�6k   $	��Top=�6~   $	��122��6�   $��1��6�   ���	#FFC9B97D6�   �� 5(   
   -   5        $ GameReputationPeopleLabel��5(      $��16(�67   $
��Left=�6E   $��	53,76,0,0q�6`   $
��Wrap=�6s   $	��Top=�6�   $��1��6�   �� 6�   $�People��6�   �� 6�   $�:��6�   6�   �� 5)   
   -   5        $ GameReputationStateLabel��5)      $��16(�66   $
��Left=�6D   $��
63,112,0,0q�6_   $
��Wrap=�6s   $	��Top=�6�   $��State:��6�   $��1��6�   �� 5*   
   -   5        $# GameReputationUnderworldLabel��5*      $��16(�6;   $
��Left=�6I   $��
18,150,0,0q�6d   $
��Wrap=�6x   $	��Top=�6�   $��1��6�   �� 6�   $�
Underworld��6�   �� 6�   $�:��6�   6�   �� 5+   
   -   5        $$ GameReputationPeopleValueLabel��5+      $��16(�6<   $
��Left=�6J   $��
114,76,0,0q�6e   $
��Wrap=�6y   $	��Top=�6�   $��1��6�   �� 5,   
   -   5        $# GameReputationStateValueLabel��5,      $��16(�6;   $
��Left=�6I   $��114,112,0,0q�6d   $
��Wrap=�6y   $	��Top=�6�   $��1��6�   �� 5-   
   -   5        $( "GameReputationUnderWorldValueLabel��5-      $��16(�6@   $
��Left=�6N   $��114,150,0,0q�6i   $
��Wrap=�6~   $	��Top=�6�   $��1��6�   �� 5.   
   -   5        $ CheckForAdventuresButton��5.      $$��Check for adventures to solve!��63   $
��Left=�6\   $��
288,82,0,0q�6w   $	��Top=�6�   $	��184��6�   $��38��6�   $��1��6�   ���	#FFC9B97D6�   �� 5/   
   -   5        $+ %CheckGameAdventureMessagesJsonTextBox��5/      $
��Left=�6A   $��64��6\   $��
51,322,0,0q�6h   $
 Wrap=�6|   $	��Top=�6�   $	��211��6�   �� 50   
   -   5         ��Name$' !CheckGameAdventureMessagesListBox��50      $
��Left=�6=   $	��422��6X   $��
63,134,0,0q�6e   $	��Top=�6y   $	��578��6�   $��1��6�   �� 51   
   -   5        $* $CheckGameAdventureSolvingJsonTextBox��51      $
��Left=�6@   $��53��6[   $��
51,391,0,0q�6g   $
 Wrap=�6{   $	��Top=�6�   $	��211��6�   �� 52   
   -   5        $# MissionWasSuccessfulTextBlock��52      $��16(�6;   $
��Left=�6I   $��
46,288,0,0q�6d   $
��Wrap=�6x   $��Mission was successful:��6�   $	��Top=�6�   �� 53   
   -   5        $$ MissionWasSuccessfulValueLabel��53      $��16(�6<   $
��Left=�6J   $��215,288,0,0q�6e   $
��Wrap=�6z   $	��Top=�6�   �� 54   
   -   5        $ GameShopJsonTextBox��54      $
��Left=�61   $��
62,449,0,0q�6L   $
��Wrap=�6`   $	��Top=�6t   $	��120��6�   $��45��6�   �� 55   
   -    5        $ GameGoToTheShopButton��55      $��Go to the shop!��60   $
��Left=�6J   $��
741,81,0,0q�6e   $	��Top=�6y   $	��118��6�   $��39��6�   $��1��6�   ���	#FFC9B97D6�   �� 56   
   -!   5        $ GameShopItemsListBox��56      $	��304��60   $��656,134,0,0q�6=   $	��Top=�6R   $��1��6�   $
��Left=�6�   $	��286��6�   �� 57   
   -"   5        $( "ItemPurchaseWasSuccessfulTextBlock��57      $��16(�6@   $
��Left=�6N   $��
36,322,0,0q�6i   $
��Wrap=�6}   $��Purchase was successful:��6�   $	��Top=�6�   �� 58   
   -#   5        $) #ItemPurchaseWasSuccessfulValueLabel��58      $��16(�6A   $
��Left=�6O   $��215,322,0,0q�6j   $
��Wrap=�6   $	��Top=�6�   �� 59   
   $N��HTry to solve the highest probability and highest gold reward adventures!��6   $��1��6c   $��16(�6s   $
��Left=�6�   $��
114,38,0,0q�6�   $	��Top=�6�   $	��516��6�   �� 5:   
   $/��)Improve your character with buying items!��6   $��1��6D   $
��Left=�6T   $��16(�6o   $��
671,44,0,0q�6}   $	��Top=�6�   $ 0.75,-0.192&�6�   5=      5>      