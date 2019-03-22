using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Houlert.Model;
using Houlert.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Houlert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listings : ContentPage
    {
        private PropertyVM propertyVm { get; set; }
        private IUserDialogs Dialogs = UserDialogs.Instance;

        public Listings()
        {
            BindingContext = propertyVm;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var dialog = this.Dialogs.Loading();
            dialog.Show();
            var property = new Property();
            //Get The Query Tha Calls all The Property That Belongs to This User
            BindingContext = new PropertyVM
            {
                Properties = await property.Properties()
            };
//           
            dialog.Hide();
//            var properties = await property.Properties();
            //listingListView.ItemsSource = properties;
            base.OnAppearing();
        }

        private void List_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Property property)
            {
           
               // (App.Current.MainPage as MasterDetailPage).IsPresented = true;
                ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).Navigation.PushAsync(
                    new PropertyDetailsPage(property));

                //  App.Current.MainPage= new PropertyDetailsPage(property);
            }
        }
    }
}