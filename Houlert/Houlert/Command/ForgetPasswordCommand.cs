using Houlert.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Houlert.Command
{
	public class ForgotPasswordCommand : ICommand
	{
		public NavigateVM navigateVM { get; set; }
		public ForgotPasswordCommand(NavigateVM navigateVM)
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
			App.Current.MainPage.Navigation.PushAsync(new ForgetPasswordPage());
		}
	}
}
