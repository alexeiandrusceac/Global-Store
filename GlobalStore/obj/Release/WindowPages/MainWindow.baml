   M S B A M L   `   `   `  ���� F  BGlobalStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GlobalStoreGlobalStore      GlobalStore.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:GlobalStore     U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4:
extToolkit)http://schemas.xceed.com/wpf/xaml/toolkit  b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/     WindowStyle#��[    � WindowStartupLocation$  CenterScreen=� � WindowState$ 	Maximized=� � 	Resources   OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%n  &	       &	 p    �� .��U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ GridMain��.\�  $ 0��$ 0Q�  $ 0:0:0.5��$	 250Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ GridMain��.\�  $ 0��$ 0Q�  $ 0:0:0.5��$ 50Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ StackPanelMenu��.\�  $ 0��$ 0Q�  $ 0:0:0.5��$	 250Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ listViewItem1��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:0.7��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ listViewItem2��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:0.9��$ 0Q��� .��U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ GridMain��.\�  $ 0��$	 250Q�  $ 0:0:0.5��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ GridMain��.\�  $ 0��$ 50Q�  $ 0:0:0.5��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ StackPanelMenu��.\�  $ 0��$	 250Q�  $ 0:0:0.5��$ 0Q�.��� ���#EAA124$��0,-3,0,0q� � RowDefinitions �� $	��13* ��� $��5* � � ColumnDefinitions �� $
��271* ��� $
��145* ��� $	��92* �.+��� -   	 ��Name$	 StackPanelMenu��$	��222��$
��Left=�$��-5,-10,0,10q�
 J� RenderTransformOrigin$
 0.5,0.5&�$��2��z�V� .~��� �� �� T� .+���  �� Orientation$ 
Horizontal=�$	��Top=�$	��100��$��Center=�.+��� $/��)/GlobalStore;component/Resources/logo.png��$	��168��$��0,0,0,10q�{�.  �� .@��� -    ��Name$ listViewItemScanning��$��60��$
 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Scanner=����#242222$��30��$��30��$��Center=�$��5q��� -    ��Name$ listViewItem_txtscan�����#242222$��10q�$��Center=��� $	��381��.@��� -   $ listViewTranslateEn��$��60��$
 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+��� $6��0/GlobalStore;component/Resources/Language/en.png��$��30��$��30��$��Center=�$��5q��� -   $ txt_en��$��10q����#242222$��Center=��� -   $ listViewTranslateRo��$��60��$
 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+��� $6��0/GlobalStore;component/Resources/Language/ro.png��$��30��$��30��$��Center=�$��5q��� -   $ txt_ro��$��10q����#242222$��Center=��� -   $ listViewTranslateRu��$��60��$
 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+��� $6��0/GlobalStore;component/Resources/Language/ru.png��$��30��$��30��$��Center=�$��5q��� -	   $ txt_ru��$��10q����#242222$��Center=�� -
    �Name$ mainGrid�����	#FFFBFBFB$��
222,50,0,0q�$
 0.5,0.5&�$��3��$��2��.+�� -   $ scannerGrid��z�V� .~��� �� �� T�  �� $��* ��� $	��250 �.+�� $��1�����#242222.+��� $��	0,0,0,374q��� $��
0,150,0,78q�.+��� -   $ productTitle��
�������$��28(�$��Nirmala UI Semilight)�$	��Top=�$
 0.488,-1.432&��� -   $ productDescription��$
��Wrap=�$
��0,10q����	#FFFBFBFB$��14(�$	��245���� $��	0,416,0,0q����#EAA124.+��� -   $ 
priceTitle��$
��Wrap=�$��26(����#242222$��	0,0,140,0q�$��39���� -   $ priceRetail��$
��Wrap=�$��26(����#242222$��1��$
 0.5,0.5&�z�V� .~���  �� ScaleY$ -1Q��� �� T� �� -   $ 
pricePromo��$
��Wrap=�$��46(�
���  ��$y�Hidden=��  �� $��40 ��� $��50 ��� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* �.+�� $��5q�$��2��$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   Color$ 	#FFEEEEEE��   ShadowDepth$ 1Q�.+��� -    ��Name$ 	mainImage��$��UniformToFill=��� $ 
Horizontal=�$��5q�$��Right=�$��Bottom=�� $��5q�$��2��$��1��   $ 20Q�$ 	#FFEEEEEE��$ 1Q�.+��� $��UniformToFill=��� $ 
Horizontal=�$��5q�$��Right=�$��Bottom=�� $��5q�$��2��$��2��.+��� $��UniformToFill=��� $ 
Horizontal=�$��5q�$��Right=�$��Bottom=�� $��5q�$��3��$��0��   $ 20Q�$ 	#FFEEEEEE��$ 1Q�.+��� $��UniformToFill=��� $ 
Horizontal=�$��5q�$��Right=�$��Bottom=�� -   $ feedbackGrid��$y�Hidden=�z�V� .~��� �� �� T�  �� $��* ��� $	��250 �.+�� $��1�����#242222.+��� -   $ 	feedback1��
�������$��28(�$��Nirmala UI Semilight)�$��10 100q�$	��Top=��� $��0 150q�.+��� -   $ 	feedback2��$
��Wrap=�$��10q����	#FFFBFBFB$��14(��� $��
0,150,0,40q�