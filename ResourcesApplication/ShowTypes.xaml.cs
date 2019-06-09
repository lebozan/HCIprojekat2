using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for ShowTypes.xaml
    /// </summary>
    public partial class ShowTypes : Window
    {
        public TempWindow tw { get; set; }
        public ResourceType SelectedType { get; set; }
        private ObservableCollection<ResourceType> types;
        public ObservableCollection<ResourceType> Types
        {
            get { return types; }
            set
            {
                if (value != types)
                {
                    types = value;
                    OnPropertyChanged("Types");
                }
            }
        }
        public ShowTypes(TempWindow t)
        {
            tw = t;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SelectedType = null;
            DataContext = this;
            tw.database.loadData();
            Types = tw.database.Types;
        }


        private void typesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //buttonEdit_Click(null, null);
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button delete clicked");
            /*
            int counter = 0;
            ObservableCollection<Manifestation> manifestations = Database.getInstance().Manifestations;
            if (SelectedType != null)
            {
                foreach (Manifestation manifestation in manifestations)
                {
                    if (manifestation.Type.Id.Equals(SelectedType.Id))
                    {
                        counter++;
                    }
                }

                if (counter > 0)
                {
                    DeleteType handler = new DeleteType(SelectedType);
                    handler.ShowDialog();
                }
                else
                {
                    Database.DeleteType(SelectedType);
                    SelectedType = null;
                }
            }
            else
            {
                MessageBox.Show("Molimo, odaberite tip manifestacije za brisanje", "Brisanje tipa manifestacije");
            }
            */
        }


        private void typesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedType != null)
            {

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
