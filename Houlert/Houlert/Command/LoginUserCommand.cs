using Houlert.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Houlert.Helper;
using Houlert.Model;
using Houlert.RestClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Acr.UserDialogs;


namespace Houlert.Command
{
    public class LoginUserCommand : ICommand
    {
        public LoginVm loginVm { get; set; }
        private Utilities utilities = new Utilities();
        protected IUserDialogs Dialogs { get; }

        public LoginUserCommand(LoginVm loginVm, IUserDialogs dialogs)
        {
            this.Dialogs = dialogs;
            this.loginVm = loginVm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //Login user Here
            var user = (User) parameter;

            if (user == null)
            {
                return false;
            }
            else
            {
                //Check that the Password is not also Null
                if (string.IsNullOrEmpty(user.password))
                    return false;
                //Check that email is not null and valid
                if (string.IsNullOrEmpty(user.email))
                    return false;

                //Checking for Email Validity
                if (!utilities.IsEmailValid(user.email))
                    return false;
            }

            return true;
        }

        public async void Execute(object parameter)
        {
            var user = (User) parameter;


            LoginClient loginClient = new LoginClient();


            try
            {
                var diag = this.Dialogs.Loading("Please wait ...... Login in progress");

                diag.Show();

                var response = await loginClient.LoginUser(user);

                diag.Hide();
                //  JObject jsonObject= response;
                if (response != null)
                {
                    var returnedUser = JsonConvert.DeserializeObject<RootObject>(response);

                    var serialized = JsonConvert.SerializeObject(response);

                    var jObject = (JObject) JsonConvert.DeserializeObject(response);

                    string message = (string) jObject["message"];

                    //Checking for failed Login
                    if (message != null)
                    {
                        // There is an Error Message, So we can display
                        this.Dialogs.Toast(string.Format("Login failed : {0}", message));
//                        await App.Current.MainPage.DisplayAlert("Login Failed", message,
//                            "Cancel");
                    }
                    else
                    {
                        //Store User Information into the Local Store/ Share Preferences
                        App.Current.Properties["User"] = response;


                        //Redirect if Login is Successfully
                        App.Current.MainPage = (new MasterDetailPage1());
                    }

                    //Successful Login
                }
                else if (response == null)
                {
                    this.Dialogs.Toast(string.Format("Login failed : {0}", "Unable to complete login"));
                }
            }
            catch (Exception ex)
            {
                this.Dialogs.Toast(string.Format("Login failed : {0}", "Unable to complete login"));
            }
        }
    }
}