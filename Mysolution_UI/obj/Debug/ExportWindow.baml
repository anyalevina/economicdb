   M S B A M L   `   `   `  ����H  DMysolution_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Mysolution_UIMysolution_UI  5   	        Mysolution_UI.ExportWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Mysolution_UI     5   	     � Title$  Track Economic Variables��5   	   $	��400��6*   $	��400��67   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��100 �6   6.   �� 5      $	��100 �6   6-   �� 5      6!   �� 5      $	��120 �6   6-    � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      6   �� 5      6   .+�5   
   �� -   5        $��VarTextBlock��5      $��2��6(   6>   �� 5   
   $��2��6   $��1��6%   for Country:6G   �� 5   
   -   5        $��CountryTextBlock��5      $��3��6-   6@   �� 5   
   -   5        $��ExportListView��5      $��1��6*   $��2��67   $��3��6H    �� View 5      �� 5      .P�5      ��  �� Width$ 50��6%   $
��Year��60    �� DisplayMemberBinding 6>   �� *Year+�� 5      $��Your Requested Variable��6%    6F   �� *
EconomyVar+5      5      o� 5    
   $��1��6   $��3��6   $��80��6,   .@�5!      m� -   5        $
��Exit��5!      $��40��6#   $��80��6/   $��Exit App��6:   6d   m� 5"      -   5        $��Close��5"      $��40��6$   $��80��60   $��Close Window��6;   6j   5$      5%      5&      