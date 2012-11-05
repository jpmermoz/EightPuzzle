using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace EightPuzzle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage imagen;
        Tablero tablero;

        public MainWindow()
        {
            InitializeComponent();

            imagen = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + @"\Imagenes\imagen.jpg"));
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 500;
            rectangle.Height = 500;
            rectangle.Fill = new ImageBrush(imagen);

            tablero = new Tablero(3, 3, imagen);

            foreach (Pieza p in tablero.Piezas)
            {
                Rectangle r = new Rectangle();
                r.Width = Canvas.Width / tablero.Filas;
                r.Height = Canvas.Height / tablero.Columnas;
                r.Fill = new ImageBrush(p.Imagen);
                r.Stroke = new SolidColorBrush(Colors.Black);
                r.StrokeThickness = 1;
                r.SetValue(Canvas.LeftProperty, Convert.ToDouble(p.Columna * (Canvas.Width / tablero.Filas)));
                r.SetValue(Canvas.TopProperty, Convert.ToDouble(p.Fila * (Canvas.Height / tablero.Columnas)));
                Canvas.Children.Add(r);
            }
        }

        private void buttonDesordenar_Click(object sender, RoutedEventArgs e)
        {
            tablero.Desordenar(50);
            DibujarTablero();
        }

        private void buttonOrdenar_Click(object sender, RoutedEventArgs e)
        {
            tablero.Coordenadas.Clear();
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork+=new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync();
            progressBar1.IsIndeterminate = true;
            buttonDesordenar.IsEnabled = false;
            buttonOrdenar.IsEnabled = false;
        }

        void  worker_DoWork(object sender, DoWorkEventArgs e)
        {
            tablero.Ordenar();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DibujarTablero();
            progressBar1.IsIndeterminate = false;
            buttonDesordenar.IsEnabled = true;
            buttonOrdenar.IsEnabled = true;
        }

        private void DibujarTablero()
        {
            Canvas.Children.Clear();

            foreach (Pieza p in tablero.Piezas)
            {
                Rectangle r = new Rectangle();
                r.Width = Canvas.Width / tablero.Filas;
                r.Height = Canvas.Height / tablero.Columnas;
                r.Fill = new ImageBrush(p.Imagen);
                r.Stroke = new SolidColorBrush(Colors.Black);
                r.StrokeThickness = 1;
                r.SetValue(Canvas.LeftProperty, Convert.ToDouble(p.Columna * (Canvas.Width / tablero.Filas)));
                r.SetValue(Canvas.TopProperty, Convert.ToDouble(p.Fila * (Canvas.Height / tablero.Columnas)));
                Canvas.Children.Add(r);
            }
        }

        private void buttonGraficar_Click(object sender, RoutedEventArgs e)
        {
            distanciasSeries.ItemsSource = tablero.Coordenadas;
            distanciasSeries.Refresh();
        }
    }
}
