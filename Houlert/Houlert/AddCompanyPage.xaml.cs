using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Houlert.Helper;
using Houlert.Model;
using Houlert.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Houlert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCompanyPage : ContentPage
    {
        private CompanyVM CompanyVm { get; set; }
        public IUserDialogs Dialogs { get; }
        private MediaFile mediaFile;
        public Company Company { get; set; }

        private LocationDropDown LocationDropDown = new LocationDropDown();

        public AddCompanyPage()
        {
            CompanyVm = new CompanyVM();
            BindingContext = CompanyVm;

            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            BindingContext = new CompanyVM
            {
                States = await LocationDropDown.GetStates(),
            };

            base.OnAppearing();
        }


        private async void UploadLogo(object sender, EventArgs e)
        {
            //Upload Command Here
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                this.Dialogs.Toast("No Photo Available");
                return;
            }

            mediaFile = await CrossMedia.Current.PickPhotoAsync();
            if (mediaFile == null)
            {
                return;
            }

           // LocalPathLabel.Text = mediaFile.Path;
           // FileImage.Source = ImageSource.FromStream(() => { return mediaFile.GetStream(); });
        }
    }
}