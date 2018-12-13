using Aleph.home;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aleph.login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Index : ContentPage
	{

        HttpClient client;
        
        
        public Index ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            BindingContext = this;

            not_accountLabelFunct();
            IsBusy = false;

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            
        }

        void not_accountLabelFunct()
        {
            not_accountLabel.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new landing());
                }),
            });
        }

        public static void CheckLogin()
        {
            
        }

        private Uri loginURL;

        private async void LoginFunc(Object sender, EventArgs e)
        {
            IsBusy = true;
            //var uri = new Uri("https://randomuser.me/api/");
            var username = Username.Text;
            var password = Password.Text;

            var location = await Geolocation.GetLastKnownLocationAsync();

            loginURL = new Uri("http://erp.gs1id.org/getMBL-INUX-VERIFY.asp?c=" + username + "&d=" + password + "&latitude:" + location.Latitude.ToString() + "&Longitude" + location.Latitude.ToString());


            var response = await client.GetAsync(loginURL);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //var jsonParse = JsonConvert.DeserializeObject(content).ToString();
                var jsonParse = JObject.Parse(content);
                //var jsonParseName = JsonConvert.DeserializeObject(content);
                //var jsonParseName = JObject.Parse(jsonParse);
                Debug.WriteLine(jsonParse["status"].ToString());
                Debug.WriteLine(location);
                var result = jsonParse["status"].ToString();
                if (result.Equals("1"))
                {
                    //DisplayAlert("Informasi", "Berhasil Login", "Ok");
                    Application.Current.Properties["info_user "] = jsonParse;
                    Application.Current.Properties["status"] = result;
                    Application.Current.Properties.Add("isLogged", Boolean.TrueString);
                    Application.Current.SavePropertiesAsync();

                    IsBusy = false;
                    Application.Current.MainPage = new NavigationPage(new HomeIndex());                    
                }
                else {
                    DisplayAlert("Informasi", "Gagal Login", "Ok");
                    IsBusy = false;
                }
                //string json = Encoding.UTF8.GetString(jsonParse);

                //if (json["status"] == 1)
                //{
                //    DisplayAlert("Informasi", "Berhasil Login", "Ok");
                //    IsBusy = false;
                //}
                //else {
                //DisplayAlert("Informasi", "Berhasil Login", "Ok");
                //IsBusy = false;
                //}
                //Debug.WriteLine(jsonParseName["results"]);
                //Debug.WriteLine(content);
                //Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
            }
        }
    }
}