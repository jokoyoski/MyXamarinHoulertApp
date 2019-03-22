using Houlert.Command;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterVM registerVM { get; set; }

        public RegisterPage()
        {
            //bnding the viewmodel to the xaml page
            registerVM = new RegisterVM();
            BindingContext = registerVM;
            InitializeComponent();
        }
    }
}