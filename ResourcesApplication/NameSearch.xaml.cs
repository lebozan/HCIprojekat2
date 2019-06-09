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
    /// Interaction logic for NameSearch.xaml
    /// </summary>
    public partial class NameSearch : Window
    {
        private TempWindow window;

        public NameSearch(TempWindow tw)
        {
            InitializeComponent();
            window = tw;
            autoCompleteBoxName.DataContext = window.database;
        }

        private void NameSearchh(object sender, RoutedEventArgs e)
        {
            Message.Content = "";
            Resource resource = new Resource();
            if (autoCompleteBoxName.Text != "")
            {
                List<Resource> resources = window.database.searchName(autoCompleteBoxName.Text);
                if (resources.Count() > 0)
                {
                    Message.Content = "";
                    window.ResourcePins_Draw2(resources);
                    this.Close();
                }
                else
                {
                    Message.Content = "Nema resursa sa ovim nazivom.";
                }
            }
            else
            {
                Message.Content = "Morate uneti naziv resursa.";
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

