﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesApplication.Beans
{
    [Serializable]
    public class ResourceType: INotifyPropertyChanged
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

        private string name;
        public string Name
        {
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

        private string iconPath;
        public string IconPath
        {
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
        
        
        public ResourceType()
        {
        }

        public ResourceType(string id, string name, string description, string iconPath)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            string newPath = Directory.GetCurrentDirectory() + @iconPath.Split('/').Last();
            if (!File.Exists(newPath) && newPath != null && !string.IsNullOrEmpty(newPath) && !string.IsNullOrWhiteSpace(newPath))
            {
                File.Copy(@iconPath, @newPath, true);
            }
            this.iconPath = newPath;
        }

        public ResourceType(ResourceType type)
        {
            if (type != null)
            {
                id = type.Id;
                name = type.Name;
                description = type.Description;
                iconPath = type.IconPath;
            }
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
