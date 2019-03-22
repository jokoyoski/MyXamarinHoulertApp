using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Houlert.Logic
{
    
        public class SplashPage : ContentPage
        {
            Image SplashImage;

            public SplashPage()
            {
                NavigationPage.SetHasNavigationBar(this, false);
                var sub = new AbsoluteLayout();
                SplashImage = new Image
                {
                    Source = "Houlert.png",
                    WidthRequest = 100,
                    HeightRequest = 100,
                    Scale = 0

                };
                AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                sub.Children.Add(SplashImage);

                this.BackgroundColor = Color.FromHex("#FF0000");
                this.Content = sub;
            }

            protected override async void OnAppearing()
            {

                base.OnAppearing();
                await SplashImage.ScaleTo(1, 4000, Easing.SpringOut);
                //  await SplashImage.ScaleTo(0.9, 1500, Easing.Linear);
                //  await SplashImage.ScaleTo(150,1200, Easing.Linear);
                Application.Current.MainPage = (new MainPage());
            }
        }
    }


