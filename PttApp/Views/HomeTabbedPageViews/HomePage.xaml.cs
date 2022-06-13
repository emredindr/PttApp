using System;
using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;
using PttApp.Models;
using PttApp.Views.HomeTabbedPageViews.CategoryDetailPageViews;
using PttApp3.Views.HomeTabbedPageViews.HomeDetailPageViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp.Views.HomeTabbedPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            var homeManager = Startup.ServiceProvider.GetService<Home>();
            var categoryManager = Startup.ServiceProvider.GetService<Category>();
            cvBanners.ItemsSource = homeManager.Banners;

            collectionViewListHorizontal.ItemsSource = categoryManager.MainCategories;
            BindableLayout.SetItemsSource(stacklayoutElektronikler, categoryManager.ElektronicPopulerCategories);
            BindableLayout.SetItemsSource(stacklayoutBebekler, categoryManager.BabyPopulerCategories);

        }
        private void SearchbarFocussed(object sender, FocusEventArgs e)
        {
            Navigation.PushAsync(new SearchScreenPage());
        }
        private void OnClickImageForMainIcon_Tapped(object sender, EventArgs e)
        {
            Image imageClicked = (Image)sender;
            var item = (TapGestureRecognizer)imageClicked.GestureRecognizers[0];
            var selectImageMainIcon = (MainCategory)item.CommandParameter;
            if (selectImageMainIcon != null && selectImageMainIcon.Id > 0)
            {
                Page page = new SubCategoryPage(selectImageMainIcon);
                Navigation.PushAsync(page);
            }

        }
        private void OnClickImageForPopuler_Tapped(object sender, EventArgs e)
        {
            Image imageClicked = (Image)sender;
            var item = (TapGestureRecognizer)imageClicked.GestureRecognizers[0];

            // var selectElektronicPopular = item.CommandParameter as SubCategory;
            var selectElektronicPopular = (SubCategory)item.CommandParameter;

            if (selectElektronicPopular != null && selectElektronicPopular.Id > 0)
            {
                Page page = new SubOfSubCategoryPage(selectElektronicPopular);
                Navigation.PushAsync(page);
            }
        }

        protected override async void OnAppearing()
        {

        }
    }
}
