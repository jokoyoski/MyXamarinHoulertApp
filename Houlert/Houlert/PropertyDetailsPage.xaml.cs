using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlert.Model;
using Houlert.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Houlert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyDetailsPage : ContentPage
    {
        public PropertyVM PropertyVm { get; set; }

       // public Property Property { get; set; }

        public PropertyDetailsPage(Property property)
        {

           
            PropertyVm = new PropertyVM {Property = property};
            BindingContext = PropertyVm;
            InitializeComponent();
        }
    }
}