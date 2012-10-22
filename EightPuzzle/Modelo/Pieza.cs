using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace EightPuzzle
{
    public class Pieza
    {
        public int Valor { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public CroppedBitmap Imagen { get; set; }

        public Pieza(int valor, int fila, int columna, CroppedBitmap imagen)
        {
            Valor = valor;
            Fila = fila;
            Columna = columna;
            Imagen = imagen;
        }
    }
}
