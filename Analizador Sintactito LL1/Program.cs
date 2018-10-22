using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Sintactico_LL1
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
            Console.OutputEncoding = Encoding.UTF8;
            Program P = new Program();
            Console.ReadKey();
        }

        public Program()
        {
            reglas = new List<Regla>();
            /*reglas.Add(new Regla("S", "Aa"));
            reglas.Add(new Regla("A", "BD"));
            reglas.Add(new Regla("B", "b"));
            reglas.Add(new Regla("B", "€"));
            reglas.Add(new Regla("D", "d"));
            reglas.Add(new Regla("D", "€"));*/
            /*reglas.Add(new Regla("E", "TR"));
            reglas.Add(new Regla("R", "+TR"));
            reglas.Add(new Regla("R", "€"));
            reglas.Add(new Regla("T", "FY"));
            reglas.Add(new Regla("Y", "*FY"));
            reglas.Add(new Regla("Y", "€"));
            reglas.Add(new Regla("F", "(E)"));
            reglas.Add(new Regla("F", "i"));*/
            reglas.Add(new Regla("E", "TR"));
            reglas.Add(new Regla("R", "+TR"));
            reglas.Add(new Regla("R", "-TR"));
            reglas.Add(new Regla("R", "€"));
            reglas.Add(new Regla("T", "FY"));
            reglas.Add(new Regla("Y", "*FY"));
            reglas.Add(new Regla("Y", "/FY"));
            reglas.Add(new Regla("Y", "€"));
            reglas.Add(new Regla("F", "(E)"));
            reglas.Add(new Regla("F", "n"));
            reglas.Add(new Regla("F", "i"));

            primeros = new List<string>();
            /*primeros.Add("S->b,d,a");
            primeros.Add("A->b,d,€");
            primeros.Add("B->b,€");
            primeros.Add("D->d,€");*/
            /*primeros.Add("E->(,i");
            primeros.Add("R->+,€");
            primeros.Add("T->(,i");
            primeros.Add("Y->*,€");
            primeros.Add("F->(,i");*/
            primeros.Add("E->(,n,i");
            primeros.Add("R->+,-,€");
            primeros.Add("T->(,n,i");
            primeros.Add("Y->*,/,€");
            primeros.Add("F->(,n,i");

            siguientes = new List<string>();
            /*siguientes.Add("S->$");
            siguientes.Add("A->a");
            siguientes.Add("B->a,d");
            siguientes.Add("D->a");*/
            /*siguientes.Add("E->$,)");
            siguientes.Add("R->$,)");
            siguientes.Add("T->+,$,)");
            siguientes.Add("Y->+,$,)");
            siguientes.Add("F->*,+,$,)");*/
            siguientes.Add("E->$,)");
            siguientes.Add("R->$,)");
            siguientes.Add("T->+,-,$,)");
            siguientes.Add("Y->+,-,$,)");
            siguientes.Add("F->+,/,*,-,$,)");


            terminales = new List<string>();
            /*terminales.Add("a");
            terminales.Add("b");
            terminales.Add("d");*/
            /*terminales.Add("i");
            terminales.Add("+");
            terminales.Add("*");
            terminales.Add("(");
            terminales.Add(")");*/
            terminales.Add("+");
            terminales.Add("-");
            terminales.Add("*");
            terminales.Add("/");
            terminales.Add("(");
            terminales.Add(")");
            terminales.Add("n");
            terminales.Add("i");


            noTerminales = new List<string>();
            /*noTerminales.Add("S");
            noTerminales.Add("A");
            noTerminales.Add("B");
            noTerminales.Add("D");*/
            /*noTerminales.Add("E");
            noTerminales.Add("R");
            noTerminales.Add("T");
            noTerminales.Add("Y");
            noTerminales.Add("F");*/
            noTerminales.Add("E");
            noTerminales.Add("R");
            noTerminales.Add("T");
            noTerminales.Add("Y");
            noTerminales.Add("F");

            tabla = new string[noTerminales.Count + 1, terminales.Count + 2];

            InicializarTabla();
            RellenarTabla();
            MostrarMatriz();

            Console.WriteLine("Fin");
        }

        public void InicializarTabla()
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    tabla[i, j] = "";
                }
            }

            int contador = 0;
            int noTerm = 0;

            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (i == 0 && j >= 1)
                    {
                        if (contador == terminales.Count)
                        {
                            tabla[i, j] = "$";
                        }
                        else
                        {
                            if (contador < terminales.Count)
                            {
                                tabla[i, j] = terminales[contador].ToString();
                                contador++;
                            }
                        }
                    }
                    else if (i > 0 && j == 0)
                    {
                        tabla[i, j] = noTerminales[noTerm];
                        noTerm++;
                    }
                }
            }
        }

        public void MostrarMatriz()
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    Console.Write(tabla[i, j] + " | ");
                }
                Console.WriteLine();
            }
        }

        public void RellenarTabla()
        {
            List<string> prim = new List<string>();
            List<string> noTerminalesPrimeros = new List<string>();
            List<string> noTerminalesSiguientes = new List<string>();
            List<string> listaDeLosSiguientes = new List<string>();

            int numeroColumna = 0;
            int numeroFila = 0;

            foreach (string primero in primeros)
            {
                string p = primero.Substring(3, primero.Length - 3);
                string noTermPrimeros = primero.Substring(0, 1);
                prim.Add(p);
                noTerminalesPrimeros.Add(noTermPrimeros);
            }

            foreach (string siguiente in siguientes)
            {
                string s = siguiente.Substring(0, 1);
                string noTermSiguientes = siguiente.Substring(3, siguiente.Length - 3);
                noTerminalesSiguientes.Add(s);
                listaDeLosSiguientes.Add(noTermSiguientes);
            }


            foreach (Regla regla in reglas)
            {
                if (regla.GetLadoDerecho()[0].Equals('€'))
                {
                    for (int k = 0; k < noTerminalesSiguientes.Count; k++)
                    {
                        if (regla.GetLadoIzquierdo().ToString().Equals(noTerminalesSiguientes[k]))
                        {
                            string[] elementosSiguientes = listaDeLosSiguientes[k].Split(',');

                            for (int l = 0; l < elementosSiguientes.Length; l++)
                            {
                                for (int m = 1; m < tabla.GetLength(1); m++)
                                {
                                    if (elementosSiguientes[l].Equals(tabla[0, m]))
                                    {
                                        int i = 0;

                                        for(int n = 0; n < tabla.GetLength(0); n++)
                                        {
                                            if (regla.GetLadoIzquierdo().ToString().Equals(tabla[n,0]))
                                            {
                                                i = n;
                                                break;
                                            }
                                        }

                                        tabla[i, m] = "€";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (Char.IsLetter(regla.GetLadoDerecho()[0]) && regla.GetLadoDerecho()[0].ToString().Equals(regla.GetLadoDerecho()[0].ToString().ToUpper()))
                {
                    for (int i = 0; i < noTerminalesPrimeros.Count; i++)
                    {
                        if (noTerminalesPrimeros[i].Equals(regla.GetLadoDerecho()[0].ToString()))
                        {
                            string[] elementosPrimeros = prim[i].Split(',');

                            for (int j = 0; j < elementosPrimeros.Length; j++)
                            {
                                if (elementosPrimeros[j].Equals("€"))
                                {
                                    for (int k = 0; k < noTerminalesSiguientes.Count; k++)
                                    {
                                        if (regla.GetLadoDerecho()[0].ToString().Equals(noTerminalesSiguientes[k]))
                                        {
                                            string[] elementosSiguientes = listaDeLosSiguientes[k].Split(',');

                                            for (int l = 0; l < elementosSiguientes.Length; l++)
                                            {
                                                for (int m = 1; m < tabla.GetLength(1); m++)
                                                {
                                                    if (elementosSiguientes[l].Equals(tabla[0, m]))
                                                    {
                                                        bool reglaEpsilon = false;

                                                        for (int n = 0; n < reglas.Count; n++)
                                                        {
                                                            if (reglas[n].GetLadoIzquierdo().Equals(regla.GetLadoIzquierdo()) && reglas[n].GetLadoDerecho().Equals("€"))
                                                            {
                                                                tabla[k, m] = "€";
                                                                reglaEpsilon = true;
                                                                break;
                                                            }
                                                        }

                                                        if (!reglaEpsilon)
                                                        {
                                                            tabla[k, m] = regla.GetLadoDerecho();
                                                        }

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int k = 0; k < tabla.GetLength(1); k++)
                                    {
                                        if (tabla[0,k].Equals(elementosPrimeros[j]))
                                        {
                                            for(int l = 0; l < tabla.GetLength(0); l++)
                                            {
                                                if (tabla[l, 0].Equals(regla.GetLadoIzquierdo()))
                                                {
                                                    tabla[l, k] = regla.GetLadoDerecho();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Al encontrar un terminal en la produccion busca la posicion  en la tabla que le corresponde 
                    for (int i = 0; i < tabla.GetLength(0); i++)
                    {
                        if (i == 0)
                        {
                            for (int j = 1; j < tabla.GetLength(1); j++)
                            {
                                if (regla.GetLadoDerecho()[0].ToString().Equals(tabla[0, j]))
                                {
                                    numeroColumna = j;
                                }
                            }
                        }
                        else
                        {
                            if (regla.GetLadoIzquierdo().ToString().Equals(tabla[i, 0]))
                            {
                                numeroFila = i;
                            }
                        }
                    }

                    tabla[numeroFila, numeroColumna] = regla.GetLadoDerecho();
                }
            }
        }



    }
}
