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
    /// Interaction logic for TypeSearch.xaml
    /// </summary>
    public partial class TypeSearch : Window
    {
        private TempWindow window;

        public TypeSearch(TempWindow tw)
        {
            InitializeComponent();
            window = tw;
            autoCompleteBoxTypes.DataContext = window.database;
        }

        private void typeSearch(object sender, RoutedEventArgs e)
        {
            Message.Content = "";
            List<Resource> resources = new List<Resource>();
            if (autoCompleteBoxTypes.Text != "")
            {
                resources = window.database.searchType(autoCompleteBoxTypes.Text);
                if (resources.Count() > 0)
                {
                    window.ResourcePins_Draw2(resources);
                    this.Close();
                }
                else
                {
                    Message.Content = "Nema resursa sa ovim tipom.";
                }
            }
            else
            {
                Message.Content = "Molimo odaberite ID tipa.";
            }
        }

        private void autoCompleteBoxType_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

            }
        }

        private void autoCompleteBoxTypes_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}