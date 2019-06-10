using System;
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
    /// Interaction logic for DeleteResources.xaml
    /// </summary>
    public partial class DeleteResources : Window
    {

        public TempWindow tw { get; set; }
        private ObservableCollection<Resource> _resources;

        public ObservableCollection<Resource> Resources
        {
            get { return _resources; }
            set
            {
                if (value != _resources)
                {


                    _resources = value;
                    OnPropertyChanged("Resources");




                }
            }
        }

        public ObservableCollection<Resource> ResourcesForUndo
        {

            get; set;
        }

        public Resource SelectedResource { get; set; }

        public int OldCount { get; set; }
        public int NewCount { get; set; }
        public DeleteResources(TempWindow t)
        {
            tw = t;
            InitializeComponent();

            SelectedResource = null;
            DataContext = this;

            Resources = tw.database.Resources;
            ResourcesForUndo = new ObservableCollection<Resource>();


        }
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Resource forDelete = new Resource(SelectedResource);
                ResourcesForUndo.Add(forDelete);
                tw.database.DeleteResource(forDelete);
                tw.addToResourcesToShow();
                tw.ResourcePins_Draw();

            }


            /*
            DeleteResourceConfirmation d = new DeleteResourceConfirmation(SelectedResource.Id);
            d.Show();
            */


        }
        private void resourcesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (SelectedResource != null)
            {
                buttonDelete.IsEnabled = true;

            }

        }

        private void resourcesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            buttonDelete_Click(null, null);
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            Console.WriteLine("ON PROPERTY CHANGED CALLED");
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));

            }
        }



        private void ButtonUndo_Click(object sender, RoutedEventArgs e)
        {

            if (ResourcesForUndo.Count() != 0)
            {
                Resource resource = ResourcesForUndo.ElementAt(ResourcesForUndo.Count() - 1);
                ResourcesForUndo.RemoveAt(ResourcesForUndo.Count() - 1);
                Resources.Add(resource);
                tw.database.SaveResources();
                tw.addToResourcesToShow();
            }


        }


    }
}
