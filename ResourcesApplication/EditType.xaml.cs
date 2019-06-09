using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using ResourcesApplication.Beans;

namespace ResourcesApplication
{
    /// <summary>
    /// Interaction logic for EditType.xaml
    /// </summary>
    public partial class EditType : Window
    {
        public TempWindow tp { get; set; }
        private ResourceType type;
        public ResourceType Type
        {
            get { return type; }
            set { type = value; }
        }

        private string oldId;
        private bool idError;
        private bool nameError;
        private bool iconPathError;
        private bool descriptionError;
        public EditType(string typeId, TempWindow t)
        {
            tp = t;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            oldId = typeId;
            type = tp.database.GetType(oldId);
            DataContext = type;

            idError = false;
            nameError = false;
            iconPathError = false;
            descriptionError = false;
        }

        private void textBoxName_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                nameError = true;
        }

        private void textBoxIconPath_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                iconPathError = true;
        }

        private void textBoxDescription_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                descriptionError = true;
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg,*.ico)|*.ico;*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                textBoxIconPath.Text = dialog.FileName;
                Type.IconPath = dialog.FileName;
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            idError = false; nameError = false; iconPathError = false; descriptionError = false;
            textBoxId.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxIconPath.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxDescription.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (idError == false &&
                nameError == false &&
                iconPathError == false &&
                descriptionError == false)
            {
                tp.database.UpdateType(oldId, type);
                Close();
            }
        }

        private void textBoxId_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                idError = true;
        }
    }
}
