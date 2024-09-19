using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.NodoAEstrella
{
    public class AEstrella
    {
        readonly int _ancho;
        readonly int _alto;

        readonly Nodo[,] _nodos;

        public AEstrella(int ancho, int alto, bool[,] mapa)
        {
            _alto = alto;
            _ancho = ancho;
            _nodos = new Nodo[ancho, alto];
            for (int i = 0; i < _ancho; i++)
            {
                for (int j = 0; j < _alto; j++)
                {
                    _nodos[i, j] = new Nodo(i, j, mapa[i,j]);
                }
            }
        }
        public int HEURISTICA(Nodo a , Nodo b) =>
            Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

        public List<Nodo> GenerarSucesores(Nodo nodo)
        {
            List<Nodo> sucesores = new List<Nodo>();
            //Nodo sucesor;
            int nuevaX;
            int nuevaY;
            //Hacia arriba
            nuevaX = nodo.X;
            nuevaY = nodo.Y - 1;
            if(nuevaY >= 0)
            {
                sucesores.Add(_nodos[nuevaX,nuevaY]);
            }
            //hacia abajo
            nuevaX = nodo.X;
            nuevaY = nodo.Y + 1;
            if(nuevaY < _alto)
            {
                sucesores.Add(_nodos[nuevaX, nuevaY]);
            }
            //hacia la izquierda
            nuevaX = nodo.X - 1;
            nuevaY = nodo.Y;
            if (nuevaX >= 0)
            {
                sucesores.Add(_nodos[nuevaX, nuevaY]);
            }
            //hacia la derecha
            nuevaX = nodo.X + 1;
            nuevaY = nodo.Y;
            if (nuevaX < _ancho)
            {
                sucesores.Add(_nodos[nuevaX, nuevaY]);
            }


            return sucesores;
        }

        public List<Nodo> BuscarRuta(Nodo origen, Nodo meta)
        {
            List<Nodo> abiertos = new List<Nodo>();
            abiertos.Add(origen);
            HashSet<Nodo> cerrados  = new HashSet<Nodo>();
            origen.G = 0;
            origen.H = HEURISTICA(origen, meta);


        }
    }
}
