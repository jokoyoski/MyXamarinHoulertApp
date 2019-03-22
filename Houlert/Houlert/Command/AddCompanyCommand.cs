using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Acr.UserDialogs;
using Houlert.Helper;
using Houlert.Model;
using Acr.UserDialogs;
using Houlert.RestClient;
using Houlert.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Houlert.Command
{
    public class AddCompanyCommand : ICommand
    {
        private Utilities utilities = new Utilities();
        private IUserDialogs Dialogs = UserDialogs.Instance;
        private CompanyClient companyClient = new CompanyClient();
        public CompanyVM CompanyVM { get; set; }

        public AddCompanyCommand(CompanyVM CompanyVM)
        {
            this.CompanyVM = CompanyVM;
        }

        public bool CanExecute(object parameter)
        {
            var company = (Company) parameter;

            if (company == null)
            {
                return false;
            }
            else
            {
                if (!utilities.IsEmailValid(company.email))
                    return false;
            }

            return true;
        }

        public async void Execute(object parameter)
        {
            var company = (Company) parameter;

            if (company.name == null)
            {
                DisplayMessage("Please provide valid company name");
                return;
            }
            else if (company.address == null)
            {
                DisplayMessage("Please provide valid company  address");
                return;
            }
            else if (company.mobile == null || company.mobile.Length < 5)
            {
                DisplayMessage("Please provide valid company phone number ");
                return;
            }


            //Get The Currently Logged In User

            try
            {
                var diag = this.Dialogs.Loading(" Please wait .... ");

                diag.Show();
                var loggedUser = App.Current.Properties["User"].ToString();

                var loggedInUser = JsonConvert.DeserializeObject<UserJson>(loggedUser);

                var user = loggedInUser.User as User;

                var userId = user.id;
                var api_token = user.api_token;

                company.user_id = user.id;


                //Send the Information to API
                var response = await companyClient.AddCompany(company, userId, api_token);
                diag.Hide();

                //Check for Errors

                if (response != null)
                {
                    var deserializeResponse = JsonConvert.DeserializeObject(response);

                    //Lopping througn The Json to Get Message if Any
                    //The presnence of a message meas there is an error

                    var JsonObject = (JObject) deserializeResponse;

                    var message = (string) JsonObject["message"];

                    if (!string.IsNullOrEmpty(message))
                    {
                        DisplayMessage(message);
                    }
                    else
                    {
                        //Go to the Main Page
                        //The Response Should be Company Information

                        //Store the Company Infomation in the Aproperties for Easy Access

                        App.Current.Properties["Company"] = response;

                        DisplayMessage("Company Registration Successful");

                        //Also, Redirect to the Main Application Page
                        App.Current.MainPage = new MasterDetailPage1();
                    }
                }


                //Redirect
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public event EventHandler CanExecuteChanged;


        void DisplayMessage(string message)
        {
            this.Dialogs.Toast(message);
        }
    }
}