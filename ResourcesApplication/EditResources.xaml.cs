using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for EditResources.xaml
    /// </summary>
    public partial class EditResources : Window
    {
        public TempWindow tw { get; set; }
        private ObservableCollection<Resource> resources;
        public ObservableCollection<Resource> Resources
        {
            get { return resources; }
            set
            {
                if (value != resources)
                {
                    resources = value;
                    OnPropertyChanged("Resources");
                }
            }
        }

        public ObservableCollection<Resource> ResourcesForUndo { get; set; }
        public List<int> IndexesForUndo;

        public Resource SelectedResource { get; set; }
        public EditResources(TempWindow t)
        {
            tw = t;
            InitializeComponent();

            SelectedResource = null;
            DataContext = this;

            Resources = tw.database.Resources;
            ResourcesForUndo = new ObservableCollection<Resource>();
            IndexesForUndo = new List<int>();




        }
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedResource != null)
            {
                int index = 0;
                int brojac = -1;
                foreach (Resource r in Resources)
                {
                    brojac++;
                    if (r.Id.Equals(SelectedResource.Id))
                    {
                        index = brojac;
                    }
                }
                IndexesForUndo.Add(index);
                Resource resource = new Resource(SelectedResource);
                ResourcesForUndo.Add(resource);
                EditResource editResource = new EditResource(SelectedResource.Id, tw);
                editResource.Show();
            }
            else
            {
                MessageBox.Show("Molimo, odaberite resurs za ažuriranje", "Ažuriranje resursa");
            }
        }
        private void resourcesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (SelectedResource != null)
            {
                buttonEdit.IsEnabled = true;

            }

        }

        private void resourcesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //buttonEdit_Click(null, null);
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
            if (ResourcesForUndo.Count() != 0)
            {
                int position = IndexesForUndo.Count() - 1;

                Resource resource = ResourcesForUndo.ElementAt(ResourcesForUndo.Count() - 1);
                ResourcesForUndo.RemoveAt(ResourcesForUndo.Count() - 1);
                int positionForInsert = IndexesForUndo.ElementAt(position);
                Resources.Insert(positionForInsert, resource);
                Resources.RemoveAt(positionForInsert + 1);
                IndexesForUndo.RemoveAt(position);
                tw.database.SaveResources();

            }
        }
    }
}
