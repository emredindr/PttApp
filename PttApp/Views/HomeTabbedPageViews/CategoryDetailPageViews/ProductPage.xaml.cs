using System;
using System.Collections.Generic;
using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;
using PttApp.Persistence.Managers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp.Views.HomeTabbedPageViews.CategoryDetailPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        readonly MyBasketManager _myBasketManager;
        public ProductPage(ProductFilter productFilter)
        {
            InitializeComponent();
            var productManager = Startup.ServiceProvider.GetService<IProductManager>();
            _myBasketManager = new MyBasketManager();
            lblProductCategoryName.Text = productFilter.Title;
            var productsWithImage = productManager.GetProducts(productFilter);
            productFlowList.FlowItemsSource = productsWithImage;
        }

        private void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            ListView lstView = (ListView)sender;
            lstView.SelectedItem = null;
        }

        private async void OnClickedAddBasket(object sender, System.EventArgs e)
        {
            var product = ((Button)sender).BindingContext as Product;

            if (product != null)
            {
                int isInserted = _myBasketManager.Insert(new MyBasketItem
                {
                    MainCategoryId = product.CategoryId,
                    ProductCount = 1,
                    ProductPrice = product.Price,
                    ProductId = product.Id,
                    ProductTitle = product.Title,
                    SubCategoryId = product.SubCategoryId,
                    SubOfSubCategoryId = product.SubOfSubCategoryId
                });


                if (isInserted > 0)
                {
                    var action = await DisplayAlert("Tebrikler?", "Ürün başarıyla sepete eklenmiştir", "Sepete Git", "Alışverişe Devam Et");
                    if (action)
                    {
                        await Navigation.PushAsync(new MyBasketPage());
                    }
                }
                else
                {
                    await DisplayAlert("HATA", "Ekleme sırasında hata oluştu", "OK");
                }

            }
        }

        private void OnClickProductImage_Tapped(object sender, EventArgs e)
        {
            Image imageClicked = (Image)sender;
            var item = (TapGestureRecognizer)imageClicked.GestureRecognizers[0];
            var selectedProduct = (Product)item.CommandParameter;
            if (selectedProduct != null && selectedProduct.Id > 0)
            {
                //ProductDetailPage(selectedProduct) olarak düzenlenecek
                Page page = new ProductDetailPage(selectedProduct);
                Navigation.PushAsync(page);
            }
        }
    }
}





