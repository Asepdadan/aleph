using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aleph.login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class landing : ContentPage
	{
		public landing ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            

            BindingContext = this;

            var names = new List<Slides>
           {
               new Slides("http://developeraplikasi.com/wp-content/uploads/2018/08/landing-page-1.jpg","lorem ipsum"),
               new Slides("http://developeraplikasi.com/wp-content/uploads/2018/08/landing-page-1.jpg","lorem ipsum"),
               new Slides("http://developeraplikasi.com/wp-content/uploads/2018/08/landing-page-1.jpg","lorem ipsum"),
           };

            MainCarouselView.ItemsSource = names;

            
        }
        
        private async void Button_Login_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Index());
            
        }
    }
}