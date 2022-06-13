using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;
using PttApp.Models;
using PttApp.Views.HomeTabbedPageViews.CategoryDetailPageViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp.Views.HomeTabbedPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
            var categoryManager = Startup.ServiceProvider.GetService<Category>();
            categoryListView.ItemsSource = categoryManager.MainCategories;
        }

        private void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            ListView lstView = (ListView)sender;
            lstView.SelectedItem = null;

            MainCategory selected = (MainCategory)e.SelectedItem;
            if (selected != null && selected.Id > 0)
            {
              //  Page Page = new SubCategoryPage(selected);
               Navigation.PushAsync(new SubCategoryPage(selected));
            }
        }
    }
}