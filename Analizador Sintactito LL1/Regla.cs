using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Sintactito_LL1
{
    class Regla
    {
        private string ladoDerecho;
        private string ladoIzquierdo;

        public Regla(string ladoDerecho, string ladoIzquierdo)
        {
            this.ladoDerecho = ladoDerecho;
            this.ladoIzquierdo = ladoIzquierdo;
        }

        public string getLadoDerecho()
        {
            return this.ladoDerecho;
        }

        public void setLadoDerecho(string ladoDer)
        {
            this.ladoDerecho = ladoDer;
        }

        public string getLadoIzquierdo()
        {
            return this.ladoIzquierdo;
        }

        public void setLadoIzquierdo(string ladoIzq)
        {
            this.ladoIzquierdo = ladoIzq;
        }
    }
}
