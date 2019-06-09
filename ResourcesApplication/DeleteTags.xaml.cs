using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for DeleteTags.xaml
    /// </summary>
    public partial class DeleteTags : Window
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
        public ObservableCollection<ResourceTag> TagsForUndo { get; set; }
        public List<int> IndexesForUndo;
        public DeleteTags(TempWindow t)
        {
            tw = t;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            SelectedTag = null;
            DataContext = this;

            tw.database.loadData();
            Tags = tw.database.Tags;
            TagsForUndo = new ObservableCollection<ResourceTag>();
            IndexesForUndo = new List<int>();

        }
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            ResourceTag rt = new ResourceTag(SelectedTag);
            TagsForUndo.Add(rt);

            int index = 0;
            int brojac = -1;
            foreach (ResourceTag tag in Tags)
            {
                brojac++;
                if (tag.Id.Equals(rt.Id))
                {
                    index = brojac;
                }
            }
            IndexesForUndo.Add(index);

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
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Brisanje etikete ce prouzrokovati brisanje i manifetacija koje je poseduju. Nastavi?", "Upozorenje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ObservableCollection<Resource> resources = tw.database.Resources;

                for (int i = resources.Count - 1; i >= 0; i--)
                {
                    if (resources[i].Type.Id.Equals(SelectedTag.Id))
                    {
                        tw.database.DeleteResource(resources[i]);
                    }
                }
                ResourceTag tag = new ResourceTag(SelectedTag);
                TagsForUndo.Add(tag);
                tw.database.DeleteTag(SelectedTag);

            }
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
                buttonDelete.IsEnabled = true;

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

        private void ButtonUndo_Click(object sender, RoutedEventArgs e)
        {
            if (TagsForUndo.Count() != 0)
            {
                ResourceTag tag = TagsForUndo.ElementAt(TagsForUndo.Count() - 1);
                TagsForUndo.RemoveAt(TagsForUndo.Count() - 1);
                Tags.Add(tag);
                tw.database.SaveTags();
            }
        }
    }
}
