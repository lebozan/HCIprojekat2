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
    /// Interaction logic for DeleteTypes.xaml
    /// </summary>
    public partial class DeleteTypes : Window
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
        public ObservableCollection<ResourceType> TypesForUndo { get; set; }

        public DeleteTypes(TempWindow t)
        {
            tw = t;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SelectedType = null;
            DataContext = this;
            tw.database.loadData();
            Types = tw.database.Types;
            TypesForUndo = new ObservableCollection<ResourceType>();

        }


        private void typesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            buttonDelete_Click(null, null);
        }



        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            /*
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Da li ste sigurni? Brisanje tipa ce prouzrokovati brisanje resursa koji poseduju taj tip. Nastavi?", "Upozorenje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ObservableCollection<Resource> resources = Database.getInstance().Resources;

                for (int i = resources.Count - 1; i >= 0; i--)
                {
                    if (resources[i].Type.Id.Equals(SelectedType.Id))
                    {
                        Database.DeleteResource(resources[i]);
                    }
                }
                ResourceType type = new ResourceType(SelectedType);
                TypesForUndo.Add(type);
                Database.DeleteType(SelectedType);

            }

    */

        }
        private void typesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedType != null)
            {
                ButtonObrisi.IsEnabled = true;

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

        private void ButtonUndo_Click(object sender, RoutedEventArgs e)
        {

            if (TypesForUndo.Count() != 0)
            {
                ResourceType type = TypesForUndo.ElementAt(TypesForUndo.Count() - 1);
                TypesForUndo.RemoveAt(TypesForUndo.Count() - 1);
                Types.Add(type);
                tw.database.SaveTypes();
            }
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedType != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Da li ste sigurni? Brisanje tipa ce prouzrokovati brisanje resursa koji poseduju taj tip. Nastavi?", "Upozorenje", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    ObservableCollection<Resource> resources = tw.database.Resources;

                    for (int i = resources.Count - 1; i >= 0; i--)
                    {
                        if (resources[i].Type.Id.Equals(SelectedType.Id))
                        {
                            tw.database.DeleteResource(resources[i]);
                        }
                    }
                    ResourceType type = new ResourceType(SelectedType);
                    TypesForUndo.Add(type);
                    tw.database.DeleteType(SelectedType);

                }
            }
            else
            {
                MessageBox.Show("Molimo, odaberite resurs za brisanje", "Brisanje resursa");
            }
        }

        private void ButtonOpozovi_Click(object sender, RoutedEventArgs e)
        {
            if (TypesForUndo.Count() != 0)
            {
                ResourceType type = TypesForUndo.ElementAt(TypesForUndo.Count() - 1);
                TypesForUndo.RemoveAt(TypesForUndo.Count() - 1);
                Types.Add(type);
                tw.database.SaveTypes();
            }
        }
    }
}
