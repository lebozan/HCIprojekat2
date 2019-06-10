using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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


        public Resource SelectedResource { get; set; }
        public EditResources(TempWindow t)
        {
            tw = t;
            InitializeComponent();

            SelectedResource = null;
            DataContext = this;

            Resources = tw.database.Resources;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
                Resource resource = new Resource(SelectedResource);
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

    }
}
