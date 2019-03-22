using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Plugin.Media;
using Xamarin.Forms;
using Acr.UserDialogs;
using Houlert.Model;
using Houlert.ViewModel;
using Plugin.Media.Abstractions;


namespace Houlert.Command
{
    public class UploadFileCommand : ICommand
    {
        public IUserDialogs Dialogs { get; }
        private MediaFile mediaFile;
        public Company Company{ get; set; }

        public UploadFileCommand(Company Company)
        {
            this.Company = Company;
            this.Dialogs = UserDialogs.Instance;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
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

            this.Company.logo = mediaFile.Path;

            // LocalPathLabel.Text = mediaFile.Path;
            // App.Current.MainPage.FileImage.Source = ImageSource.FromStream(() => { return mediaFile.GetStream(); });
        }

        public event EventHandler CanExecuteChanged;
    }
}