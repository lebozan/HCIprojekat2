
using Microsoft.Win32;
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
    /// Interaction logic for AddResource.xaml
    /// </summary>
    public partial class AddResource : Window
    {
        public TempWindow tw { get; set; }
        private Resource resource;
        public Resource Resource
        {
            get { return resource; }
            set
            {
                if (value != resource)
                {
                    resource = value;
                    OnPropertyChanged("Resource");
                }
            }
        }

        private ObservableCollection<ResourceTag> selectedTags;
        public ObservableCollection<ResourceTag> SelectedTags
        {
            get { return selectedTags; }
            set
            {
                if (value != selectedTags)
                {
                    selectedTags = value;
                    OnPropertyChanged("Tags");
                }
            }
        }
        public List<ResourceTag> ChosenTags { get; set; }
        public bool idError;
        private bool nameError;
        private bool descriptionError;
        private bool publicError;
        private bool priceError;
        public AddResource(TempWindow t)
        {
            tw = t;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            Resource = new Resource();

            Resource.X = -1;
            Resource.Y = -1;

            autoCompleteBoxTypes.DataContext = tw.database;
            // autoCompleteBoxTags.DataContext = Database.getInstance();

            DataContext = Resource;

            selectedTags = new ObservableCollection<ResourceTag>();

            // comboBoxTags.DataContext = this;

            idError = false;
            nameError = false;
            descriptionError = false;
            publicError = false;
            priceError = false;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // Force revalidation
            idError = false; nameError = false; descriptionError = false; publicError = false;
            textBoxId.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxDescription.GetBindingExpression(TextBox.TextProperty).UpdateSource();


            // Type validation
            if (string.IsNullOrWhiteSpace(autoCompleteBoxTypes.Text)
                || tw.database.GetType(autoCompleteBoxTypes.Text) == null)
            {
                textBoxTypeError.Visibility = System.Windows.Visibility.Visible;
                autoCompleteBoxTypes.Focus();
                return;
            }

            if (idError == false &&
                nameError == false &&
                descriptionError == false &&
                publicError == false && priceError == false)
            {
                resource.Type = tw.database.GetType(autoCompleteBoxTypes.Text);


                // Set the default type icon
                if (string.IsNullOrEmpty(textBoxIconPath.Text) || string.IsNullOrWhiteSpace(textBoxIconPath.Text))
                {
                    resource.IconPath = resource.Type.IconPath;
                }
                Console.WriteLine("duzina liste tagova");
                Console.WriteLine(SelectedTags.Count());


                // Resource.Tags = new ObservableCollection<ResourceTag>(SelectedTags);
                tw.database.AddResource(resource);
                String ids = "";
                foreach (ResourceTag rt in Resource.Tags)
                {

                }

                Close();
                tw.addToResourcesToShow();
            }

        }
        private void textBoxPrice_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                priceError = true;
        }
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void loadIcon_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg,*.ico)|*.ico;*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                textBoxIconPath.Text = dialog.FileName;
            }
        }

        private void autoCompleteBoxTag_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.Key == Key.Enter)
            {
                if (Database.GetTag(autoCompleteBoxTags.Text) == null)
                {
                    buttonAddNewTag_Click(null, null);
                }
            }
            */
        }

        private void buttonAddNewTag_Click(object sender, RoutedEventArgs e)
        {

        }
        private void buttonAddNewType_Click(object sender, RoutedEventArgs e)
        {

            AddType addType = new AddType(autoCompleteBoxTypes.Text, tw);
            addType.ShowDialog();

            /*
            if (Database.GetResource(autoCompleteBoxTypes.Text) == null)
            {
                AddType addType = new AddType(autoCompleteBoxTypes.Text);
                addType.ShowDialog();
            }
            else
            {
                AddType addType = new AddType();
                addType.ShowDialog();
            }
            */
        }

        private void autoCompleteBoxType_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (tw.database.GetType(autoCompleteBoxTypes.Text) == null)
                {
                    buttonAddNewType_Click(null, null);
                }
            }
        }

        private void autoCompleteBoxTypes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(autoCompleteBoxTypes.Text)
                || tw.database.GetType(autoCompleteBoxTypes.Text) == null)
            {
                // textBoxTypeError.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                //textBoxTypeError.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void autoCompleteBoxTags_LostFocus(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(autoCompleteBoxTypes.Text)
                || tw.database.GetType(autoCompleteBoxTypes.Text) == null)
            {
                // textBoxTypeError.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                /*
                //textBoxTypeError.Visibility = System.Windows.Visibility.Hidden;
                ResourceTag rt = Database.GetTag(autoCompleteBoxTags.Text);
                MessageBox.Show(rt.Id);
                Resource.Tags.Add(rt);
                */
            }

        }

        private void textBoxDescription_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                descriptionError = true;
        }
        private void textBoxName_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                nameError = true;
        }
        private void textBoxId_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                idError = true;
        }

        private void textBoxId_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            if (textBoxId.Text.Length > 0)
                //buttonSave.IsEnabled = true;
            else
                //buttonSave.IsEnabled = false;

    */
        }

        private void textBoxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            if (textBoxId.Text.Length > 0)
                //buttonSave.IsEnabled = true;
            else
                //buttonSave.IsEnabled = false;

    */
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void ButtonTags_Click(object sender, RoutedEventArgs e)
        {
            /*
            SelectTags nt = new SelectTags(ChosenTags);
            nt.ShowDialog();

            if (nt.DialogResult == DialogResult.OK)
            {
                ChosenTags.Clear();
                List<string> ret = nt.GetSelectedTags();
                foreach (string s in ret)
                {
                    if (MainForm.tags.ContainsKey(s))
                    {
                        Tag t = MainForm.tags[s];
                        tags.Add(s, t);
                    }
                }
                lblTag.Text = tags.Count.ToString() + " etiketa";
            }

    */
        }
    }
}
