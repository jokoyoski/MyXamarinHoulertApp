using Houlert.Helper;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Houlert.Model;
using Newtonsoft.Json;

namespace Houlert.RestClient
{
    public class PropertyClient
    {
        HttpClient client;

        //Make the Web Url 
        private static string web_api = Constant.RestUrl + "property/";

        private static string area_api = Constant.RestUrl + "area?locality_id={0}";

        /// <summary>
        /// Add Property to API
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<string> AddProperty(Property property, int userId, string apiToken)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri(String.Format("{0}create?user_id={1}&api_token={2}", web_api, userId, apiToken));


            var json = JsonConvert.SerializeObject(property);
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
                Console.WriteLine("Unable to connect ", ex);
            }

            return null;
        }




        /// <summary>
        /// Get All Properties
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Property>> Properties(int userId, string apiToken)
        {
            List<Property> propertyList = new List<Property>();
            //calls the Generate URL
            var uri = new Uri(String.Format("{0}properties?user_id={1}&api_token={2}", web_api, userId, apiToken));

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //this is the function that calls the api
                    var response = await client.GetAsync(uri);
                    //convert the json to string 

                    var json = await response.Content.ReadAsStringAsync();

                    //the property type root consisit of response and the property type
                    var propertiesList = JsonConvert.DeserializeObject<PropertyList>(json);


                    //we need to convert them to List
                    propertyList = propertiesList.properties;

                    return propertyList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



        /// <summary>
        /// Get Property Types
        /// </summary>
        /// <returns></returns>
        public static async Task<List<PropertyType>> GetPropertyTypes()
        {
            List<PropertyType> propertyTypes = new List<PropertyType>();
            //calls the Generate URL

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //this is the function that calls the api
                    var response = await client.GetAsync(web_api + "property_types");
                    //convert the json to string 

                    var json = await response.Content.ReadAsStringAsync();

                    //the property type root consisit of response and the property type
                    var propertyList = JsonConvert.DeserializeObject<PropertyTypeRoot>(json);


                    //we need to convert them to List
                    propertyTypes = propertyList.property_type;

                    return propertyTypes;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        /// <summary>
        /// Get Property Sub Type When A property Type Is Selected
        /// </summary>
        /// <param name="propertyTypeId"></param>
        /// <returns></returns>
        public static async Task<List<PropertySubType>> GetPropertySubTypes(int propertyTypeId)
        {
            List<PropertySubType> propertySubTypes = new List<PropertySubType>();
            //calls the Generate URL
            var full_api = string.Format("{0}property_sub_types?property_type_id={1}", web_api, propertyTypeId);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //this is the function that calls the api
                    var response = await client.GetAsync(full_api);
                    //convert the json to string 

                    var json = await response.Content.ReadAsStringAsync();

                    //the property type root consisit of response and the property type
                    var propertySubTypeList = JsonConvert.DeserializeObject<PropertySubTypeList>(json);

                    //we need to convert them to List
                    propertySubTypes = propertySubTypeList.Property_sub_types;

                    return propertySubTypes;
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
        public static async Task<List<PropertyPurpose>> GetPropertyPurpose()
        {
            List<PropertyPurpose> propertyPurposes = new List<PropertyPurpose>();
            //calls the Generate URL
            var full_api = string.Format("{0}property_purposes", web_api);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //this is the function that calls the api
                    var response = await client.GetAsync(full_api);
                    //convert the json to string 

                    var json = await response.Content.ReadAsStringAsync();

                    //the property type root consisit of response and the property type
                    var propertyPurposeList = JsonConvert.DeserializeObject<PropertyPurposesList>(json);

                    //we need to convert them to List
                    propertyPurposes = propertyPurposeList.property_purpose;

                    return propertyPurposes;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        //update property
        public async Task<string>  EditPropetry(int userId, string user_token, Property property)
        {

            int Id = property.id;

            var full_api = string.Format("{0}update/{1}?user_id={2}&api_token={3}", web_api, Id, userId, user_token);

            ///
            using (HttpClient client = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(property);

                var contentType = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = null;
                response = await client.PostAsync(full_api, contentType);

                var result = await response.Content.ReadAsStringAsync();

                return result;
            }


        }





        public static async Task<List<Area>> GetAreas(int locality_id)
        {
            var url = Constant.RestUrl;
            List<Area> areas = new List<Area>();
            //calls the Generate URL
            var full_api = string.Format(url + "area?locality_id={0}", locality_id);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //this is the function that calls the api
                    var response = await client.GetAsync(full_api);
                    //convert the json to string 

                    var json = await response.Content.ReadAsStringAsync();

                    //the property type root consisit of response and the property type
                    var areaList = JsonConvert.DeserializeObject<AreaList>(json);

                    //we need to convert them to List
                    areas = areaList.area as List<Area>;

                    return areas;
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
        public static async Task<List<PropertyUse>> GetPropertyUse()
        {
            List<PropertyUse> propertyPurposes = new List<PropertyUse>();
            //calls the Generate URL
            var full_api = string.Format("{0}property_uses", web_api);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //this is the function that calls the api
                    var response = await client.GetAsync(full_api);
                    //convert the json to string 

                    var json = await response.Content.ReadAsStringAsync();

                    //the property type root consisit of response and the property type
                    var propertyUseList = JsonConvert.DeserializeObject<PropertyUseList>(json);

                    //we need to convert them to List
                    propertyPurposes = propertyUseList.property_use;

                    return propertyPurposes;
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
