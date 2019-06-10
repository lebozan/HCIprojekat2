using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ResourcesApplication.Beans;

namespace ResourcesApplication
{
    /// <summary>
    /// Interaction logic for Maps.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Resource resourceForCopy;
        public MainWindow()
        {
            resourceForCopy = null;
            InitializeComponent();
        }

        private void Mapa1Button_Click(object sender, RoutedEventArgs e)
        {

            string trenutni = System.IO.Directory.GetCurrentDirectory();
            string putanja = System.IO.Path.Combine(trenutni, "Maps/world-map-big_01.gif");
            TempWindow tag = new TempWindow("Mapa1");

            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = new BitmapImage(new Uri(putanja, UriKind.Relative));

            tag.Map.Background = imgB;
            tag.Show();
        }

        private void Mapa2Button_Click(object sender, RoutedEventArgs e)
        {

            string trenutni = System.IO.Directory.GetCurrentDirectory();
            string putanja = System.IO.Path.Combine(trenutni, "Maps/world-map-big_02.gif");
            TempWindow tag = new TempWindow("Mapa2");

            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = new BitmapImage(new Uri(putanja, UriKind.Relative));

            tag.Map.Background = imgB;
            tag.Show();
        }

        private void Mapa3Button_Click(object sender, RoutedEventArgs e)
        {

            string trenutni = System.IO.Directory.GetCurrentDirectory();
            string putanja = System.IO.Path.Combine(trenutni, "Maps/world-map-big_03.gif");
            TempWindow tag = new TempWindow("Mapa3");

            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = new BitmapImage(new Uri(putanja, UriKind.Relative));

            tag.Map.Background = imgB;
            tag.Show();
        }

        private void Mapa4Button_Click(object sender, RoutedEventArgs e)
        {

            string trenutni = System.IO.Directory.GetCurrentDirectory();
            string putanja = System.IO.Path.Combine(trenutni, "Maps/world-map-big_04.gif");
            TempWindow tag = new TempWindow("Mapa4");

            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = new BitmapImage(new Uri(putanja, UriKind.Relative));

            tag.Map.Background = imgB;
            tag.Show();
        }

        private void WorldButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AsiaButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}