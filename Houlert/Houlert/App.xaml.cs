using Houlert.Logic;
using System;
using Acr.UserDialogs;
using Houlert.Model;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Houlert
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            //  ettings userData = JsonConvert.DeserializeObject<Settings>(App.Current.Properti‌​es["UserDetail"]);


            // Current.Properties.Remove("User");

            try
            {
                //   MainPage = new NavigationPage(new MainPage());
                if (Current.Properties.ContainsKey("User"))
                {
                    var user = App.Current.Properties["User"].ToString();

                    var loggedInUser = JsonConvert.DeserializeObject<UserJson>(user);
                    MainPage = new MasterDetailPage1();
                }
                else
                {
                    MainPage = new NavigationPage(new MainPage());
                }
            }
            catch (AggregateException e)
            {
                Console.WriteLine("An Error has occured", e);
            }
        }

        protected override void OnStart()
        {
            AppCenter.Start("22272f0b-8c08-493e-83c7-f9f658fe1cf8", typeof(Push));

            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}