using System;
using System.Net.Http;
using Acr.UserDialogs;
using Houlert.Helper;
using Houlert.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Houlert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPropertyImagesPage : ContentPage
    {
        private MediaFile mediaFile;
        private Property property;

        private IUserDialogs Dialogs = UserDialogs.Instance;

        public UploadPropertyImagesPage(Property property)
        {
            this.property = property;
            InitializeComponent();
        }

        private async void UploadFile_Clicked(object sender, EventArgs e)
        {
            var dialog = this.Dialogs.Loading("Uploading Property Photo.....");
            dialog.Show();
            //Get The Logged In User and Token and Bind to Uploaded Property
            var propertyId = property.id;
            var loggedUser = App.Current.Properties["User"].ToString();

            //Get The Logged In User
            var loggedInUser = JsonConvert.DeserializeObject<UserJson>(loggedUser);

            var user = loggedInUser.User as User;

            var userId = user.id;
            var token = user.api_token;


            var content = new MultipartFormDataContent();


            content.Add(new StreamContent(mediaFile.GetStream()),
                "\"file\"",
                $"\"{mediaFile.Path}\"");

            var httpClient = new HttpClient();

            var uri = string.Format(Constant.RestUrl + "{0}?property_id={1}&user_id={2}&api_token={3}",
                "property/upload", propertyId, userId, token);
            var httpResponse = await httpClient.PostAsync(uri, content);

            //  RemotePathLabel.Text = await httpResponse.Content.ReadAsStringAsync();
            var response = await httpResponse.Content.ReadAsStringAsync();

            dialog.Hide();
            var deserializeResponse = JsonConvert.DeserializeObject(response);

            //Lopping througn The Json to Get Message if Any
            //The presnence of a message meas there is an error

            var JsonObject = (JObject) deserializeResponse;

            var message = (string) JsonObject["message"];

            if (!string.IsNullOrEmpty(message))
            {
                this.Dialogs.Alert("Upload failed, please try again", "Houlert", "Ok");
                return;
                
            }
           

            this.Dialogs.Alert("Property Image Uploaded, Click Ok upload more", "Houlert", "OK");
        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No PickPhoto", "No Photo Available", "OK");
                return;
            }

            mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "myImage.jpg"
            });

            if (mediaFile == null)
            {
                return;
            }

            LocalPathLabel.Text = mediaFile.Path;
            FileImage.Source = ImageSource.FromStream(() => { return mediaFile.GetStream(); });
            FileImage.IsVisible = true;
        }


        private async void PickPhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No PickPhoto", "No Photo Available", "OK");
                return;
            }

            mediaFile = await CrossMedia.Current.PickPhotoAsync();
            if (mediaFile == null)
            {
                return;
            }

            LocalPathLabel.Text = mediaFile.Path;
            FileImage.Source = ImageSource.FromStream(() => { return mediaFile.GetStream(); });
            FileImage.IsVisible = true;
        }
    }
}