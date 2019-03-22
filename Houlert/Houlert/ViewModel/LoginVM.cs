using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Acr.UserDialogs;
using Houlert.Command;

using Houlert.Model;

namespace Houlert.ViewModel
{
    public class LoginVm : INotifyPropertyChanged
    {
        private User user;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }


        private string Email;

        public string email
        {
            get { return Email; }
            set
            {
                Email = value;
                User = new User
                {
                    email = this.email,
                    password = this.password,
                };
                OnPropertyChanged("email");
            }
        }


        private string Password;

        public string password

        {
            get { return Password; }
            set
            {
                Password = value;
                User = new User
                {
                    email = this.email,
                    password = this.password,
                };
                OnPropertyChanged("password");
            }
        }


        public LoginUserCommand LoginUserCommand { get; set; }

        public LoginVm()
        {
            LoginUserCommand = new LoginUserCommand(this,UserDialogs.Instance );
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}