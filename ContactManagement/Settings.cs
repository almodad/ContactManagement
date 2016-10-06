using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement
{
    public class Settings
    {
        private Windows.Storage.ApplicationDataContainer localSettings;
        public Settings()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        }

        public List<Contact> contacts
        {
            get
            {
                if (localSettings.Values.ContainsKey("contacts"))
                {
                    return fromJson(localSettings.Values["contacts"].ToString());
                }else
                {
                    return new List<Contact>();
                }
            }
            set
            {
                localSettings.Values["contacts"] = toJson(value);
            }
        }

        private List<Contact> fromJson(string json)
        {
            return JsonConvert.DeserializeObject(json, typeof(List<Contact>)) as List<Contact>;
        }

        private List<Contact> _fromJson(string json)
        {
            DataContractJsonSerializer Serializer = new DataContractJsonSerializer(typeof(List<Contact>));

            return Serializer.ReadObject(getStream(json)) as List<Contact>;
        }
        private string toJson(List<Contact> contacts)
        {
            return JsonConvert.SerializeObject(contacts);
        }

        private string _toJson(List<Contact> contacts)
        {
            DataContractJsonSerializer Serializer = new DataContractJsonSerializer(typeof(List<Contact>));
            MemoryStream stream = new MemoryStream();
            Serializer.WriteObject(stream, contacts);
            return stream.ToString();
        }

        private MemoryStream getStream(string json)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(json));
        }


    }
}
