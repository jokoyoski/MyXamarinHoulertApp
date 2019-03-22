using Houlert.ViewModel;
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
    public partial class LoginPage : ContentPage
    {
        public LoginVm LoginVm { get; set; }

        public LoginPage()
        {
            LoginVm = new LoginVm();

            BindingContext = LoginVm;
            InitializeComponent();
        }
    }
}