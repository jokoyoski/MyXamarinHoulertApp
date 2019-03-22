using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Houlert.Model;
using Houlert.ViewModel;

namespace Houlert.Command
{
    public class PropertyDetailsCommand:ICommand
    {
        public PropertyVM PropertyVm { get; set; }

        public PropertyDetailsCommand(PropertyVM PropertyVm)
        {
            this.PropertyVm = PropertyVm;
        }

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
           // var property = (Property) parameter;
          //  App.Current.MainPage.Navigation.PushAsync(new PropertyDetailsPage(property));
        }

        public event EventHandler CanExecuteChanged;
    }
}