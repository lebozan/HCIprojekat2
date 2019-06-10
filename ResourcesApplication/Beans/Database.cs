using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ResourcesApplication.Beans
{
    [Serializable]
    public class Database : INotifyPropertyChanged
    {
        public SerializationService serijalizacija { get; set; }
        public DeserializationService deserijalizacija { get; set; }


        private ObservableCollection<Resource> resources;
        public ObservableCollection<Resource> Resources
        {
            get { return resources; }
            set
            {
                if (value != resources)
                {
                    resources = value;
                    OnPropertyChanged("Resources");
                }
            }
        }

        private ObservableCollection<Resource> allResources;
        public ObservableCollection<Resource> AllResources
        {
            get { return allResources; }
            set
            {
                if (value != allResources)
                {
                    allResources = value;
                    OnPropertyChanged("AllResources");
                }
            }
        }

        private ObservableCollection<ResourceType> types;
        public ObservableCollection<ResourceType> Types
        {
            get { return types; }
            set
            {
                if (value != types)
                {
                    types = value;
                    OnPropertyChanged("Types");
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


        public Database()
        {
            serijalizacija = new SerializationService();
            deserijalizacija = new DeserializationService();
            resources = new ObservableCollection<Resource>();
            allResources = new ObservableCollection<Resource>();
            types = new ObservableCollection<ResourceType>();
            tags = new ObservableCollection<ResourceTag>();
        }


        public void SaveResources()
        {
            serijalizacija.serializeResource(resources);
            serijalizacija.serializeAllResources(allResources);
        }

        public void SaveTypes()
        {
            serijalizacija.serializeTypes(types);
        }

        public void SaveTags()
        {
            serijalizacija.serializeTags(tags);
        }

        public void AddResource(Resource resource)
        {
            resources.Add(resource);
            allResources.Add(resource);
            SaveResources();
        }

        public void AddType(ResourceType type)
        {
            types.Add(type);
            SaveTypes();
        }

        public void AddTag(ResourceTag tag)
        {
            tags.Add(tag);
            SaveTags();
        }

        public Resource GetResource(string id)
        {
            for (int i = 0; i < Resources.Count; i++)
            {
                if (Resources[i].Id.Equals(id))
                {
                    return Resources[i];
                }
            }
            return null;
        }

        public ResourceType GetType(string id)
        {
            for (int i = 0; i < Types.Count; i++)
            {
                if (Types[i].Id.Equals(id))
                {
                    return Types[i];
                }
            }
            return null;
        }

        public ResourceTag GetTag(string id)
        {
            for (int i = 0; i < Tags.Count; i++)
            {
                if (Tags[i].Id.Equals(id))
                {
                    return Tags[i];
                }
            }
            return null;
        }

        public void UpdateResource(string oldId, Resource resource)
        {
            for (int i = 0; i < Resources.Count; i++)
            {
                if (oldId.Equals(Resources[i].Id))
                {
                    Resources[i] = resource;
                    SaveResources();
                    break;
                }
            }
        }

        public void UpdateType(string oldId, ResourceType type)
        {
            for (int i = 0; i < Types.Count; i++)
            {
                if (oldId.Equals(Types[i].Id))
                {
                    Types[i] = type;
                    SaveTypes();
                    break;
                }
            }
        }

        public void UpdateTag(string oldId, ResourceTag tag)
        {
            for (int i = 0; i < Tags.Count; i++)
            {
                if (oldId.Equals(Tags[i].Id))
                {
                    Console.WriteLine("Uslo u updatee");
                    Tags[i] = tag;
                    SaveTags();
                    break;
                }
            }
        }

        public void DeleteResource(Resource resource)
        {
            for (int i = 0; i < Resources.Count; i++)
            {
                if (resource.Id.Equals(Resources[i].Id))
                {
                    Resources.RemoveAt(i);
                    SaveResources();
                    break;
                }
            }
        }

        public void DeleteType(ResourceType type)
        {
            for (int i = 0; i < Types.Count; i++)
            {
                if (type.Id.Equals(Types[i].Id))
                {
                    Types.RemoveAt(i);
                    SaveTypes();
                    break;
                }
            }
        }

        public void DeleteTag(ResourceTag tag)
        {
            for (int i = 0; i < Tags.Count; i++)
            {
                if (tag.Id.Equals(Tags[i].Id))
                {
                    Tags.RemoveAt(i);
                    SaveTags();
                    break;
                }
            }
        }



        public void loadData()
        {
            deserijalizacija.deserializeTags(this);
            deserijalizacija.deserializeTypes(this);
            deserijalizacija.deserializeResources(this);
            deserijalizacija.deserializeAllResources(this);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public List<Resource> searchName(string name)
        {
            List<Resource> send = new List<Resource>();
            for (int i = 0; i < Resources.Count; i++)
            {
                if (name != null)
                {
                    if (name.Equals(Resources[i].Name))
                    {
                        if (Resources[i].X != -1 && Resources[i].Y != -1)
                        {
                            send.Add(Resources[i]);
                        }
                    }
                }
            }

            return send;
        }

        public List<Resource> searchType(string type)
        {
            List<Resource> send = new List<Resource>();
            for (int i = 0; i < Resources.Count; i++)
            {
                if (type != null)
                {
                    if (type.Equals(Resources[i].Type.Id))
                    {
                        if (Resources[i].X != -1 && Resources[i].Y != -1)
                        {
                            send.Add(Resources[i]);
                        }
                    }
                }
            }

            return send;
        }

        public List<Resource> searchTag(string tag)
        {
            List<Resource> send = new List<Resource>();
            for (int i = 0; i < Resources.Count; i++)
            {
                foreach (ResourceTag rt in Resources[i].Tags)
                {
                    if (rt.Id.Equals(tag))
                    {
                        if (Resources[i].X != -1 && Resources[i].Y != -1)
                        {
                            send.Add(Resources[i]);
                        }

                    }
                }
            }

            return send;
        }

        public List<Resource> filter(List<string> krit)
        {
            List<Resource> send = new List<Resource>();
            foreach (Resource r in Resources)
            {
                bool added = false;
                foreach (string s in krit)
                {
                    if (s.Equals("obnovljiv") && r.Renewable == true)
                    {
                        if (added == false)
                        {
                            if (r.X != -1 && r.Y != -1)
                            {
                                send.Add(r);
                                added = true;
                            }
                        }
                    }
                    if (s.Equals("vazan") && r.Importance == true)
                    {
                        if (added == false)
                        {
                            if (r.X != -1 && r.Y != -1)
                            {
                                send.Add(r);
                                added = true;
                            }
                        }
                    }
                    if (s.Equals("exp") && r.AbleToExploate == true)
                    {
                        if (added == false)
                        {
                            if (r.X != -1 && r.Y != -1)
                            {
                                send.Add(r);
                                added = true;
                            }
                        }
                    }
                    if (s.Equals("merica") && r.MeasurementUnit == "Merica")
                    {
                        if (added == false)
                        {
                            if (r.X != -1 && r.Y != -1)
                            {
                                send.Add(r);
                                added = true;
                            }
                        }
                    }
                    if (s.Equals("tona") && r.MeasurementUnit == "Tona")
                    {
                        if (added == false)
                        {
                            if (r.X != -1 && r.Y != -1)
                            {
                                send.Add(r);
                                added = true;
                            }
                        }
                    }
                    if (s.Equals("kilogram") && r.MeasurementUnit == "Kilogram")
                    {
                        if (added == false)
                        {
                            if (r.X != -1 && r.Y != -1)
                            {
                                send.Add(r);
                                added = true;
                            }
                        }
                    }
                    if (s.Equals("barel") && r.MeasurementUnit == "Barel")
                    {
                        if (added == false)
                        {
                            if (r.X != -1 && r.Y != -1)
                            {
                                send.Add(r);
                                added = true;
                            }
                        }
                    }
                    if (s.Equals("redak") && r.Frequency == "Redak")
                    {
                        if (added == false)
                        {
                            if (r.X != -1 && r.Y != -1)
                            {
                                send.Add(r);
                                added = true;
                            }
                        }
                    }
                    if (s.Equals("cest") && r.Frequency == "Cest")
                    {
                        if (added == false)
                        {
                            if (r.X != -1 && r.Y != -1)
                            {
                                send.Add(r);
                                added = true;
                            }
                        }

                    }
                    if (s.Equals("univerzalan") && r.Frequency == "Univerzalan")
                    {
                        if (added == false)
                        {
                            if (r.X != -1 && r.Y != -1)
                            {
                                send.Add(r);
                                added = true;
                            }
                        }
                    }
                }
            }
            return send;
        }
    }
}
