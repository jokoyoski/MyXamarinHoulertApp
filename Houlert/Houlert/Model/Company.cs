using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace Houlert.Model
{
    public class Company : INotifyPropertyChanged
    {
        private string Name;

        public string name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("name");
            }
        }

        private string Mobile;

        public string mobile
        {
            get { return Mobile; }
            set
            {
                Mobile = value;
                OnPropertyChanged("mobile");
            }
        }

        private string Address;

        public string address
        {
            get { return Address; }
            set
            {
                Address = value;
                OnPropertyChanged("address");
            }
        }

        private string Website;

        public string website
        {
            get { return Website; }
            set
            {
                Website = value;
                OnPropertyChanged("website");
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


        private int State_Id;

        public int state_id
        {
            get { return State_Id; }
            set
            {
                State_Id = value;
                OnPropertyChanged("state_id");
            }
        }


        private string Logo;

        public string logo
        {
            get { return Logo; }
            set
            {
                Logo = value;
                OnPropertyChanged("logo");
            }
        }


        private int User_Id;

        public int user_id
        {
            get { return User_Id; }
            set
            {
                User_Id = value;
                OnPropertyChanged("user_id");
            }
        }


        private string Created_At;

        public string created_at
        {
            get { return Created_At; }
            set
            {
                Created_At = value;
                OnPropertyChanged("created_at");
            }
        }


        private int Id;

        public int id
        {
            get { return Id; }
            set
            {
                Id = value;
                OnPropertyChanged("id");
            }
        }


       


        public class CompanyRoot
        {
            public Company Company { get; set; }
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