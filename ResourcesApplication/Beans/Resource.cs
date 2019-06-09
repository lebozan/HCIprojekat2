using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesApplication.Beans
{   
    [Serializable]
    public class Resource : INotifyPropertyChanged
    {

        private string id;
        public string Id {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private string name;
        public string Name {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string description;
        public string Description {
            get { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private ResourceType type;
        public ResourceType Type {
            get { return type; }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        private string iconPath;
        public string IconPath {
            get { return iconPath; }
            set
            {
                if (value != iconPath)
                {
                    iconPath = value;
                    OnPropertyChanged("IconPath");
                }
            }
        }

        private bool renewable;
        public bool Renewable {
            get { return renewable; }
            set
            {
                if (value != renewable)
                {
                    renewable = value;
                    OnPropertyChanged("Renewable");
                }
            }
        }

        private bool importance;
        public bool Importance {
            get { return importance; }
            set
            {
                if (value != importance)
                {
                    importance = value;
                    OnPropertyChanged("Importance");
                }
            }
        }

        private bool ableToExploate;
        public bool AbleToExploate {
            get { return ableToExploate; }
            set
            {
                if (value != ableToExploate)
                {
                    ableToExploate = value;
                    OnPropertyChanged("AbleToExploate");
                }
            }
        }

        private string measurementUnit;
        public string MeasurementUnit {
            get { return measurementUnit; }
            set
            {
                if (value != measurementUnit)
                {
                    measurementUnit = value;
                    OnPropertyChanged("MeasurementUnit");
                }
            }
        }

        private double price;
        public double Price {
            get { return price; }
            set
            {
                if (value != price)
                {
                    price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        private DateTime date;
        public DateTime Date {
            get { return date; }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        private String frequency;
        public string Frequency {
            get { return frequency; }
            set
            {
                if (value != frequency)
                {
                    frequency = value;
                    OnPropertyChanged("Frequency");
                }
            }
        }

       

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

        private int x;
        public int X
        {
            get { return x; }
            set
            {
                if (value != x)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set
            {
                if (value != y)
                {
                    y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        public Resource()
        {
            Tags = new ObservableCollection<ResourceTag>();
        }

        public Resource(Resource resource)
        {
            id = resource.id;
            name = resource.name;
            description = resource.description;
            date = resource.date;
            renewable = resource.renewable;
            type = new ResourceType(resource.type);
            iconPath = resource.iconPath;
            importance = resource.importance;
            ableToExploate = resource.ableToExploate;
            price = resource.price;
            measurementUnit = resource.measurementUnit;
            price = resource.price;
            frequency = resource.frequency;
            tags = new ObservableCollection<ResourceTag>(resource.tags);
            x = resource.X;
            y = resource.Y;
        }


        public Resource(string id, string name, string description, DateTime date, ResourceType type, string iconPath,
            bool renewable, bool importance, bool ableToExploate, string measurementUnit, double price, string frequency, ObservableCollection<ResourceTag> tags)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.date = date;
            this.type = type;
            string newPath = Directory.GetCurrentDirectory() + @iconPath.Split('/').Last();
            if (!File.Exists(newPath) && newPath != null && !string.IsNullOrEmpty(newPath) && !string.IsNullOrWhiteSpace(newPath))
            {
                File.Copy(@iconPath, @newPath, true);
            }
            this.renewable = renewable;
            this.importance = importance;
            this.ableToExploate = ableToExploate;
            this.price = price;
            this.measurementUnit = measurementUnit;
            this.price = price;
            this.frequency = frequency;
            this.x = -1;
            this.y = -1;
        }

        [field: NonSerialized]
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
