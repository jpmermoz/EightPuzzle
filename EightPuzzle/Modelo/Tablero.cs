using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows;

namespace EightPuzzle
{
    public class Tablero
    {
        private List<Pieza> piezas = new List<Pieza>();
        public int Filas { get; set; }
        public int Columnas { get; set; }

        public List<List<Pieza>> Movimientos = new List<List<Pieza>>();
        private static Random random = new Random(DateTime.Now.Millisecond);
        private List<Pieza> EstadoObjetivo;
        public List<Coordenada> Coordenadas = new List<Coordenada>();
        public List<Pieza> Piezas
        {
            get
            {
                return piezas;
            }
        }

        public Tablero(int filas, int columnas, BitmapImage imagen)
        {
            Filas = filas;
            Columnas = columnas;

            int valor = 1;

            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    piezas.Add(new Pieza(valor, i, j, new CroppedBitmap(imagen, new Int32Rect((imagen.PixelWidth / Columnas) * j, (imagen.PixelHeight / Filas) * i, imagen.PixelWidth / Filas, imagen.PixelHeight / Columnas))));
                    valor++;
                }
            }

            piezas.Where(p => p.Fila == 2 && p.Columna == 2).FirstOrDefault().Valor = 0;
            EstadoObjetivo = Clonar(piezas);
        }

        public void Desordenar(int pasos)
        {
            Pieza piezaVacia = ObtenerPieza(0);

            for (int i = 0; i < pasos; i++)
            {
                List<Pieza> piezasAdyacentes = ObtenerPiezasAdyacentes(piezaVacia);
                Pieza piezaAleatoria = ObtenerPiezaAleatoria(piezasAdyacentes);
                CambiarPiezasDePosicion(piezaVacia, piezaAleatoria);
            }
        }

        public Pieza ObtenerPieza(int valor)
        {
            return piezas.Where(p => p.Valor == valor).FirstOrDefault();
        }

        public List<Pieza> ObtenerPiezasAdyacentes(Pieza p)
        {
            List<Pieza> piezas = new List<Pieza>();
            Pieza p1 = ObtenerPiezaPorPosicion(p.Fila, p.Columna - 1);
            Pieza p2 = ObtenerPiezaPorPosicion(p.Fila - 1, p.Columna);
            Pieza p3 = ObtenerPiezaPorPosicion(p.Fila, p.Columna + 1);
            Pieza p4 = ObtenerPiezaPorPosicion(p.Fila + 1, p.Columna);

            if (p1 != null)
                piezas.Add(p1);
            if (p2 != null)
                piezas.Add(p2);
            if (p3 != null)
                piezas.Add(p3);
            if (p4 != null)
                piezas.Add(p4);

            return piezas;
        }

        public Pieza ObtenerPiezaPorPosicion(int fila, int columna)
        {
            return piezas.Where(p => p.Fila == fila && p.Columna == columna).FirstOrDefault();
        }

        private Pieza ObtenerPiezaAleatoria(List<Pieza> piezas)
        {
            return piezas[random.Next(piezas.Count)];
        }

        private void CambiarPiezasDePosicion(Pieza p1, Pieza p2)
        {
            int aux = p1.Fila;
            p1.Fila = p2.Fila;
            p2.Fila = aux;

            aux = p1.Columna;
            p1.Columna = p2.Columna;
            p2.Columna = aux;
        }

        public void Ordenar()
        {
            int movimientos = 0;
            int distancia = CalcularDistanciaManhattan();

            Coordenadas.Add(new Coordenada(movimientos, distancia));
            Pieza piezaVacia = ObtenerPieza(0);
            Pieza piezaOptima = new Pieza(-1, 0, 0, null);

            while (distancia != 0)
            {
                List<Pieza> piezasAdyacentes = ObtenerPiezasAdyacentes(piezaVacia);
                
                foreach (Pieza p in piezasAdyacentes)
                {
                    CambiarPiezasDePosicion(p, piezaVacia);
                    int nuevaDistancia = CalcularDistanciaManhattan();

                    if (nuevaDistancia < distancia)
                    {
                        distancia = nuevaDistancia;
                        piezaOptima.Valor = p.Valor;
                    }
                    else
                    {
                        piezaOptima.Valor = -1;
                    }

                    CambiarPiezasDePosicion(p, piezaVacia);
                }

                if (piezaOptima.Valor != -1)
                {
                    CambiarPiezasDePosicion(ObtenerPieza(piezaOptima.Valor), piezaVacia);
                    movimientos++;
                    Coordenadas.Add(new Coordenada(movimientos, distancia));
                    Movimientos.Add(Clonar(Piezas));
                }
                else
                {
                    Desordenar(3);
                    distancia = CalcularDistanciaManhattan();
                    Movimientos.Add(Clonar(Piezas));
                }
            }
        }

        private int CalcularDistanciaManhattan()
        {
            int distancia = 0;

            foreach (Pieza pieza in piezas)
            {
                Pieza piezaObjetivo = EstadoObjetivo.Where(p => p.Valor == pieza.Valor).FirstOrDefault();
                distancia += Math.Abs(piezaObjetivo.Fila - pieza.Fila) + Math.Abs(piezaObjetivo.Columna - pieza.Columna);
            }

            return distancia;
        }

        private List<Pieza> Clonar(List<Pieza> piezas)
        {
            List<Pieza> clon = new List<Pieza>();

            foreach (Pieza p in piezas)
            {
                clon.Add(new Pieza(p.Valor, p.Fila, p.Columna, p.Imagen));
            }

            return clon;
        }
    }
}
