using System;
using System.Windows.Input;
using Firebase.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp.Views.HomeTabbedPageViews.AccountDetailPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        [Obsolete]
        public ICommand TapCommand => new Command<string>(OpenBrowser);
        public string WebAPIKey = "AIzaSyArAkGi_opXahEVvwh11P9RjfLpXeSNAXU";
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        [Obsolete]
        void OpenBrowser(string url)
        {
            Device.OpenUri(new Uri(url));
        }
        private void OnColorsRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        private async void RegisterSignUpClicked(object sender, System.EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Alert", "Başarılı Bir Şekilde Üye Olundu", "Ok");
                //Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync()

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Hata Lütfen Yeniden Deneyiniz", "OK");
                
            }

        }
    }
}