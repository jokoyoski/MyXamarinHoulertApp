using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Houlert.Command;
using Houlert.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Houlert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1Master : ContentPage
    {
        public ListView ListView;

        public MasterDetailPage1Master()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPage1MasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPage1MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPage1MenuItem> MenuItems { get; set; }
            
            public MasterDetailPage1MasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPage1MenuItem>(new[]
                {
					new MasterDetailPage1MenuItem { Title = "Add Property", Icon="home.png",TargetType = typeof(AddProperty) },
					new MasterDetailPage1MenuItem { Id = 1, Title = "Calendar",Icon="calendar_today.png", TargetType=typeof(Calendar) },
					new MasterDetailPage1MenuItem { Id = 2, Title = "Leads", Icon="wallet.png",TargetType=typeof(Leads) },

					new MasterDetailPage1MenuItem { Id = 3, Title = "Listing",Icon="numbered.png",TargetType=typeof(Listings) },
					new MasterDetailPage1MenuItem { Id = 4, Title = "Referrals",Icon="accessibility.png",TargetType=typeof(Referral) },
					new MasterDetailPage1MenuItem { Id = 5, Title = "Statistics",Icon="track.png",TargetType=typeof(Statistics) },
					new MasterDetailPage1MenuItem { Id = 6, Title = "Subscriptions",Icon="subscribe.png",TargetType=typeof(Subscription) },
					new MasterDetailPage1MenuItem { Id = 7, Title = "Syndication",Icon="business_center.png",TargetType=typeof(Syndication) },
					new MasterDetailPage1MenuItem { Id = 8, Title = "Logout",Icon="business_center.png", TargetType = typeof(Logout)},
				});
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}