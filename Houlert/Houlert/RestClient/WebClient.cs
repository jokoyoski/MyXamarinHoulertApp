using Houlert.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Houlert.RestClient
{
    public class WebClient
    {


        public const string WebServiceUrl = "http://houlert.topefasua2019.com/api/register";
        // public const  string joko=  "http://houlert.topefasua2019.com/api/register?first_name=adeola&password=jokoyoski&password_confirmation=jokoyoski&user_type=5&last_name=adeola&email=joko@gmail.com"


        public async Task<bool> Register(User users)
        {
            Data data;
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(users);

                string sampleJson = "{\"first_name\":\"adeola\",\"email\":\"jookoyoski11@yahoo.com\",\"user_type\":\"5\",\"password\":\"jokoyoski\",\"last_name\":\"Oladeinde\",\"password_confirmation\":\"jokoyoski\"}";
                var contentType = new StringContent(sampleJson, Encoding.UTF8, "application/json");
                //HttpContent httpContent = new StringContent(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                //          httpClient.DefaultRequestHeaders
                //.Accept
                //.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //ACCEPT header
                //httpClient.DefaultRequestHeaders.Add("Accept", "audio/*; q=0.2, audio/basic");
                // httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var result = await httpClient.PostAsync(WebServiceUrl, contentType);

                string responseString = await result.Content.ReadAsStringAsync();

                if (responseString.Contains("The email has already been taken."))
                {
                    await App.Current.MainPage.DisplayAlert("Email Exist", "The Email Already Exist", "Cancel");
                }
                if (responseString.Contains("\"first_name\":[\"The first name field is required.\"]"))
                {
                    await App.Current.MainPage.DisplayAlert("validName", "Enter a Valid Name", "Cancel");
                }
                if (responseString.Contains("\"last_name\":[\"The last name field is required.\"]"))
                {
                    await App.Current.MainPage.DisplayAlert("validLastName", "Enter a Valid Last Name", "Cancel");
                }
                if (responseString.Contains("\"email\":[\"The email field is required.\"]"))
                {
                    await App.Current.MainPage.DisplayAlert("validLastName", "Enter a Valid Last Name", "Cancel");
                }
                if (responseString.Contains("\"password\":[\"The password field is required.\"]"))
                {
                    await App.Current.MainPage.DisplayAlert("validLastName", "Enter a Valid Last Name", "Cancel");
                }


                var RootObject = JsonConvert.DeserializeObject<RootObject>(responseString);

                // venues = VenueRoot.response.venues as List<Venue>;
                data = RootObject.data as Data;
                return result.IsSuccessStatusCode;
            }
        }
        

           


        }
    }

