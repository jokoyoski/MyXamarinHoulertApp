using Houlert.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Houlert.ViewModel
{
    public class NavigateVM
    {
        public ForgotPasswordCommand forgotpasswordCommand { get; set; }

        public LoginCommand loginCommand { get; set; }
       
        public RegisterCommand RegisterCommand { get; set; }

        public NavigateVM()
        {
            //Register User
            RegisterCommand = new RegisterCommand(this);

            //Forgot Password Navigation command
            forgotpasswordCommand = new ForgotPasswordCommand(this);

            loginCommand = new LoginCommand(this);
           
       
        }
    }
}