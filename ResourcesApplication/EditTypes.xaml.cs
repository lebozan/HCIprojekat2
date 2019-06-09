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
    /// Interaction logic for EditTypes.xaml
    /// </summary>
    public partial class EditTypes : Window
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
        public List<int> IndexesForUndo;
        public EditTypes(TempWindow t)
        {
            tw = t;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SelectedType = null;
            DataContext = this;
            tw.database.loadData();
            Types = tw.database.Types;
            TypesForUndo = new ObservableCollection<ResourceType>();
            IndexesForUndo = new List<int>();
        }


        private void typesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            buttonEditt_Click(null, null);
        }



        private void buttonEditt_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedType != null)
            {
                ResourceType rt = new ResourceType(SelectedType);
                TypesForUndo.Add(rt);

                int index = 0;
                int brojac = -1;
                foreach (ResourceType typee in Types)
                {
                    brojac++;
                    if (typee.Id.Equals(rt.Id))
                    {
                        index = brojac;
                    }
                }
                IndexesForUndo.Add(index);

                EditType editType = new EditType(SelectedType.Id, tw);
                editType.Show();
            }
            else
            {
                MessageBox.Show("Molimo, odaberite tip resursa za ažuriranje", "Ažuriranje tipa resursa");
            }
        }
        private void typesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedType != null)
            {
                buttonEdit.IsEnabled = true;

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
                int position = IndexesForUndo.Count() - 1;

                ResourceType type = TypesForUndo.ElementAt(TypesForUndo.Count() - 1);
                TypesForUndo.RemoveAt(TypesForUndo.Count() - 1);
                int positionForInsert = IndexesForUndo.ElementAt(position);
                Types.Insert(positionForInsert, type);
                Types.RemoveAt(positionForInsert + 1);
                IndexesForUndo.RemoveAt(position);
                tw.database.SaveTypes();

            }
        }
    }
}
