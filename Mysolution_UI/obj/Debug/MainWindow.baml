   M S B A M L   `   `   `  ����H  DMysolution_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Mysolution_UIMysolution_UI  5   	       Mysolution_UI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   
   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   'localclr-namespace:Mysolution_UI  5   	     � Title$  World Economic Trends��5	   	   $	��500��6'   $	��525��64    � 
ResizeMode$ NoResize=�6@   .��5      �� 
���   �$��2q�6!   ._�5      � 
���   � � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $��80 �6   6*   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ Images/trends.gif��6   $��0��6E   $��4��6R      	AutoStart . $
��Fill=�5      $��0,0,-113.75,0q�6   o� 5      $��2��6   
���   �
���r���$��4��6H   .@�5      m� -   5        $	��170��5      $��Center=�6'   $��40��6D   $��18(�6P   $��View By Country��6^   6�   m� 5      -   5         m�Name$ YEarView��5      $��40��6.   $��18(�6:   $��View By Year��6H   .@�5      �� $��1q�6   
���   �6F   m� 5       -   5        $ TopEc��5       
���   �
���r���$��Top Economies��6U   6�   m� 5!      -   5        $ 	BottomGdp��5!      
���   �
���r���$��Bottom Economies��6Y   6�   m� 5"      -   5        $ FastGDPGrowth��5"      
���   �
���r���$��Fastest Growing Economies��6]   6�   m� 5#      -   5        $ sloGDPGrowth��5#      
���   �
���r���$��Slowest Growing Economies��6\   6�   5%      5'      �� 5)      $��1��6   $��4��6%    �� TextAlignment$ Center=�69   
��� ���$��27(�5*      $-��'Welcome to the  World Economy archive! ��5+      6J   5,      5-      5.      