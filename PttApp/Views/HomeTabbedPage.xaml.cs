using PttApp.Application.Abstractions;
using PttApp.Views.HomeTabbedPageViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage()
        {
            InitializeComponent();
            Children.Add(new HomePage());
            Children.Add(new CategoryPage());
            Children.Add(new MyBasketPage());
            Children.Add(new MyAccountPage());
        }
    }
}