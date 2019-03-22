using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Houlert.RestClient;
using Newtonsoft.Json;

namespace Houlert.Model
{
    public class Property : INotifyPropertyChanged
    {
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


        private string Title;

        public string title
        {
            get { return Title; }
            set
            {
                Title = value;
                OnPropertyChanged("title");
            }
        }


        private int Property_Purpose_Id;

        public int property_purpose_id
        {
            get { return Property_Purpose_Id; }
            set
            {
                Property_Purpose_Id = value;
                OnPropertyChanged("property_purpose_id");
            }
        }


        private int Property_Use_Id;

        public int property_use_id
        {
            get { return Property_Use_Id; }
            set
            {
                Property_Use_Id = value;
                OnPropertyChanged("property_use_id");
            }
        }


        private int Property_Type_Id;

        public int property_type_id
        {
            get { return Property_Type_Id; }
            set
            {
                Property_Type_Id = value;
                OnPropertyChanged("property_type_id");
            }
        }


        private int Property_Sub_Type_Id;

        public int property_sub_type_id
        {
            get { return Property_Sub_Type_Id; }
            set
            {
                Property_Sub_Type_Id = value;
                OnPropertyChanged("property_sub_type_id");
            }
        }

        private string Bedroom;

        public string bedroom
        {
            get { return Bedroom; }
            set
            {
                Bedroom = value;
                OnPropertyChanged("bedroom");
            }
        }


        private string Bathroom;

        public string bathroom
        {
            get { return Bathroom; }
            set
            {
                Bathroom = value;
                OnPropertyChanged("bathroom");
            }
        }

        private string Toilet;

        public string toilet
        {
            get { return Toilet; }
            set
            {
                Toilet = value;
                OnPropertyChanged("toilet");
            }
        }

        private string Short_Description;

        public string short_description
        {
            get { return Short_Description; }
            set
            {
                Short_Description = value;
                OnPropertyChanged("short_description");
            }
        }

        private string Description;

        public string description
        {
            get { return Description; }
            set
            {
                Description = value;
                OnPropertyChanged("description");
            }
        }


        private string Price;

        public string price
        {
            get { return Price; }
            set
            {
                Price = value;
                OnPropertyChanged("price");
            }
        }


        private int Currency;

        public int currency
        {
            get { return Currency; }
            set
            {
                Currency = value;
                OnPropertyChanged("currency");
            }
        }

        private string Street;

        public string street
        {
            get { return Street; }
            set
            {
                Street = value;
                OnPropertyChanged("street");
            }
        }

        private int Area_Id;

        public int area_id
        {
            get { return Area_Id; }
            set
            {
                Area_Id = value;
                OnPropertyChanged("area_id");
            }
        }

        private int Locality_Id;

        public int locality_id
        {
            get { return Locality_Id; }
            set
            {
                Locality_Id = value;
                OnPropertyChanged("locality_id");
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

        private int Company_Id;

        public int company_id
        {
            get { return Company_Id; }
            set
            {
                Company_Id = value;
                OnPropertyChanged("company_id");
            }
        }


        private int Duration;

        public int duration
        {
            get { return Duration; }
            set
            {
                Duration = value;
                OnPropertyChanged("duration");
            }
        }


        private string CreatedAt;

        public string created_at
        {
            get { return CreatedAt; }
            set
            {
                CreatedAt = value;
                OnPropertyChanged("created_at");
            }
        }

        private State State;
        public State state
        {
 
            get { return State;  }
            set
            {
                State = value;
                OnPropertyChanged("state");
            }
        }


        private Locality Locality;
        public Locality locality
        {

            get { return Locality; }
            set
            {
                Locality = value;
                OnPropertyChanged("locality");
            }
        }

        private Locality Area;
        public Locality area
        {

            get { return Area; }
            set
            {
                Area = value;
                OnPropertyChanged("area");
            }
        }


        private PropertyPurpose Property_Purpose;
        public PropertyPurpose property_purpose
        {

            get { return Property_Purpose; }
            set
            {
                Property_Purpose = value;
                OnPropertyChanged("property_purpose");
            }
        }


        private PropertyUse Property_Use;

        public PropertyUse property_use
        {
            get { return Property_Use; }
            set
            {
                Property_Use = value;
                OnPropertyChanged("property_use");
            }
        }



        private PropertyType Property_Type;

        public PropertyType property_type
        {
            get { return Property_Type; }
            set
            {
                Property_Type = value;
                OnPropertyChanged("property_type");
            }
        }



        private PropertySubType Property_Sub_Type;

        public PropertySubType property_sub_type
        {
            get { return Property_Sub_Type; }
            set
            {
                Property_Sub_Type = value;
                OnPropertyChanged("property_sub_type");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        //======================= Methods Here======================

        public async Task<List<Property>> Properties()
        {
            //Get The Logge In User
            //Get The Currently Logged In User
            var loggedUser = App.Current.Properties["User"].ToString();

            var user = JsonConvert.DeserializeObject<UserJson>(loggedUser);

            var userId = user.User.id;
            var api_token = user.User.api_token;

            var response = await PropertyClient.Properties(userId, api_token);

            return response;
        }

        public string BedRoomToString
        {
            get { return bedroom.ToString(); }
        }
    }

    public class PropertyList
    {
        public List<Property> properties { get; set; }
    }

    public class PropertyRoot
    {
        public Property Property { get; set; }
    }
}