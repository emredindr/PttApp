using System;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp.Views.HomeTabbedPageViews.AccountDetailPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public string WebAPIKey = "AIzaSyArAkGi_opXahEVvwh11P9RjfLpXeSNAXU";
        public LoginPage()
        {
            InitializeComponent();
        }
        private void ForgetPasswordClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ForgetPasswordPage());
        }

        [Obsolete]
        private void RegisterButtonClicked(object sender,System.EventArgs e)
        {
            //Device.OpenUri(new Uri("market://details?id=com.udemy.android")); Google Play için Navigate eder
            Navigation.PushAsync(new RegisterPage());
        }
        
        private async void LoginButtonClicked(object sender,System.EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLoginEmail.Text, UserLoginPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                Preferences.Set("MyFirebaseLoginControl", true);
                Preferences.Set("MyFirebaseLoginedUserEmail", UserLoginEmail.Text);
                await Navigation.PushAsync(new MyAccountPage());
                
                // Application.Current.MainPage = new HomeTabbedPage();
               // var homeTabbedPage = new HomeTabbedPage();
                //Application.Current.MainPage = homeTabbedPage.Children[4];
                //Application.Current.MainPage = new HomeTabbedPage();
                // Application.Current.MainPage= new NavigationPage(new HomeTabbedPage()) { BarBackgroundColor = Color.White };
               

            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Hatalı  useremail yada password", "OK");
            }

        }
        



    }
}