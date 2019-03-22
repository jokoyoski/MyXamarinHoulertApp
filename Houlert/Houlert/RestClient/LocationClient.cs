using Houlert.Helper;
using Houlert.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Houlert.RestClient
{
    class LocationClient
    {
        HttpClient client;

        //Make the Web Url 
        private static string web_api = Constant.RestUrl ;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<State>> GetStates()
        {
            List<State> stateList = new List<State>();
            //calls the Generate URL
            var full_api = string.Format("{0}states", web_api);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //this is the function that calls the api
                    var response = await client.GetAsync(full_api);
                    //convert the json to string 

                    var json = await response.Content.ReadAsStringAsync();

                    //the property type root consisit of response and the property type
                    var statesList = JsonConvert.DeserializeObject<StatesList>(json);

                    //we need to convert them to List
                    stateList = statesList.states;

                    return stateList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Locality>> GetLocality(int state_id)
        {
            List<Locality> localityList = new List<Locality>();

            //calls the Generate URL
            var full_api = string.Format("{0}locality?state_id={1}", web_api,state_id);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //this is the function that calls the api
                    var response = await client.GetAsync(full_api);
                    //convert the json to string 

                    var json = await response.Content.ReadAsStringAsync();

                    //the property type root consisit of response and the property type
                    var localitiesList = JsonConvert.DeserializeObject<LocalityList>(json);

                    //we need to convert them to List
                    localityList = localitiesList.locality;

                    return localityList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
