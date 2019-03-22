using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Houlert.Helper;
using Houlert.Model;
using Newtonsoft.Json;

namespace Houlert.RestClient
{
    public class LoginClient
    {

        HttpClient client;

        public async Task<string> LoginUser(User user)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri(string.Format(Constant.RestUrl + "login", string.Empty));


            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = null;

            try
            {
                //Connection to the API
                response = await client.PostAsync(uri, content);
                //Geth The String Response

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to connect", ex);
            }

            return null;
        }
    }
}
