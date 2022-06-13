using PttApp;
using PttApp.Application.Abstractions;
using PttApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp3.Views.HomeTabbedPageViews.HomeDetailPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchScreenPage : ContentPage
    {
        public SearchScreenPage()
        {
            InitializeComponent();
            var productManager = Startup.ServiceProvider.GetService<Product>();
            lstView.BindingContext = productManager.Products;
        }        

        private void OnTextChanged(object sender,TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length>3)
            {
                DisplayAlert("Tebrikler","Oldu","Ok","No");
            }

        }
        private void OnSelected(object sender,SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            ListView lstView = (ListView)sender;
            lstView.SelectedItem = null;
        }
    }
}