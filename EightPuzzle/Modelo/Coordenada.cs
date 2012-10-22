using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightPuzzle
{
    public class Coordenada
    {
        public long Movimiento { get; set; }
        public int Distancia { get; set; }

        public Coordenada(long movimiento, int distancia)
        {
            Movimiento = movimiento;
            Distancia = distancia;
        }
    }
}
