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
    /// Interaction logic for IdSearch.xaml
    /// </summary>
    public partial class IdSearch : Window
    {
        private TempWindow window;

        public IdSearch(TempWindow tw)
        {
            InitializeComponent();
            window = tw;
            autoCompleteBoxId.DataContext = window.database;
        }

        private void idSearch(object sender, RoutedEventArgs e)
        {
            Message.Content = "";
            Resource resource = new Resource();
            List<Resource> resources = new List<Resource>();
            if (autoCompleteBoxId.Text != "")
            {
                resource = window.database.GetResource(autoCompleteBoxId.Text);
                if (resource != null)
                {
                    resources.Add(resource);
                    window.ResourcePins_Draw2(resources);
                    this.Close();
                }
                else
                {
                    Message.Content = "Nema resursa sa ovim ID-ijem.";
                }
            }
            else
            {
                Message.Content = "Molimo unesite ID resursa.";
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
