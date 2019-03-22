using Houlert.RestClient;
using Houlert.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Houlert
{
    public partial class MainPage : ContentPage
    {
        public NavigateVM navigateVM;

        public MainPage()
        {
            navigateVM = new NavigateVM();
            BindingContext = navigateVM;
            InitializeComponent();

            var assembly = typeof(MainPage);
           // IconImage.Source = ImageSource.FromResource("Houlert.Assets.Images.logo.png",assembly);
        }


        
        public void OnTappedGesture(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCompanyPage());
        }
    }
}