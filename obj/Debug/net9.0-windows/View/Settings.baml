   M S B A M L   `   `   `  ����  BFMTools    BFMTools.Views.Settings   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X TXceed.Wpf.Toolkit, Version=4.7.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      .��5      �� $��20q�6   $	��500��6   .+�5	   
   �� $&�� Sélectionner un client existant��6   $��0,0,0,5q�6;   �� 5
   
   -   5          ��Name$  ClientComboBox��5
       �� DisplayMemberPath$
 Name��5      $��0,0,0,15q�5       �� SelectedItem 5      �� *SelectedClient+ �� Mode$ TwoWay=���5      �� *	Clients+5      �� 5   
   $��0,0,0,10q�6   .+�5      �� $��Nom du client��6   �� 5      -   5         ��Name$ NameBox��5      $	��300��6'   �� 5      $��Friendly Name��6   �� 5      -   5        $ FriendlyNameBox��5      $	��300��6/   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   $��Center=�6@   .+�5      �� $	��300��6   .+�5      �� $��
Logo (URL)��6   �� 5      -   5        $ LogoBox��5      $	��280��6+   67   5      �� 5       
�������$��1q�6(   $	��100��6<   $	��100��6H   $��	10,20,0,0q�6U   ._�5!      �� -   5         ��Name$ LogoPreview��5!      $��Uniform=�6-   5"      5#      �� 5&   
   $ Vertical=�6   $��0,0,0,10q�6,   .+�5'      �� $��Couleur principale (Menu)��6   #  Xceed.Wpf.Toolkit.ColorPicker  5(      -   5          Name$ 	Color1Box��5(      $	��200��5)         UsingAlphaChannel$ False��5+      5,      �� 5/   
   $ Vertical=�6   $��0,0,0,10q�6,   .+�50      �� $"��Couleur secondaire (tableau)��6     51      -   5        $ 	Color2Box��51      $	��200��52      $ False��54      55      �� 58   
   $ 
Horizontal=�6   $
��Left=�6.   $��0,10,0,0q�6I   .+�59      �� -   5        $��Ajouter��59      $	��100��6'   $��0,0,10,0q�6K   �� 5:      -	   5        $��Modifier��5:      $	��100��6(   64   5;      5=      5>      