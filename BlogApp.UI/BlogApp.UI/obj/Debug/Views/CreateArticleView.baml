   M S B A M L   `   `   `  ����E  ABlogApp.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BlogApp.UI.ViewsBlogApp.UI.Views  5   	   (    "BlogApp.UI.Views.CreateArticleView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BlogApp.UI.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  CreateArticleView��5   	    � AllowsTransparency .  � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterOwner=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	   $	��500��5      $	��375��6    � 
ResizeMode$ NoResize=�5   	    � DataContext 5   	   ��   locator �� Source# [ 	 �� Path$	 CreateArticleVM�
 � 	Resources
 5       �� Source�� 5   
   $ MaterialDesign.xaml?�6   %    6<   .��5      � 
 5   
   �� 5       $ MaterialDesign.xaml?�6!   %    6@    � RowDefinitions 5"   
   �� 5#      $��80 �6   6*   �� 5$      $��40 �6   6*   �� 5%      6   �� 5&      $��50 �6   6*   �� 5'      $��50 �6   6*   �� 5(      $��50 �6   6*   �� 5)      $��40 �6   6*   �� 5*      $��60 �6   6*   �� 5+      $��20 �6   6*   .+�5.   
   '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�6"   $��Center=�5/         Kind$ 	Newspaper=�50   "   $��70��51   "   $��70��52   "   53      �� 54   
   $��	30,0,30,0q�6   $��1��55      $��Center=�56      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Title��59         
IsFloating . ��57      �� *CreatedArticle.Title+5:      �� 5<   
   $��2��6   .��5=      �� $��Center=�5@       �� SelectionMode$ Single=�5A      $
��Auto=�5B      $��5q�5D       # MaterialDesignFilterChipListBox#��[ 5E      ��5?      �� *
HashTags+ �� SelectedItem 5C      �� *	Hashtag+��5H      �� 5I      .R�5J      �� ��6$   �� *Tag+6<   5K      5N      5O      �� 5Q   
   $��3��6    �� Orientation$ 
Horizontal=�6"   .+�5R        $��34��6'   $��34��62   $ Pound=�6>   $
��0,10q�6K   �� 5S      $��8q�5T      $��Center=�5U      $	��260��5V      $ Hashtag��5W       . ��5Y      �� *Hashtag.Tag+�� 5[      $��Right=�6<   ��6   �� *AddHashTagCommand+.��5\        $	 Add=�5]      $��25��5^      $��30��5_      5`      5a      5d      �� 5h   
   $��4��6   $ 
Horizontal=�6"   .+�5i        $
 File=�6&   $��34��62   $��34��6=   $��0, 10q�6I   6Z   �� 5k      $��8q�5l      $��Center=�5m      $	��260��5n      $ 	File Path��5o       . $	��328��5p   >   ��6J   �� *
FilePath+5q      �� 5r   
   $��5��5s        MaterialDesignRaisedButton#��[ 5t      $��Right=�5u      $��0, 0, 10, 0q�5v      $
��OPEN��5w      ��5x      �� *BrowserCommand+62   �� 5y   
   $��6��6   $ 
Horizontal=�6"   .+�5{      �� $��70, 0, 0, 0q�6   #��[ 5~      $��Right=�5      $
��SAVE��5�      ��5�      �� *CreateCommand+��67   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL�6�   �� 5�      $��50, 0, 0, 0q�6   #��[ 5�      $��Right=�5�      $��CANCLE��5�       �� IsCancel . ��5�      �� *CancleCommand+��5�      ��  �� $ FindAncestor=�$ WindowL�5�      5�      � 5�   
   $��7��6   {�.  $��5q�5�       � IsIndeterminate . 5�      5�      5�      