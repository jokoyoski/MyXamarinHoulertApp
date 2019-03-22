using Houlert.Model;
using Houlert.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Acr.UserDialogs;
using Houlert.RestClient;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Houlert.Command
{
    public class PostEditPropertyCommand : ICommand
    {
        public PropertyVM propertyVM { get; set; }

        private IUserDialogs Dialogs = UserDialogs.Instance;

        public PostEditPropertyCommand(PropertyVM propertyVM)
        {
            this.propertyVM = propertyVM;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
//            var property = (Property) parameter;
//            if (property.title == null)
//                return false;
//            else
//            {
//                return true;
//            }
        }

        public async void Execute(object parameter)
        {
            var property = (Property) parameter;
            //Get The Currently Logged In User

            //Get The Currently Logged In User
            if (property == null)
            {
                this.Dialogs.Toast("Provide valid properties details");
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(property.title))
                {
                    this.Dialogs.Toast("Property title is required");
                    return;
                }

                if (property.property_purpose_id <= 0)
                {
                    this.Dialogs.Toast("Property purpose is required");
                    return;
                }


                if (property.property_type_id <= 0)
                {
                    this.Dialogs.Toast("Property type is required");
                    return;
                }


                if (property.property_sub_type_id <= 0)
                {
                    this.Dialogs.Toast("Property sub type is required");
                    return;
                }

                if (property.property_use_id <= 0)
                {
                    this.Dialogs.Toast("Property use is required");
                    return;
                }


                if (string.IsNullOrEmpty(property.description))
                {
                    this.Dialogs.Toast("Property description is required");
                    return;
                }


                if (string.IsNullOrEmpty(property.short_description))
                {
                    this.Dialogs.Toast("Property short description is required");
                    return;
                }


                if (string.IsNullOrEmpty(property.price))
                {
                    this.Dialogs.Toast("Property price is required");
                    return;
                }

                if (property.state_id <= 0)
                {
                    this.Dialogs.Toast("Property state is required");
                    return;
                }

                if (property.area_id <= 0)
                {
                    this.Dialogs.Toast("Property area is required");
                    return;
                }


                if (string.IsNullOrEmpty(property.street))
                {
                    this.Dialogs.Toast("Property street address is required");
                    return;
                }
            }

          

            try
            {
                PropertyClient propertyClient = new PropertyClient();


                var loggedUser = App.Current.Properties["User"].ToString();

                var user = JsonConvert.DeserializeObject<UserJson>(loggedUser);

                var userId = user.User.id;
                var api_token = user.User.api_token;

                var dialog = this.Dialogs.Loading();
                dialog.Show();

                var response = await propertyClient.EditPropetry(userId, api_token, property);

                dialog.Hide();

                if (response != null)
                {
                    var deserializeResponse = JsonConvert.DeserializeObject(response);

                    var returnedProperty = JsonConvert.DeserializeObject<PropertyRoot>(response);

                    var propertyReturned = returnedProperty.Property;

                    //Lopping througn The Json to Get Message if Any 
                    //The presnence of a message meas there is an error

                    var JsonObject = deserializeResponse as JObject;

                    var message = (string) JsonObject["message"];

                    if (message != null)
                    {
                        this.Dialogs.Toast(displayMessage(message));
                        return;
                    }

                    this.Dialogs.Toast("Property Updated");
                    await ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).Navigation.PushAsync(
                        new Listings());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        /// <summary>
        /// To Help Display Message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        string displayMessage(string message)
        {
            return string.Format("Failed : {0}", message);
        }
    }
}