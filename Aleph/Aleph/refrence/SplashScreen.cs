using Aleph.home;
using Aleph.login;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Aleph.refrence
{
    public class SplashScreen : ContentPage
    {
        Image splashimage;

        public SplashScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashimage = new Image
            {
                Source = "baseline_fingerprint_black_18.png",
                WidthRequest = 100,
                HeightRequest = 100
            };

            AbsoluteLayout.SetLayoutFlags(splashimage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashimage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashimage);

            this.BackgroundColor = Color.FromHex("#429de1");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("star get data profile");
            await splashimage.ScaleTo(1, 2000);
            Debug.WriteLine("get awal");
            await splashimage.ScaleTo(0.9, 1500, Easing.Linear);
            Debug.WriteLine("get awal 1");
            await splashimage.ScaleTo(150, 1200, Easing.Linear);
            Debug.WriteLine("finish get data");
            Debug.WriteLine("=====local storage=======");
            //Debug.WriteLine(Application.Current.Properties.ContainsKey("status"));
            
            Application.Current.MainPage = new NavigationPage(new landing());
            
            //if (Application.Current.Properties.ContainsKey("status"))
            //{
            //    var currentuserID = (Application.Current.Properties["status "].ToString());

            //    if (currentuserID.Equals("1"))
            //    {
            //        Application.Current.MainPage = new NavigationPage(new HomeIndex());
            //    }
            //    else
            //    {
            //        Application.Current.MainPage = new NavigationPage(new landing());
            //    }
            //}
            //else {
            //    Application.Current.MainPage = new NavigationPage(new landing());
            //}


        }
    }
}
