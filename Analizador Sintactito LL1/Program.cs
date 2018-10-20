using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Sintactito_LL1
{
    class Program
    {
        private List<Regla> reglas;
        private List<string> primeros;
        private List<string> siguientes;

        private List<string> terminales;
        private List<string> noTerminales;

        private string[,] tabla;
       
        static void Main(string[] args)
        {
            Program P = new Program();
            P.MostrarMatriz();
            Console.ReadKey();
        }

        public Program()
        {
            reglas = new List<Regla>();
            reglas.Add(new Regla("S","Aa"));
            reglas.Add(new Regla("A", "BD"));
            reglas.Add(new Regla("B", "b"));
            reglas.Add(new Regla("B", "€"));
            reglas.Add(new Regla("D", "d"));
            reglas.Add(new Regla("D", "€"));

            primeros = new List<string>();
            primeros.Add("S->b,d,a");
            primeros.Add("A->b,d,€");
            primeros.Add("B->b,€");
            primeros.Add("D->d,€");

            siguientes = new List<string>();
            siguientes.Add("S->$");
            siguientes.Add("A->a");
            siguientes.Add("B->a,d");
            siguientes.Add("D->a");

            terminales = new List<string>();
            terminales.Add("a");
            terminales.Add("b");
            terminales.Add("d");

            noTerminales = new List<string>();
            noTerminales.Add("S");
            noTerminales.Add("A");
            noTerminales.Add("B");
            noTerminales.Add("D");

            tabla = new string[noTerminales.Count + 1, terminales.Count + 2];

        }

        public void MostrarMatriz()
        {
            int contador = 0;
            int noTerm = 0;

            Console.WriteLine("--- Tabla de analisis sintáctico LL1 ---");
     
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Console.Write("  ");
                    }

                    if (i == 0 && j >= 1)
                    {
                        if (contador == terminales.Count)
                        {
                            tabla[i, j] = "$";
                            Console.WriteLine(tabla[i, j]);
                        }
                        else
                        {
                            if (contador < terminales.Count)
                            {
                                tabla[i, j] = terminales[contador].ToString();
                                contador++;
                                Console.Write(tabla[i, j] + "  ");
                            }
                        }
                    }

                    if (i > 0 && j == 0)
                    {
                        Console.WriteLine(noTerminales[noTerm] + "  ");
                        noTerm++;
                    }
                   
                }
            }
        }

        public 

        public void RellenarTabla()
        {

        }

    }
}
