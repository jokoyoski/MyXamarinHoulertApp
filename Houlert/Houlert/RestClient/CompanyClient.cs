using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Houlert.Helper;
using Houlert.Model;
using Newtonsoft.Json;

namespace Houlert.RestClient
{
    public class CompanyClient
    {
        HttpClient client;

        /// <summary>
        /// Create a company
        /// </summary>
        /// <param name="company"></param>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> AddCompany(Company company, int userId, string token)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri(string.Format(Constant.RestUrl + "company/create?api_token={0}&user_id={1}", token,
                userId));


            var json = JsonConvert.SerializeObject(company);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            try
            {
                using (client)
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Connection to the API
                    response = await client.PostAsync(uri, content);
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to connect", ex);
            }

            return null;
        }


        /// <summary>
        /// Update a company Information
        /// </summary>
        /// <param name="company"></param>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> UpdateCompany(Company company, int companyId, int userId, string token)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri(string.Format(Constant.RestUrl + "company/update/{0}?api_token={1}&user_id={2}",companyId, token,
                userId));


            var json = JsonConvert.SerializeObject(company);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            try
            {
                using (client)
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Connection to the API
                    response = await client.PostAsync(uri, content);
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to connect", ex);
            }

            return null;
        }


//        public static async Task<Company> Company(int companyId,int userId, string apiToken)
//        {
//            List<Property> propertyList = new List<Property>();
//            //calls the Generate URL
//            var uri = new Uri(String.Format("{0}company/{3}?user_id={1}&api_token={2}", Constant.RestUrl, userId, apiToken,companyId));
//
//            try
//            {
//                using (HttpClient client = new HttpClient())
//                {
//                    //this is the function that calls the api
//                    var response = await client.GetAsync(uri);
//                    //convert the json to string 
//
//                    var json = await response.Content.ReadAsStringAsync();
//
//                    //the property type root consisit of response and the property type
//                    var propertiesList = JsonConvert.DeserializeObject<PropertyList>(json);
//
//
//                    //we need to convert them to List
//                    propertyList = propertiesList.properties;
//
//                    return propertyList;
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
    }
}