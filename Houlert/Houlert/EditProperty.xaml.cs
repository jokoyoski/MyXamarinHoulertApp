using Acr.UserDialogs;
using Houlert.Helper;
using Houlert.Model;
using Houlert.RestClient;
using Houlert.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Houlert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProperty : ContentPage
    {
        List<Area> aread = new List<Area>();
        private Property property { get; set; }
        private IUserDialogs Dialogs = UserDialogs.Instance;

        private LocationDropDown LocationDropDown = new LocationDropDown();

        //getting the Id  to the xml
        public PropertyVM propertyVM { get; set; }

        public EditProperty(Property property)
        {
            this.property = property;
            this.propertyVM = new PropertyVM();
            this.BindingContext = propertyVM;


            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            var dialog = this.Dialogs.Loading();
            dialog.Show();

            var propertyPurpose = await this.GetPropertyPurposes();
            var propertyType = await this.GetPropertyType();
            var propertySubType = await this.GetPropertySubType();
            var propertyUse = await this.GetPropertyUse();
            var propertyState = await this.LocationDropDown.GetStates();
            var propertyLocality = await LocationDropDown.GetLocalities();
            var propertyArea = await LocationDropDown.GetArea();

            //Gettting the Index of the Selected Elemet to set as the Element
            BindingContext = new PropertyVM
            {
                title = property.title,
                area_id = property.area_id,
                bedroom = property.bedroom,
                bathroom = property.bathroom,
                currency = property.currency,
                description = property.description,
                short_description = property.short_description,
                locality_id = property.locality_id,
                property_purpose_id = property.property_purpose_id,
                price = property.price,
                property_sub_type_id = property.property_sub_type_id,
                property_type_id = property.property_type_id,
                property_use_id = property.property_use_id,
                toilet = property.toilet,
                state_id = property.state_id,
                street = property.street,
                Property = property,

                Property_types = propertyType,
                PropertySubTypes = propertySubType,
                PropertyPurposes = propertyPurpose,
                PropertyUses = propertyUse,
                States = propertyState,
                Localities = propertyLocality,
                areas = propertyArea,
                id=property.id
            };


            //Setting Index of the Selected Dropdowsn
            PropertyPurposeList.SelectedIndex =
                propertyPurpose.FindIndex(purposes => purposes.id == property.property_purpose_id);

            PropertyTypeList.SelectedIndex =
                propertyType.FindIndex(types => types.id == property.property_type_id);

            PropertySubTypeList
                    .SelectedIndex =
                propertySubType.FindIndex(subTypes => subTypes.id== property.property_sub_type_id);

            PropertyUseList.SelectedIndex =
                propertyUse.FindIndex(uses => uses.id == property.property_use_id);

            StateList.SelectedIndex =
                propertyState.FindIndex(states => states.id == property.state_id);

            AreaList.SelectedIndex =
                propertyArea.FindIndex(areas => areas.id == property.area_id);

            LocalityList.SelectedIndex =
                propertyLocality.FindIndex(localities => localities.id == property.locality_id);

            dialog.Hide();

            base.OnAppearing();
        }


        //Get Property Types
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<PropertyType>> GetPropertyType()
        {
            List<PropertyType> propertyTypes;
            propertyTypes = await PropertyClient.GetPropertyTypes();
            return propertyTypes.ToList();
            // return PropertyList.ItemsSource = propertyTypes.ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<PropertySubType>> GetPropertySubType()
        {
            var propertySubTypes = await PropertyClient.GetPropertySubTypes(1);
            return propertySubTypes.ToList();
        }


        /// <summary>
        /// Get Property Purpsoes
        /// </summary>
        /// <returns></returns>
        public async Task<List<PropertyPurpose>> GetPropertyPurposes()
        {
            var propertyPurposes = await PropertyClient.GetPropertyPurpose();
            return propertyPurposes.ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<PropertyUse>> GetPropertyUse()
        {
            var propertyUses = await PropertyClient.GetPropertyUse();
            return propertyUses.ToList();
        }
    }
}