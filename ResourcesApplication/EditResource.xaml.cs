using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ResourcesApplication.Beans;
using Microsoft.Win32;

namespace ResourcesApplication
{
    /// <summary>
    /// Interaction logic for EditResource.xaml
    /// </summary>
    public partial class EditResource : Window
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

        private string oldId;

        private bool idError;
        private bool nameError;
        private bool descriptionError;
        private bool publicError;
        private bool priceError;
        public EditResource(string resourceId, TempWindow t)
        {


            tw = t;
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            oldId = resourceId;
            Resource = new Resource(tw.database.GetResource(resourceId));
            DataContext = Resource;

            autoCompleteBoxTypes.DataContext = tw.database;
            autoCompleteBoxTags.DataContext = tw.database.Tags;
            Database d = tw.database;
            SelectedTags = new ObservableCollection<ResourceTag>();


            foreach (var tag in Resource.Tags)
            {
                SelectedTags.Add(tag);
            }

            foreach (var typeDatabase in tw.database.Types)
            {
                if (Resource.Type.Id != null)
                {
                    if (Resource.Type.Id.Equals(typeDatabase.Id))
                    {
                        autoCompleteBoxTypes.Text = typeDatabase.Id;
                    }
                }
            }

            idError = false;
            nameError = false;
            descriptionError = false;
            publicError = false;
            priceError = false;


        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            idError = false; nameError = false; descriptionError = false; publicError = false;
            textBoxId.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxDescription.GetBindingExpression(TextBox.TextProperty).UpdateSource();


            // Type validation
            if (string.IsNullOrWhiteSpace(autoCompleteBoxTypes.Text)
                || tw.database.GetType(autoCompleteBoxTypes.Text) == null)
            {
                textBoxTypeError.Visibility = System.Windows.Visibility.Visible;
                autoCompleteBoxTypes.Text = "";
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

                Resource.Tags = new ObservableCollection<ResourceTag>(SelectedTags);
                tw.database.UpdateResource(oldId, resource);
                Close();
                tw.addToResourcesToShow();
            }

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
            if (e.Key == Key.Enter)
            {
                buttonAddNewTag_Click(null, null);
            }
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

        private void textBoxPrice_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                priceError = true;
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
