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
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        private TempWindow window;

        public Filter(TempWindow tw)
        {
            InitializeComponent();
            window = tw;
        }

        private void filter(object sender, RoutedEventArgs e)
        {
            Message.Content = "";
            List<string> criteria = new List<string>();
            int i = 0;
            if ((bool)(radioButtonInside.IsChecked))
            {
                criteria.Add("obnovljiv"); i++;
            }
            if ((bool)(Importance.IsChecked))
            {
                criteria.Add("vazan"); i++;
            }
            if ((bool)(AbleToExploate.IsChecked))
            {
                criteria.Add("exp"); i++;
            }

            if ((bool)(Merica.IsChecked))
            {
                criteria.Add("merica"); i++;
            }
            if ((bool)(Tona.IsChecked))
            {
                criteria.Add("tona"); i++;
            }
            if ((bool)(Kilogram.IsChecked))
            {
                criteria.Add("kilogram"); i++;
            }
            if ((bool)(Barel.IsChecked))
            {
                criteria.Add("barel"); i++;
            }

            if ((bool)(Redak.IsChecked))
            {
                criteria.Add("redak"); i++;
            }
            if ((bool)(Cest.IsChecked))
            {
                criteria.Add("cest"); i++;
            }
            if ((bool)(Univerzalan.IsChecked))
            {
                criteria.Add("univerzalan"); i++;
            }
            if (i == 0)
            {
                Message.Content = "Štiklirajte bar jedno od ponuđenih polja.";
                return;
            }
            List<Resource> res = window.database.filter(criteria);
            if (res.Count() > 0)
            {
                window.ResourcePins_Draw2(res);
                this.Close();
            }
            else
            {
                Message.Content = "Nema resursa koji isunjavaju neki od kriterijuma.";
            }
        }
    }
}
