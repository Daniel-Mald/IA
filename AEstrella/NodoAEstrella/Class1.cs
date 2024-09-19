using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.NodoAEstrella
{
    public class Nodo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Bloqueado { get; set; }
        public Nodo Padre { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F { get 
            {
                return G + H;
            } }



        public Nodo(int x , int y , bool bloqueado)
        {
            X = x;
            Y = y;
            Bloqueado = bloqueado;
        }


    }
}
