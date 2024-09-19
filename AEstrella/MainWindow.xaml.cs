using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AEstrella
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var mapa = new bool[,] 
            { 
                {
                    true, true,true,true,true 
                },
                {
                    true, true,true,true,true
                },{
                    true, true,false,true,true
                },{
                    true, true,true,true,true
                },{
                    true, true,true,true,true
                }
            };


            var AEstrella = new AEstrella(5,5,mapa);
            var inicial = AEstrella.BuscarRuta(AEstrella._nodos[0, 0], AEstrella._nodos[4,4]);
        }
    }
}