using Houlert.Model;
using Houlert.RestClient;
using Houlert.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Houlert.Command
{
    //this coomand helps to navigate to th register view
    public class RegisterCommand : ICommand
    {
        public NavigateVM navigateVM { get; set; }

        public RegisterCommand(NavigateVM navigateVM)
        {
            this.navigateVM = navigateVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}