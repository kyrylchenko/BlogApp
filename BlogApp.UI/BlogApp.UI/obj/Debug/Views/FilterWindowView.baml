   M S B A M L   `   `   `  ����E  ABlogApp.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BlogApp.UI.ViewsBlogApp.UI.Views  5   	   '    !BlogApp.UI.Views.FilterWindowView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BlogApp.UI.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  FilterWindowView��5   	    � AllowsTransparency .  � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	   $	��329��5      $	��350��6    � 
ResizeMode$ NoResize=�5   	    � DataContext 5   	   ��   locator �� Source# [ 	 �� Path$	 FilterVM�
 � 	Resources
 5       �� Source�� 5   
   $ MaterialDesign.xaml?�6   %    6<   .��5      � 
 5   
   �� 5       $ MaterialDesign.xaml?�6!   %    6@    � RowDefinitions 5"   
   �� 5#      $��65 �6   6*   �� 5$      6   �� 5%      $��70 �6   6*   �� 5&      $��20 �6   6*   .+�5(   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�5)      $��Center=�5*      .+�5+      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Filter=�5,        PrimaryHueDarkBrush#��[ 5-      $��34��5.      $��34��5/      6   �� 50      $��30(�51      #��[ 52      $
��Bold"�53      Filter6.   54      �� 57   
   $��1��6   $	��174��6$   $	��Top=�61   .��58      ��  �� SelectionMode$ Multiple=�59      $��5q�5;      $
��Auto=�5<      $��Center=�5=       # MaterialDesignFilterChipListBox#��[ 5?      ��5>      �� *
HashTags+��5@      �� 5A      .R�5B      �� ��6$   �� *Tag+6;   5C      5E      5F      �� 5G   
   $��2��6   $ 
Horizontal=�6"   .+�5H      �� $��60,0,0,0q�5L        MaterialDesignRaisedButton#��[ 5M      $��ACCEPT��5O      ��5J      �� *AcceptCommand+��5K      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL�5O      �� 5P      $��70,0,0,0q�5T      #��[ 5U      $��CANCLE��5W       �� IsCancel . ��5R      �� *CancleCommand+��5S      ��  �� $ FindAncestor=�$ WindowL�5W   '   5X      � 5Y   
   $��3��6   {�.  $��5q�5\       � IsIndeterminate . 5]      5^      5_      