   M S B A M L   `   `   `  ����   BFMTools    BFMTools.Views.Liquidites   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     .��� $��20q�  � RowDefinitions  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�$	��Top=�$��0,10,0,0q�.+��� -    ��Name$) #Btn_Liquidites_Crediteurs_File_Load��$��Fichiers Créditeurs���� -    ��Name$! txt_xls_crediteur_file_path��$��Path to file��
�������$��Center=�$��15,0,0,0q��� $��1��$ 
Horizontal=�$	��Top=�$��0,10,0,0q�.+��� -   $) #Btn_Liquidites_Débiteurs_File_Load��$��Fichiers Débiteurs���� -   $  txt_xls_debiteur_file_path��$��Path to file��
�������$��Center=�$��15,0,0,0q��� $��2��$��Client info��$��16(�$
��Bold"�
��� ���$��0,30,0,5q��� $��3��$ 
Horizontal=�$	��Top=�$��0,5,0,0q�.+��� $��Nom du client :��
�������$��Center=��� -    ��Name$ cmb_client_name��$	��200�� �� DisplayMemberPath$
 Name��$��8q����� *	Clients+� $��10q� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0��$��20,0,0,0q�$	��300��.+��� $��Friendly name :��$
��Bold"��� -   $ txtfriendlyName��$��0,0,0,10q��� $��Logo path :��$
��Bold"��� -   $ txtLogoPath��$��0,0,0,10q��� $��Primary color :��$
��Bold"��� $ 
Horizontal=�$��0,0,0,10q�.+��� -   $ txtPrimaryColor��$��Center=��� -	    ��Name$ rectPrimaryColor��$��20��$��20��$��10,0,0,0q�
���   ��� $��Secondary color :��$
��Bold"��� $ 
Horizontal=�.+��� -
   $ txtSecondaryColor��$��Center=��� -   $ rectSecondaryColor��$��20��$��20��$��10,0,0,0q�
���   ��� $��1��$	��100��$	��100��$��20,0,0,0q�
�������$��1q�._��� -    ��Name$ imgClientLogo��$��Uniform=��� $��4��$��Report��$��16(�$
��Bold"�
��� ���$��0,30,0,5q��� $��5��$ 
Horizontal=�$	��Top=�$��0,5,0,0q�.+��� $��Report Date :��
�������$��Center=�(  "System.Windows.Controls.DatePicker  -   	  Name$	 Date_report_date��$	��180��$��30��$��10,0,0,0q�
   SelectedDateFormat$
 Short=�   DisplayDate$ 
2025-06-04��   IsTodayHighlighted$
 True���� $��Montant du report :��
�������$��Center=�$��20,0,0,0q��� -    ��Name$ txt_report_amount��$	��180��$��30��$��10,0,0,0q��� $��6��$��Charges��$��16(�$
��Bold"�
��� ���$��0,30,0,5q��� $��7��$ 
Horizontal=�$	��Top=�$��0,5,0,0q�.+��� $��Salaire mensuel :��
�������$��Center=��� -   $ txt_salary_amount��$	��180��$��30��$��10,0,0,0q��� $��13ème salaire :��
�������$��Center=�$��20,0,0,0q��� -    ��Name$ chk_13th_salary��$�� ��$��Center=�$��10,0,0,0q� d� 	IsChecked$
 TrueY��� $��8��$ 
Horizontal=�$	��Top=�$��0,5,0,0q�.+��� $��Charges redondantes :��
�������$��Center=��� -   $ txt_reccuring_amount��$	��180��$��30��$��10,0,0,0q��� $��Charges date :��
�������$��Center=�$��20,0,0,0q�  -   $	 Date_Recurring_date��$	��180��$��30��$��10,0,0,0q�$
 Short=�$ 
2025-06-04��$
 True���� $��9��$	��Top=�$��0,30,0,0q�.+��� -   $ Btn_Report_Creation��$��	Calculate��$	��100��$��30��$��Right=�