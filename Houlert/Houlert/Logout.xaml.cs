using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Houlert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logout : ContentPage
    {
        public Logout()
        {
            InitializeComponent();
           
        }

        protected override void OnAppearing()
        {
            App.Current.Properties.Remove("User");

            App.Current.MainPage = new LoginPage();
            base.OnAppearing();
            
        }
    }
}