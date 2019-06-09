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
    /// Interaction logic for ShowResources.xaml
    /// </summary>
    public partial class ShowResources : Window, INotifyPropertyChanged
    {
        public TempWindow tw { get; set; }

        private ObservableCollection<Resource> resources;
        public ObservableCollection<Resource> Resourcess
        {
            get { return resources; }
            set
            {
                if (value != resources)
                {
                    resources = value;
                    OnPropertyChanged("Resourcess");
                }
            }
        }

        public Resource SelectedResource { get; set; }

        public DateTime fromDate;
        public DateTime FromDate
        {
            get { return fromDate; }
            set
            {
                if (value != fromDate)
                {
                    fromDate = value;
                    OnPropertyChanged("FromDate");
                }
            }
        }

        public DateTime toDate;
        public DateTime ToDate
        {
            get { return toDate; }
            set
            {
                if (value != toDate)
                {
                    toDate = value;
                    OnPropertyChanged("ToDate");
                }
            }
        }
        public ShowResources(TempWindow t)
        {
            tw = t;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SelectedResource = null;
            DataContext = this;

            Resourcess = tw.database.Resources;
            comboBoxType.DataContext = tw.database;
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
        }

        private void resourcesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void resourcesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //buttonEdit_Click(null, null);
        }

        private void searchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonSearch_Click(null, null);
            }
        }
        private ObservableCollection<Resource> filterDate(ObservableCollection<Resource> resources)
        {
            var replace = new ObservableCollection<Resource>();

            foreach (var data in resources)
            {
                int result = DateTime.Compare(fromDate, toDate);
                if (result <= 0)
                {
                    int compareFrom = DateTime.Compare(fromDate, data.Date);
                    int compareTo = DateTime.Compare(data.Date, toDate);
                    if (compareFrom <= 0 && compareTo <= 0)
                    {
                        replace.Add(new Resource(data));
                    }
                }
            }
            return replace;
        }
        private ObservableCollection<Resource> filterRenewable(ObservableCollection<Resource> resources, bool value)
        {
            var replace = new ObservableCollection<Resource>();

            foreach (var data in resources)
            {
                if (data.Renewable == value)
                {
                    replace.Add(new Resource(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Resource> filterImportance(ObservableCollection<Resource> resources, bool value)
        {
            var replace = new ObservableCollection<Resource>();

            foreach (var data in resources)
            {
                if (data.Importance == value)
                {
                    replace.Add(new Resource(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Resource> filterAbleToExploate(ObservableCollection<Resource> resources, bool value)
        {
            var replace = new ObservableCollection<Resource>();

            foreach (var data in resources)
            {
                if (data.AbleToExploate == value)
                {
                    replace.Add(new Resource(data));
                }
            }
            return replace;
        }
        private ObservableCollection<Resource> filterId(ObservableCollection<Resource> resources, bool value)
        {
            var replace = new ObservableCollection<Resource>();

            foreach (var data in resources)
            {
                if (data.Id.Equals(searchInputId.Text) && value == true)
                {
                    replace.Add(new Resource(data));
                }
                /*
                if (!data.Id.Contains(searchInputId.Text) && value == false)
                {
                    replace.Add(new Resource(data));
                }*/
            }

            return replace;
        }

        private ObservableCollection<Resource> filterName(ObservableCollection<Resource> resources, bool value)
        {
            var replace = new ObservableCollection<Resource>();

            foreach (var data in resources)
            {
                if (data.Name.ToUpper().Contains(searchInputName.Text.ToUpper()) && value == true)
                {
                    replace.Add(new Resource(data));
                }
                else if (!data.Name.Contains(searchInputName.Text) && value == false)
                {
                    replace.Add(new Resource(data));
                }
            }
            return replace;
        }
        private ObservableCollection<Resource> filterFrequency(ObservableCollection<Resource> resources)
        {
            var replace = new ObservableCollection<Resource>();
            Resource r = resources.ElementAt(0);

            foreach (var data in resources)
            {
                if (data.Frequency != null)
                {
                    if (data.Frequency.Equals(comboBoxFrequency.Text))
                    {
                        replace.Add(new Resource(data));
                    }
                }
            }
            return replace;
        }

        private ObservableCollection<Resource> filterJedinicaMere(ObservableCollection<Resource> resources)
        {
            var replace = new ObservableCollection<Resource>();

            foreach (var data in resources)
            {
                if (data.MeasurementUnit != null)
                {
                    if (data.MeasurementUnit.Equals(comboBoxJedinicaMere.Text))
                    {
                        replace.Add(new Resource(data));
                    }
                }
            }
            return replace;
        }

        private ObservableCollection<Resource> filterType(ObservableCollection<Resource> resources)
        {
            var replace = new ObservableCollection<Resource>();

            foreach (var data in resources)
            {
                if (data.Type != null)
                {
                    if (data.Type.Id.Equals(comboBoxType.Text))
                    {
                        replace.Add(new Resource(data));
                    }
                }
            }
            return replace;
        }

        private ObservableCollection<Resource> filterCenaOd(ObservableCollection<Resource> resources)
        {
            var replace = new ObservableCollection<Resource>();

            foreach (var data in resources)
            {
                if (data.Price != null)
                {
                    if (data.Price >= int.Parse(CenaOd.Text))
                    {
                        replace.Add(new Resource(data));
                    }
                }
            }
            return replace;
        }
        private ObservableCollection<Resource> filterCenaDo(ObservableCollection<Resource> resources)
        {
            var replace = new ObservableCollection<Resource>();

            foreach (var data in resources)
            {
                if (data.Price != null)
                {
                    if (data.Price <= int.Parse(CenaDo.Text))
                    {
                        replace.Add(new Resource(data));
                    }
                }
            }
            return replace;
        }
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            buttonSearch.IsEnabled = false;

            var result = new ObservableCollection<Resource>();
            result = tw.database.Resources;
            if (DateTime.Compare(fromDate, toDate) != 0)
            {
                result = filterDate(result);
            }
            if (CheckBoxReDa.IsChecked == true)
            {
                result = filterRenewable(result, true);
            }
            if (CheckBoxReNe.IsChecked == true)
            {
                result = filterRenewable(result, false);
            }
            if (checkBoxImportanceDa.IsChecked == true)
            {
                result = filterImportance(result, true);
            }
            if (checkBoxImportanceNe.IsChecked == true)
            {
                result = filterImportance(result, false);
            }
            if (CheckBoxEkspDa.IsChecked == true)
            {
                result = filterAbleToExploate(result, true);
            }
            if (CheckBoxEkspNe.IsChecked == true)
            {
                result = filterAbleToExploate(result, false);
            }
            if (CenaOd.Text != "")
            {
                result = filterCenaOd(result);
            }
            if (CenaDo.Text != "")
            {
                result = filterCenaDo(result);
            }



            if (!string.IsNullOrWhiteSpace(searchInputId.Text))
            {

                result = filterId(result, true);
            }
            if (!string.IsNullOrWhiteSpace(searchInputName.Text))
            {
                result = filterName(result, true);
            }
            if (!comboBoxFrequency.Text.Equals(""))
            {

                result = filterFrequency(result);
            }
            if (!comboBoxJedinicaMere.Text.Equals(""))
            {
                result = filterJedinicaMere(result);
            }
            if (!string.IsNullOrWhiteSpace(comboBoxType.Text))
            {
                result = filterType(result);
            }

            Resourcess = result;




        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {

            Resourcess = tw.database.Resources;

            searchInputId.Text = "";
            searchInputName.Text = "";
            comboBoxFrequency.SelectedIndex = 0;
            comboBoxJedinicaMere.SelectedIndex = 0;
            comboBoxType.SelectedValue = null;
            CheckBoxReDa.IsChecked = false;
            CheckBoxReNe.IsChecked = false;
            CheckBoxReDa.IsEnabled = true;
            CheckBoxReNe.IsEnabled = true;
            checkBoxImportanceDa.IsChecked = false;
            checkBoxImportanceNe.IsChecked = false;
            checkBoxImportanceDa.IsEnabled = true;
            checkBoxImportanceNe.IsEnabled = true;

            //AbleToExploate.IsChecked = false;
            CheckBoxEkspNe.IsEnabled = true;
            CheckBoxEkspDa.IsEnabled = true;
            CheckBoxEkspNe.IsChecked = false;
            CheckBoxEkspDa.IsChecked = false;


            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
            FromDate = DateTime.Now;
            buttonSearch.IsEnabled = true;

            CenaOd.Text = "";
            CenaDo.Text = "";


        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void CheckBoxEkspDa_Checked(object sender, RoutedEventArgs e)
        {

            CheckBoxEkspNe.IsEnabled = false;


        }
        private void CheckBoxReDa_Checked(object sender, RoutedEventArgs e)
        {

            CheckBoxReNe.IsEnabled = false;


        }
        private void CheckBoxImportanceDa_Checked(object sender, RoutedEventArgs e)
        {

            checkBoxImportanceNe.IsEnabled = false;


        }
        private void CheckBoxEkspDa_UnChecked(object sender, RoutedEventArgs e)
        {

            CheckBoxEkspNe.IsEnabled = true;


        }
        private void CheckBoxReDa_UnChecked(object sender, RoutedEventArgs e)
        {

            CheckBoxReNe.IsEnabled = true;


        }

        private void CheckBoxImportanceDa_UnChecked(object sender, RoutedEventArgs e)
        {

            checkBoxImportanceNe.IsEnabled = true;


        }

        private void CheckBoxEkspNe_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxEkspDa.IsEnabled = false;
        }

        private void CheckBoxReNe_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxReDa.IsEnabled = false;
        }

        private void CheckBoxImportanceNe_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxImportanceDa.IsEnabled = false;
        }


        private void CheckBoxEkspNe_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckBoxEkspDa.IsEnabled = true;
        }
        private void CheckBoxReNe_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckBoxReDa.IsEnabled = true;
        }
        private void CheckBoxImportanceNe_UnChecked(object sender, RoutedEventArgs e)
        {
            checkBoxImportanceDa.IsEnabled = true;
        }


    }
}
