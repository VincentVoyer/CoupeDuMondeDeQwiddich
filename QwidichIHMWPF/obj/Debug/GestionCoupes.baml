   M S B A M L   `   `   `  ����  QwidichIHMWPF!    QwidichIHMWPF.GestionCoupes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Gestion Des Coupes��5   	   $	��300��6$   $	��400��64   $	��300��6C   $	��400��6P   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      .+�5
   
   �� -   5        $
��cups��5
   "   $��0��6      cupTemplate#��[  6.   ��6Z   �� *cups+ �� SelectedItem 6w   �� *SelectedCup+�� 5   
   $��1��6   .+�5      �  � DataContext 6   �� *SelectedCup+ 5      �� 5      $��42 �6'   �� 5       � RowDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��0��6,   
Année :6B   �� 5      $��0��6   $��1��6,   
Libellé :6D   �� 5      -   5        $��annee��5   7   $��1��6   $��0��6*   $��Stretch=�6D   ��6b   �� *Year+�� 5      -   5        $��libelle��5   7   $��1��6   $��1��6*   $��Stretch=�6F   ��6d   �� *	Libelle+5      � 5      $��Right=�6   .+�5      �� -   5        $
��supp��5   -   $��	Supprimer��6     
buttonHome#��[ 6R   ��69   �� *Supp+6R   �� 5      -   5        $	��add��5   +   $��Ajouter��6   #��[ 6N   ��66   �� *Add+6N   5      5      5      5       