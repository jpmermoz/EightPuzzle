   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	    EightPuzzle   EightPuzzle.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	     � Title$]  W8 Puzzle UM - Inteligencia Artificial - Alumnos: Mermoz, Juan Pedro || Mayorga, Julián��5   	   $	��564��6h   $
��1176��6u    � Icon$/ )/EightPuzzle;component/Imagenes/icono.ico��6�    � 
ResizeMode$ CanMinimize=�6�   .��5      � .+�5   
   �� -   5        $��Canvas��5   %   $��
139,11,0,0q�6   $	��500��63   $	��500��6?   $	��Top=�6L   $
��Left=�6d   �� 5   
   -   5        $��buttonDesordenar��5   E   $��
Desordenar��6   $��23��6&   $��	12,12,0,0q�62   $	��Top=�6]   $
��Left=�6�   $	��120��6�   �� 5	   
   -   5        $��buttonOrdenar��5	   B   $��Ordenar��6   $��23��6#   $��	12,41,0,0q�6/   $	��Top=�6W   $
��Left=�6�   $	��120��6�   � 5
   
   -   5        $��progressBar1��5
   5   $��23��6   $��	12,70,0,0q�6"   $	��Top=�6I   $
��Left=�6a   $	��120��6|   >   8System.Windows.Controls.DataVisualization.Charting.Chart  5   
   -   5        $��chartManhattan��5   3   $��	0,11,12,0q�6    
�������
���   �$��3q�6q      Title$ 	Manhattan��6�   $��Right=�6�   $	��497��6�   $	��500��6�   $	��Top=�6�      Series. 5      C   =System.Windows.Controls.DataVisualization.Charting.LineSeries  -   5        $��distanciasSeries��5   )   ?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ 
Distancias��6A   H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   AnimationSequence$ FirstToLast=�6T      DependentValuePath$ 	Distancia��6t      IndependentValuePath$ 
Movimiento��6�   5      5      �� 5   
   -   5        $��buttonGraficar��5   _   $��Graficar��6   $��23��6$   $
��Left=�60   $��
12,134,0,0q�6K   $	��Top=�6u   $	��120��6�   6�   5      5      