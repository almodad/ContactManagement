using PortableRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement
{
    public class Proxy
    {
        private const string URL = "http://apicontacts.azurewebsites.net/";
        public static async Task<Contact> postContact(Contact contact)
        {
            var client = new RestClient { BaseUrl = URL };

            RestRequest request = new RestRequest("contacts/", HttpMethod.Post);
            request.ContentType = ContentTypes.Json;
            request.AddParameter(contact);            
            var response = await client.ExecuteAsync<Contact>(request);
            
            return response;          
        }

        public static List<Contact> getContacts()
        {
            var client = new RestClient { BaseUrl = URL };
            RestRequest request = new RestRequest("contacts/", HttpMethod.Get);
            var response = client.ExecuteAsync<List<Contact>>(request);
            return response.Result;
        }


    }
}
