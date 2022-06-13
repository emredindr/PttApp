using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PttApp.Domain.Entities;
using Xamarin.Forms;

namespace PttApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Login();
        }
        public async void Login()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://localhost:7244/api/Products");
            var login = JsonConvert.DeserializeObject<List<Product>>(response);
            if (response != null)
            {
                
            }
        }
    }
}
