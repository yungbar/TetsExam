   M S B A M L   `   `   `  ����F  BTourProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TourProject.xamlTourProject.xaml  5   	       TourProject.xaml.Window1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TourProject.xaml     5   	     � Title$  Window1��5	   	   $	��450��6   $	��800��6&    � 	Resources 5
         template �� Orientation �� Path��%G  &	        �� 5   
   .R�5      �� $	��100��6   $ Vertical=�6&   .+�5      �� ��6   �� $
 Name��� 5      �� 5      ��6   �� $ Price��� 5      $ 
Horizontal=�6   .+�5      �� ��6    �� $ isActual��� 5      ��6    �� $ TicketCount�5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      -   5         ��Name$ RowDefenition1��5   )   $	��100 �6   6)   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Right=�6"   $��Center=�6>   $ 
Horizontal=�6Y   .+�5       �� -   5         ��Name$ AddElementButton��5       $��
AddElement��6/   $	��200��6c   $��75��6o   5!      �� 5"   
   $��1��6   $��Center=�6"   $��Center=�6?   .+�5#      �� -   5         ��Name$ ToursElementComboBox��5#      $	��400��65    �� DisplayMemberPath$
 Name��5$      �� 5%      -   5        $ CloseWindowButton��5%      $��CloseWindow��60   $	��200��6f   $��75��6r   5&      �� 5'   
   -   5        	 ��Name$	 ListViewStackPanel��5'      $��2��61   .+�5(      �� -   5        
 ��Name$
 ObjectListBox��5(      $	��300��6-   #��[  5)      $��Disabled=�5+      $��Visible=�5,      ��5-      �� 5.      .R�5/      � 50      52      53      54      55      