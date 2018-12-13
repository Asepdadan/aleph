using Aleph.login;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aleph.home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeIndex : ContentPage
	{
		public HomeIndex ()
		{
            var username = Application.Current.Properties["isLogged"] as string;
            DisplayAlert("Infor", username, "Ok");

            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            BindingContext = this;

            var names = new List<Slides>
           {
               new Slides("http://developeraplikasi.com/wp-content/uploads/2018/08/landing-page-1.jpg","lorem ipsum 1"),
               new Slides("https://images.pexels.com/photos/754082/pexels-photo-754082.jpeg?cs=srgb&dl=blur-blurred-background-colors-754082.jpg&fm=jpg","lorem ipsum 3"),
               new Slides("https://jooinn.com/images/nature-319.jpg","lorem ipsum 5"),
           };

            MainCarouselView.ItemsSource = names;


            
        }
	}
}