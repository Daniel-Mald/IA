using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SlideTiles
{
    public class Nodo
    {
        public int G { get; set; } //costo real hasta al actual
        public int H { get; set; }
        public int F { get { return G + H; } }// costo total estimado
        public Nodo? Padre { get; set; }
        public byte[,]? Tablero { get; set; } 
        

        public List<Nodo>? GenerarSucesores(Nodo nodoActual)
        {
            int f ;
            int c = 0 ;
            for ( f = 0; f < 3; f++)
            {
                for ( c = 0; c < 3; c++)
                {
                    if (nodoActual.Tablero[f,c] == 0)
                    {
                        break;
                    }
                }
            }

            List<Nodo> Sucesores = new();
            int nuevaX;
            int nuevaY;
            //Hacia arriba
            if (f > 0)
            {
                byte[,] nuevoTablero = new byte[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        nuevoTablero[i, j] = nodoActual.Tablero[i, j];
                    }
                }

                Nodo nuevo = new()
                {
                    Tablero = nuevoTablero
                };
                Sucesores.Add(nuevo);
            }
            if (f < 2)
            {
                byte[,] nuevoTablero = new byte[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        nuevoTablero[i, j] = nodoActual.Tablero[i, j];
                    }
                }

                Nodo nuevo = new()
                {
                    Tablero = nuevoTablero
                };
                Sucesores.Add(nuevo);

            }
            if (c > 0)
            {
                byte[,] nuevoTablero = new byte[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        nuevoTablero[i, j] = nodoActual.Tablero[i, j];
                    }
                }

                Nodo nuevo = new()
                {
                    Tablero = nuevoTablero
                };
                Sucesores.Add(nuevo);

            }
            if (c < 2)
            {
                byte[,] nuevoTablero = new byte[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        nuevoTablero[i, j] = nodoActual.Tablero[i, j];
                    }
                }

                Nodo nuevo = new()
                {
                    Tablero = nuevoTablero
                };
                Sucesores.Add(nuevo);

            }





            return Sucesores;
        }
        public void calcularSucesores()
        {

        }
        public void Heuristica(Nodo nodoA)
        {
            //la suma de restas absolutas entre
            
            Dictionary<byte, byte[]> meta = new Dictionary<byte, byte[]>()
            {
                { 1, [0, 0] },
                { 2, [0, 1] },
                { 3, [0, 2] },
                { 4, [1, 0] },
                { 5, [1, 1] },
                { 6, [1, 2] },
                { 7, [2, 0] },
                { 8, [2, 1] },
                { 0, [2, 2] }

            };
            //Dictionary<byte, byte[]> meta1 = new Dictionary<byte, byte[]>();
            //meta[1] = new byte[] { 0, 0 };
            //meta[2] = new byte[] { 0, 1 };
            //meta[3] = new byte[] { 0, 2 };
            //meta[4] = new byte[] { 1, 0 };
            //meta[5] = new byte[] { 1, 1 };
            //meta[6] = new byte[] { 1, 2 };
            //meta[7] = new byte[] { 2, 0 };
            //meta[8] = new byte[] { 2, 1 };
            //meta[0] = new byte[] { 2, 2 };
            int resultado = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    resultado += Math.Abs(i - meta[nodoA.Tablero[i, j]][0]) + Math.Abs(j - meta[nodoA.Tablero[i, j]][1]);
                   
                }
            }
            
            string hash = $"{nodoA.Tablero[0,0]}";
            H = resultado;
        }

        public List<Nodo> BuscarRuta(Nodo nodoInicial, Nodo nodoMeta)
        {
            List<Nodo> ruta = new List<Nodo>();
            List<Nodo> abiertos = new List<Nodo>(); 
            List<Nodo> cerrados = new List<Nodo>(); 

            abiertos.Add(nodoInicial);

            while (abiertos.Count > 0)
            {
                
                Nodo nodoActual = abiertos.OrderBy(n => n.F).First();

              
                if (nodoActual.Tablero.Cast<byte>().SequenceEqual(nodoMeta.Tablero.Cast<byte>()))
                {
                    Nodo temp = nodoActual;
                    while (temp != null)
                    {
                        ruta.Add(temp);
                        temp = temp.Padre;
                    }
                    ruta.Reverse(); 
                    return ruta;
                }

                abiertos.Remove(nodoActual);
                cerrados.Add(nodoActual);

                // Generamos sucesores
                List<Nodo> sucesores = nodoActual.GenerarSucesores(nodoActual);

                foreach (Nodo sucesor in sucesores)
                {
                    if (cerrados.Any(n => n.Tablero.Cast<byte>().SequenceEqual(sucesor.Tablero.Cast<byte>())))
                    {
                        continue; 
                    }

                    sucesor.G = nodoActual.G + 1;
                    sucesor.Heuristica(nodoMeta); 
                    sucesor.Padre = nodoActual;

                    
                    Nodo nodoExistente = abiertos.FirstOrDefault(n => n.Tablero.Cast<byte>().SequenceEqual(sucesor.Tablero.Cast<byte>()));
                    if (nodoExistente == null)
                    {
                        abiertos.Add(sucesor);
                    }
                    else if (sucesor.G < nodoExistente.G)
                    {
                        nodoExistente.G = sucesor.G;
                        nodoExistente.Padre = sucesor.Padre;
                    }
                }
            }

            return null;
        }
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}
