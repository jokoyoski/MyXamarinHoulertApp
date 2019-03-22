using Houlert.Model;
using Houlert.RestClient;
using Houlert.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Houlert.Helper;
using Newtonsoft.Json;
using Xamarin.Forms;
using Acr.UserDialogs;
using Newtonsoft.Json.Linq;

namespace Houlert.Command
{
    //this is the command that process  registration info
    public class RegistrationCommand : ICommand
    {
        private Utilities utilities = new Utilities();

        public RegisterVM registerVM { get; set; }
        public IUserDialogs Dialogs { get; }

        public RegistrationCommand(RegisterVM registerVM)
        {
            this.Dialogs = UserDialogs.Instance;

            this.registerVM = registerVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var user = (User) parameter;

            if (user == null)
            {
                return false;
            }
            else
            {
                //Check that email is not null and valid
                if (string.IsNullOrEmpty(user.email))
                    return false;

                //Checking for Email Validity
                if (!utilities.IsEmailValid(user.email))
                    return false;


                //Check that Passwords Match
                if (user.password != user.password_confirmation)

                    return false;
            }


            return true;
        }

        public async void Execute(object parameter)
        {
            var user = (User) parameter;

            user.user_type = 1; //This is the main Administrator. The Company Owner

            RegistrationClient registrationClient = new RegistrationClient();

            try
            {
                var diag = this.Dialogs.Loading("Registration in progress........ Please wait");

                diag.Show();
                var response = await registrationClient.RegisterUser(user);

                diag.Hide();

                if (response != null)
                {
                    var deserializeResponse = JsonConvert.DeserializeObject(response);

                    //Lopping througn The Json to Get Message if Any
                    //The presnence of a message meas there is an error

                    var JsonObject = (JObject) deserializeResponse;

                    var message = (string) JsonObject["message"];

                    if (!string.IsNullOrEmpty(message))
                    {
                        //There is A Message
                        //Check Which it is

                        var email = (string) JsonObject["email"];


                        //Error with Email
                        if (!string.IsNullOrEmpty(email))
                        {
                            this.Dialogs.Toast(displayMessage(email));
                            return;
                        }

                        //Password Issue
                        var password = (string) JsonObject["password"];

                        if (!string.IsNullOrEmpty(password))
                        {
                            this.Dialogs.Toast(displayMessage(password));
                            return;
                        }

                        //First Name Issue
                        var first_name = (string) JsonObject["first_name"];

                        if (!string.IsNullOrEmpty(first_name))
                        {
                            this.Dialogs.Toast(displayMessage(first_name));
                            return;
                        }


                        //Last Name Issue
                        var last_name = (string) JsonObject["last_name"];

                        if (!string.IsNullOrEmpty(last_name))
                        {
                            this.Dialogs.Toast(displayMessage(last_name));
                            return;
                        }
                    }
                    else
                    {
                        //Succesfull Registration
                        var loggedInUser = JsonConvert.DeserializeObject<User>(response);

                        //Store this User in A Local Storage as the newly Logged In User
                        App.Current.Properties["User"] = response;

                        //Also, Redirect to the Main Application Page
                        await App.Current.MainPage.Navigation.PushAsync(new AddCompanyPage());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                this.Dialogs.Toast(displayMessage("Unable to complete registration operation"));
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
            return string.Format("Registration Failed : {0}", message);
        }
    }
}