using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Houlert
{
   public  class SplashScreen:ContentPage
    {
		Image image;
	

		public SplashScreen()
		{

			NavigationPage.SetHasNavigationBar(this, false);
			var sub = new AbsoluteLayout();
			image = new Image
			{

				Source="Houlettlogo.png",
				WidthRequest=100,
				HeightRequest=100,
				
			};
	
			AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			this.BackgroundColor = Color.FromHex("#FF0000");
			this.Content = sub;
		}


		protected override  async void OnAppearing()
		{
			base.OnAppearing();
			//bring the picture out for 2seconds
			await image.ScaleTo(5, 5000,Easing.SpringOut);
			Application.Current.MainPage = new NavigationPage(new MainPage());


		}
	}
}
