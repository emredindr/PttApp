using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;
using PttApp.Persistence.Managers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp.Views.HomeTabbedPageViews.CategoryDetailPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        readonly MyBasketManager _sQLiteMyBasketManager;
        public Product ProductItem { get; set; }

        public ProductDetailPage(Product _product)
        {
            InitializeComponent();
            _sQLiteMyBasketManager = new MyBasketManager();
            ProductItem = _product;
            BindingContext = _product;


        }
        private async void buyNow(object sender, System.EventArgs e)
        {
            var product = ((Button)sender).BindingContext as Product;

            if (product != null)
            {
                int isInserted = _sQLiteMyBasketManager.Insert(new MyBasketItem
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
                    await Navigation.PushAsync(new MyBasketPage());
                }
            }
        }

        private async void addToBasket(object sender, System.EventArgs e)
        {
            var product = ((Button)sender).BindingContext as Product;

            if (product != null)
            {
                int isInserted = _sQLiteMyBasketManager.Insert(new MyBasketItem
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
    }
}