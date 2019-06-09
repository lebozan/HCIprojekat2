using System;
using System.Collections.Generic;
using System.IO;
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

namespace ResourcesApplication.Html
{
    /// <summary>
    /// Interaction logic for HtmlHelp.xaml
    /// </summary>
    public partial class HtmlHelp : Window
    {
        public HtmlHelp(string key, Window originator)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Console.WriteLine("TRENUTNI FOLDER:"+Directory.GetCurrentDirectory());
            string path = string.Format("{0}/Html/{1}.html", Directory.GetCurrentDirectory(), key);
            Console.WriteLine("OVDE SAM OVO MI JE PUTANJA:"+path);
            if (!File.Exists(path))
                key = "Error";

            Uri url = new Uri(string.Format("file:///{0}/Html/{1}.html", Directory.GetCurrentDirectory(), key));

            HelpBrowser.Navigate(url);
        }
    }
}
