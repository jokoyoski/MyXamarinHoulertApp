using Houlert.Model;
using Houlert.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Houlert.Command
{
   public class GetEditPropertyCommand:ICommand
    {
        public PropertyVM propertyVM { get; set; }
        public GetEditPropertyCommand(PropertyVM propertyVM)
        {
            this.propertyVM = propertyVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           var property= (Property)parameter;
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).Navigation.PushAsync(
                    new EditProperty(property));
           // App.Current.MainPage.Navigation.PushAsync(new EditProperty(property));
        }
    }
}
