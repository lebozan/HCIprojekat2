using System;
using System.Collections.Generic;
using System.Linq;

using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ResourcesApplication.Beans;
using System.Windows.Shapes;


namespace ResourcesApplication
{
    /// <summary>
    /// Interaction logic for ShowTags.xaml
    /// </summary>
    public partial class ShowTags : Window, INotifyPropertyChanged
    {
        public TempWindow tw { get; set; }
        private ObservableCollection<ResourceTag> tags;
        public ObservableCollection<ResourceTag> Tags
        {
            get { return tags; }
            set
            {
                if (value != tags)
                {
                    tags = value;
                    OnPropertyChanged("Tags");
                }
            }
        }

        public ResourceTag SelectedTag { get; set; }
        public ShowTags(TempWindow t)
        {
            tw = t;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            SelectedTag = null;
            DataContext = this;
            Console.WriteLine("hejj");
            tw.database.loadData();
            Tags = tw.database.Tags;
            Console.WriteLine(Tags.Count());

        }
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {


            if (SelectedTag != null)
            {
                EditTag editTag = new EditTag(SelectedTag.Id, tw);
                editTag.Show();
            }
            else
            {
                MessageBox.Show("Molimo, odaberite etiketu za ažuriranje", "Ažuriranje etikete");
            }

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete button clicked");
            /*
            if (SelectedTag != null)
            {
                if (resourcesHaveTag(SelectedTag.Id))
                {
                    DeleteTag dialog = new DeleteTag(SelectedTag.Id);
                    dialog.ShowDialog();
                }
                else
                {
                    Database.DeleteTag(SelectedTag);
                    SelectedTag = null;
                }
            }
            else
            {
                MessageBox.Show("Molimo, odaberite etiketu za brisanje", "Brisanje etikete");
            }
            */
        }

        private bool resourcesHaveTag(string Id)
        {
            foreach (var res in tw.database.Resources)
            {
                foreach (var tag in res.Tags)
                {
                    if (tag.Id.Equals(Id))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private void tagsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (SelectedTag != null)
            {
                //buttonEdit.IsEnabled = true;
                //buttonDelete.IsEnabled = true;
            }

        }

        private void tagsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            buttonEdit_Click(null, null);
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
