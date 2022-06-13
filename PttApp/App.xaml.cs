using System.IO;
using PttApp.Persistence.Managers;
using PttApp.Views;
using PttApp.Views.HomeTabbedPageViews;
using Xamarin.Forms;

namespace PttApp
{
    public partial class App : IApplicationController
    {
        public static string DbName { get; set; } = "PttDatabase.db3";
        public App()
        {
            InitializeComponent();

            Startup.Init();
            MainPage = new NavigationPage(new HomeTabbedPage()) { BarBackgroundColor = Color.White };

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}