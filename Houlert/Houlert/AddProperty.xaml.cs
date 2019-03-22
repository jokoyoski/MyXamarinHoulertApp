using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Houlert.Helper;
using Houlert.Model;
using Houlert.RestClient;
using Houlert.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Houlert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProperty : ContentPage
    {
        private PropertyVM propertyVm { get; set; }

        private LocationDropDown LocationDropDown = new LocationDropDown();
        private IUserDialogs Dialogs = UserDialogs.Instance;
       

        public AddProperty()
        {
            propertyVm = new PropertyVM();
            BindingContext = propertyVm;

           

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var dialog = this.Dialogs.Loading();
            dialog.Show();
            BindingContext = new PropertyVM
            {
                Property_types = await this.GetPropertyType(),
                PropertySubTypes = await this.GetPropertySubType(),
                PropertyPurposes = await this.GetPropertyPurposes(),
                PropertyUses = await this.GetPropertyUse(),
                States = await LocationDropDown.GetStates(),
                Localities = await LocationDropDown.GetLocalities(),
                areas = await LocationDropDown.GetArea()
            };

            dialog.Hide();
            //   base.OnAppearing();
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