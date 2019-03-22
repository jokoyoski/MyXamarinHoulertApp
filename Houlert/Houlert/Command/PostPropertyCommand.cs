using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Acr.UserDialogs;
using Houlert.Model;
using Houlert.RestClient;
using Houlert.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Houlert.Command
{
    public class PostPropertyCommand : ICommand
    {
        public PropertyVM PropertyVm { get; set; }
        public IUserDialogs Dialogs = UserDialogs.Instance;

        public PostPropertyCommand(PropertyVM PropertyVm)
        {
            this.PropertyVm = PropertyVm;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var property = (Property) parameter;

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

                //if (property.property_use_id <= 0)
                //{
                //    this.Dialogs.Toast("Property use is required");
                //    return;
                //}


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
                var dialog = this.Dialogs.Loading("Please wait......");
                dialog.Show();
                var loggedUser = App.Current.Properties["User"].ToString();

                //Get The Logged In User
                var loggedInUser = JsonConvert.DeserializeObject<UserJson>(loggedUser);

                var user = loggedInUser.User as User;

                var userId = user.id;
                var api_token = user.api_token;


                // property.company_id = 1; //TODO : Get the Company Here
                property.duration = 1;
                property.currency = 1;
                PropertyClient propertyClient = new PropertyClient();

                //Store the Property
                var response = await propertyClient.AddProperty(property, userId, api_token);

                dialog.Hide();
                //Deal with the Messages and Get back to us

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

                    this.Dialogs.Toast("New Property Posted");
                    await ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).Navigation.PushAsync(
                        new UploadPropertyImagesPage(propertyReturned));
                }


                //Thank You
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public event EventHandler CanExecuteChanged;

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