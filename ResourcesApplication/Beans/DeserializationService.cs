using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ResourcesApplication.Beans
{
    public class DeserializationService
    {
        public String RESOURCES_DATA { get; set; }
        public readonly string ALL_RESOURCES = "resources.bin";
        public readonly string TYPES_DATA = "types.bin";
        public readonly string TAGS_DATA = "tags.bin";
        public void deserializeResources(Database d)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;
            Console.WriteLine("NAZIV FAJLA: " + RESOURCES_DATA);
            if (File.Exists(RESOURCES_DATA))
            {
                try
                {
                    stream = File.Open(RESOURCES_DATA, FileMode.Open);
                    var data = (ObservableCollection<Resource>)formatter.Deserialize(stream);
                    d.Resources = data;

                }
                catch
                {
                    throw new FileNotFoundException();
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }

        public void deserializeAllResources(Database d)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;
            if (File.Exists(ALL_RESOURCES))
            {
                try
                {
                    stream = File.Open(ALL_RESOURCES, FileMode.Open);
                    var data = (ObservableCollection<Resource>)formatter.Deserialize(stream);
                    d.AllResources = data;

                }
                catch
                {
                    throw new FileNotFoundException();
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }



        public void deserializeTypes(Database d)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(TYPES_DATA))
            {
                try
                {
                    stream = File.Open(TYPES_DATA, FileMode.Open);
                    d.Types = (ObservableCollection<ResourceType>)formatter.Deserialize(stream);
                }
                catch
                {
                    throw new FileNotFoundException();
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }

        public void deserializeTags(Database d)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(TAGS_DATA))
            {
                try
                {
                    stream = File.Open(TAGS_DATA, FileMode.Open);
                    d.Tags = (ObservableCollection<ResourceTag>)formatter.Deserialize(stream);
                }
                catch
                {
                    throw new FileNotFoundException();
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }
    }
}
