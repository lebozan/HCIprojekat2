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

        private void worldButton_Click(object sender, RoutedEventArgs e)
        {

            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string path = System.IO.Path.Combine(currentDirectory, "Maps/world_map.png");
            TempWindow tag = new TempWindow("WORLD");

            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(path, UriKind.Relative));

            tag.Map.Background = imgB;
            tag.Show();
        }

        private void europeButton_Click(object sender, RoutedEventArgs e)
        {

            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string path = System.IO.Path.Combine(currentDirectory, "Maps/europe_map.jpg");
            TempWindow tag = new TempWindow("EUROPE");

            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(path, UriKind.Relative));

            tag.Map.Background = imgB;
            tag.Show();
        }

        private void americaButton_Click(object sender, RoutedEventArgs e)
        {

            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string path = System.IO.Path.Combine(currentDirectory, "Maps/south_america_map.jpg");
            TempWindow tag = new TempWindow("AMERICA");

            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(path, UriKind.Relative));

            tag.Map.Background = imgB;
            tag.Show();
        }

        private void asiaButton_Click(object sender, RoutedEventArgs e)
        {

            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string path = System.IO.Path.Combine(currentDirectory, "Maps/asia_map.jpg");
            TempWindow tag = new TempWindow("ASIA");

            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(path, UriKind.Relative));

            tag.Map.Background = imgB;
            tag.Show();
        }
    }
}