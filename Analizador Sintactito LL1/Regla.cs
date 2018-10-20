using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Sintactico_LL1
{
    class Regla
    {
        private string ladoDerecho;
        private string ladoIzquierdo;

        public Regla(string ladoIzquierdo, string ladoDerecho)
        {
            this.ladoDerecho = ladoDerecho;
            this.ladoIzquierdo = ladoIzquierdo;
        }

        public string GetLadoDerecho()
        {
            return this.ladoDerecho;
        }

        public void SetLadoDerecho(string ladoDer)
        {
            this.ladoDerecho = ladoDer;
        }

        public string GetLadoIzquierdo()
        {
            return this.ladoIzquierdo;
        }

        public void SetLadoIzquierdo(string ladoIzq)
        {
            this.ladoIzquierdo = ladoIzq;
        }
    }
}
