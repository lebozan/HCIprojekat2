using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesApplication.Beans
{
    [Serializable]
    public class ResourceTag : INotifyPropertyChanged
    {

        private string id;

        public string Id
        {
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

        private string color;

        public string Color
        {
            get { return color; }
            set
            {
                if (value != color)
                {
                    color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        private string description;

        public string Description
        {
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



        public ResourceTag()
        {
        }

        public ResourceTag(string id, string color, string description)
        {
            this.id = id;
            this.color = color;
            this.description = description;
        }

        public ResourceTag(ResourceTag resourceTag)
        {
            id = resourceTag.Id;
            color = resourceTag.Color;
            description = resourceTag.Description;
        }



        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
