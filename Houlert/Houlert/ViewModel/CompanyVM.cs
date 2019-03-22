using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Houlert.Command;
using Houlert.Model;

namespace Houlert.ViewModel
{
    public class CompanyVM : INotifyPropertyChanged
    {
        private Company company;

        public Company Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }

        private string Name;

        public string name
        {
            get { return Name; }
            set
            {
                Name = value;
                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };

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
                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };
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
                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };
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
                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };
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
                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };
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
                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };
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
                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };
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
                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };
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
                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };
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
                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };
                OnPropertyChanged("id");
            }
        }

        public List<State> States { get; set; }
        //Location
        private State State;

        public State state
        {
            get { return State; }
            set
            {
                State = value;

                state_id = State.id;

                Company = new Company
                {
                    address = this.address,
                    created_at = this.created_at,
                    website = this.website,
                    email = this.email,
                    state_id = this.state_id,
                    name = this.name,
                    user_id = this.user_id,
                    id = this.id,
                    logo = this.logo,
                    mobile = this.mobile,
                };
                OnPropertyChanged("state");
            }
        }

       
        public AddCompanyCommand AddCompanyCommand { get; set; }

        public CompanyVM()
        {
            this.AddCompanyCommand = new AddCompanyCommand(this);
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