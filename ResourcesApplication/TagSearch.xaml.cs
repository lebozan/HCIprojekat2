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
    /// Interaction logic for TagSearch.xaml
    /// </summary>
    public partial class TagSearch : Window
    {
        private TempWindow window;

        public TagSearch(TempWindow tw)
        {
            InitializeComponent();
            window = tw;
            autoCompleteBoxTags.DataContext = window.database;
        }

        private void tagSearch(object sender, RoutedEventArgs e)
        {
            Message.Content = "";
            List<Resource> resources = new List<Resource>();
            if (autoCompleteBoxTags.Text != "")
            {
                resources = window.database.searchTag(autoCompleteBoxTags.Text);
                if (resources.Count() > 0)
                {
                    window.ResourcePins_Draw2(resources);
                    this.Close();
                }
                else
                {
                    Message.Content = "Nema resursa sa ovom etiketom.";
                }
            }
            else
            {
                Message.Content = "Molimo odaberite ID etikete.";
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
