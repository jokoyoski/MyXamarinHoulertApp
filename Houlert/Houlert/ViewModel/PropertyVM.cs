using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Houlert.Command;
using Houlert.Model;
using Xamarin.Forms;

namespace Houlert.ViewModel
{
    public class PropertyVM : INotifyPropertyChanged
    {
        

        //Property Settings
        public List<Property> Properties { get; set; }

        private Property property;

        public Property Property
        {
            get { return property; }
            set
            {
                property = value;
                

                OnPropertyChanged("Property");
            }
        }


        //the Id of the property we need to pass for Edit
        //  public int PropertyId { get; set;}

        private int Id;
        public  int id
       
        {
            get { return Id; }
            set
            {
                Id = value;
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id = this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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

                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
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
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
                OnPropertyChanged("state_id");
            }
        }

        //=================Selected Property
        public Property SelectedProperty { get; set; }

        //--------------------- Property Types and Settings ------------------//
        public List<PropertyType> Property_types { get; set; }
        public List<PropertySubType> PropertySubTypes { get; set; }
        public List<PropertyPurpose> PropertyPurposes { get; set; }
        public List<PropertyUse> PropertyUses { get; set; }


        //Location Settings =======================//
        public List<State> States { get; set; }
        public List<Locality> Localities { get; set; }
        public List<Area> areas { get; set; }


        private PropertyType Property_Type;

        public PropertyType property_type
        {
            get { return Property_Type; }
            set
            {
                Property_Type = value;

                property_type_id = Property_Type.id;

                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                };
                OnPropertyChanged("property_type");
            }
        }


        private PropertySubType Property_SubType;

        public PropertySubType property_subtype
        {
            get { return Property_SubType; }
            set
            {
                Property_SubType = value;

                property_sub_type_id = Property_SubType.id;

                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                };

                OnPropertyChanged("property_subtype");
            }
        }

        private PropertyPurpose Property_Purpose;

        public PropertyPurpose property_purpose
        {
            get { return Property_Purpose; }
            set
            {
                Property_Purpose = value;

                property_purpose_id = Property_Purpose.id;

                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                };
                OnPropertyChanged("property_purpose");
            }
        }


        private PropertyPurpose Property_Use;

        public PropertyPurpose property_use
        {
            get { return Property_Use; }
            set
            {
                Property_Use = value;

                property_use_id = Property_Use.id;
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                };
                OnPropertyChanged("property_use");
            }
        }


        //Location
        private State State;

        public State state
        {
            get { return State; }
            set
            {
                State = value;

                state_id = State.id;
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                };
                OnPropertyChanged("state");
            }
        }


        private Area Area;

        public Area area
        {
            get { return Area; }
            set
            {
                Area = value;

                state_id = State.id;
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                };
                OnPropertyChanged("area");
            }
        }


        //private Property editProperty;

        //public Property EditProperty
        //{
        //    get { return editProperty; }
        //    set
        //    {
        //        editProperty = value;

        //        //passing the Id as parameter to the view 
        //        App.Current.MainPage.Navigation.PushAsync(new EditProperty(editProperty.id));
        //    }
        //}

        private Locality Locality;

        public Locality locality
        {
            get { return Locality; }
            set
            {
                Locality = value;

                locality_id = Locality.id;
                Property = new Property
                {
                    title = this.title,
                    bathroom = this.bathroom,
                    bedroom = this.bedroom,
                    currency = this.currency,
                    description = this.description,
                    short_description = this.short_description,
                    area_id = this.area_id,
                    locality_id = this.locality_id,
                    property_purpose_id = this.property_purpose_id,
                    price = this.price,
                    property_sub_type_id = this.property_sub_type_id,
                    property_type_id = this.property_type_id,
                    property_use_id = this.property_use_id,
                    toilet = this.toilet,
                    state_id = this.state_id,
                    street = this.street,
                    id=this.id
                };
                OnPropertyChanged("locality");
            }
        }


        //The View Property Page

        public PropertyDetailsCommand PropertyDetailsCommand { get; set; }


        public PostPropertyCommand PostPropertyCommand { get; set; }
        public PostEditPropertyCommand EditPropertyCommand { get; set; }

        public GetEditPropertyCommand editPropertyCommand { get; set; }
        public PropertyVM()
        {
            EditPropertyCommand = new PostEditPropertyCommand(this);
            PostPropertyCommand = new PostPropertyCommand(this);
            PropertyDetailsCommand = new PropertyDetailsCommand(this);
            editPropertyCommand = new GetEditPropertyCommand(this);
        }

        public PropertyVM(Property property)
        {
            this.Property = property;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}