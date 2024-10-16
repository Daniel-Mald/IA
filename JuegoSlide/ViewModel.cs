using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlideTiles
{
    partial class ViewModel:ObservableObject
    {
        [ObservableProperty]
        static byte[,] tableroActual = new byte[,]
        {
            {0,0 }, {2,2}, {1,2},
            {2,0}, {0,1},{ 1,1},
            {2,1}, {0,2}, {1,0},
        };

        
        Nodo nodoInicial = new() { Tablero = tableroActual, Padre = null };
        
        public void Iniciar()
        {
            List<Nodo> lista =  nodoInicial.GenerarSucesores(nodoInicial)!;
            
            // vamos a autosuicidarnos 

        }
        
        

    }
}
