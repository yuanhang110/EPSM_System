   M S B A M L   `   `   `  ����  EPSM_System)    #EPSM_System.pages.record.RecordPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  
RecordPage��5      .��5
      ]� .+�5   
   c� $	��Top=�6   $��30��6'   .@�5      �� -   5        $��btnAdd��5       � ToolTip$ 新增��6#   $��Bottom=�6E   .��5      �� $��/images/add.png��6   63   5      �� 5      -   5        $��btnEdit��5      $ 编辑��6$   .��5      �� $��/images/edit.png��6   64   5      �� 5      -   5        $��	btnDelete��5      $ 删除��6&   .��5      �� $��/images/delete.png��6   66   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgUsers��5   T   $��Stretch=�6   $��2q�61   $	��Top=�6<      AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	员工号��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *ID+6I     5      $ 姓名��6%    61   �� *Name+  5      $ 职位��6%    61   �� *
Position+  5      $ 年龄��6%    61   �� *Age+  5      $ 性别��6%    61   �� *Sex+5      	   RowStyle	 5      �� 5       
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5!      ��  �� Property � �� �� Value
 ��ح�63    �� Triggers 5"      P� 5#       P� Property �@J�IsMouseOver P� Value . . �5$      ��  � ��
 �����6;   �� 5%       � ��
 � � �6;   5&      5(      5*      5+      5,      