using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Houlert.Model
{
    public class UserJson
    {
        public User User { get; set; }
    }

    public class User : INotifyPropertyChanged
    {
        private int Id;

        public int id
        {
            get => Id;
            set
            {
                Id = value;
                OnPropertyChanged("id");
            }
        }

        private string First_Name;

        public string first_name
        {
            get { return First_Name; }
            set
            {
                First_Name = value;
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
                OnPropertyChanged("user_type");
            }
        }

        private string Password;

        public string password
        {
            get { return Password; }
            set
            {
                Password = value;
                OnPropertyChanged("password");
            }
        }

        private string Password_Confirmation;

        public string password_confirmation
        {
            get { return Password_Confirmation; }
            set
            {
                Password_Confirmation = value;
                OnPropertyChanged("password_confirmation");
            }
        }

//        private int Company_Id;
//
//        public int company_id
//        {
//            get { return Company_Id; }
//            set
//            {
//                Company_Id = value;
//                OnPropertyChanged("company_id");
//            }
//        }


        private string Api_Token;

        public string api_token
        {
            get { return Api_Token; }
            set
            {
                Api_Token = value;
                OnPropertyChanged("api_token");
            }
        }

        //private DateTime updated_at;

        //public DateTime Updated_at
        //{
        //    get { return updated_at; }
        //    set
        //    {
        //        updated_at = value;
        //        OnPropertyChanged("Updated_at");

        //    }
        //}

        //private DateTime created_at;

        //public DateTime Created_at
        //{
        //    get { return created_at; }
        //    set
        //    {
        //        created_at = value;
        //        OnPropertyChanged("Updated_at");

        //    }
        //}


        //private DateTime id;

        //public DateTime Id
        //{
        //    get { return id; }
        //    set
        //    {
        //        id = value;
        //        OnPropertyChanged("Id");

        //    }
        //}


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