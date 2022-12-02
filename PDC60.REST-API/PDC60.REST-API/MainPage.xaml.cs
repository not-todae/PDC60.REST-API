using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Net.Http;

namespace PDC60.REST_API
{
    public class Post
    {

        public int ID { get; set; }
        public string username { get; set; }

        public string userpassword { get; set; }
        public string email { get; set; }

    }

        public partial class MainPage : ContentPage
        {

            private const string url = "";
                private HttpClient _Client = new HttpClient();
            private ObservableCollection<Post> _post;
            public MainPage()
            {


                InitializeComponent();
            }

            protected override async void OnAppearing()
            {

            var content = await _Client.GetStringAsync(url); 
            var post = JsonConvert.DeserializeObject<List<Post>>(content);
            _post = new ObservableCollection<Post>(post);
            Post_List.ItemsSource =_post;
            base.OnAppearing();

            }

        }
    }


