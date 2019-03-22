using Houlert.Command;
using Houlert.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Houlert.ViewModel
{
    public class RegisterVM : INotifyPropertyChanged
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

        private string First_Name;

        public string first_name
        {
            get { return First_Name; }
            set
            {
                First_Name = value;
                User = new User
                {
                    first_name = this.first_name,
                    last_name = this.last_name,
                    email = this.email,
                  
                    password = this.password,
                    password_confirmation = this.password_confirmation
                };
                OnPropertyChanged("first_name");
            }
        }


        private string Last_Name;

        public string last_name
        {
            get { return Last_Name; }
            set
            {
                Last_Name = value;
                User = new User
                {
                    first_name = this.first_name,
                    last_name = this.last_name,
                    email = this.email,
                   
                    password = this.password,
                    password_confirmation = this.password_confirmation
                };
                OnPropertyChanged("last_name");
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
                    first_name = this.first_name,
                    last_name = this.last_name,
                    email = this.email,
                  
                    password = this.password,
                    password_confirmation = this.password_confirmation
                };
                OnPropertyChanged("email");
            }
        }

        private int User_Type;

        public int user_type
        {
            get { return User_Type; }
            set
            {
                User_Type = value;
                User = new User
                {
                    first_name = this.first_name,
                    last_name = this.last_name,
                    email = this.email,
                 
                    password = this.password,
                    password_confirmation = this.password_confirmation
                };
                OnPropertyChanged("user_type");
            }
        }

        private string Password_Confirmation;

        public string password_confirmation
        {
            get { return Password_Confirmation; }
            set
            {
                Password_Confirmation = value;
                User = new User
                {
                    first_name = this.first_name,
                    last_name = this.last_name,
                    email = this.email,
                  
                    password = this.password,
                    password_confirmation = this.password_confirmation
                };
                OnPropertyChanged("password_confirmation");
            }
        }


        private string Password;

        public string password

        {
            get {
                return Password;
            }
            set
            {
                Password = value;
                User = new User
                {
                    first_name = this.first_name,
                    last_name = this.last_name,
                    email = this.email,
                   
                    password = this.password,
                    password_confirmation = this.password_confirmation
                };
                OnPropertyChanged("password");
            }
        }


        public RegistrationCommand registerCommand { get; set; }

        public RegisterVM()
        {
            registerCommand = new RegistrationCommand(this);
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