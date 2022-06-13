using System;
using System.Linq;
using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;
using PttApp.Models;
using PttApp.Persistence.Managers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp.Views.HomeTabbedPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBasketPage : ContentPage
    {
        readonly  MyBasketManager _myBasketManager;
        public MyBasketPage()
        {

            InitializeComponent();
            _myBasketManager = new MyBasketManager();
            var allProductCount = _myBasketManager.GetAllCount();



            AllProductCount.Text = "(" + allProductCount.ToString() + ")";
            if (allProductCount > 0 && allProductCount != 0)
            {
                myBasketListView.IsVisible = true;
                AllProductCount.IsVisible = true;
                Ozet.IsVisible = true;
                titleCount.IsVisible = true;
                Yok.IsVisible = false;
                Yok.Text = "";

                btnClearAll.IsVisible = true;
            }
            else
            {
                myBasketListView.IsVisible = false;
                Ozet.IsVisible = false;
                titleCount.IsVisible = false;
                Yok.IsVisible = true;
                AllProductCount.IsVisible = false;
                btnClearAll.IsVisible = false;
                Yok.Text = "Sepetinizde Hiç Ürün Bulunmamaktadır!";


            }

            var myBasketProductList = _myBasketManager.GetAll().ToList();
            myBasketListView.BindingContext = myBasketProductList;
            var total = myBasketProductList.Sum(x => x.ProductPrice);
            totalPrice.Text = total.ToString() + ".00 TL";
            subTotalPrice.Text = total.ToString() + ".00 TL";
            totalProduct.Text = allProductCount.ToString();
        }
        private async void OnClickLabelForDeleteProduct_Tapped(object sender, EventArgs e)
        {

            Label labelClicked = (Label)sender;
            var item = (TapGestureRecognizer)labelClicked.GestureRecognizers[0];
            var selectItem = (MyBasketItem)item.CommandParameter;

            if (selectItem != null && selectItem.Id > 0)
            {
                bool isOk = await DisplayAlert("UYARI", selectItem.ProductTitle + " silinecek", "Ürünü Sepetten Kaldır", "Vazgeç");
                if (isOk)
                {
                    bool isdeleted = _myBasketManager.Delete(selectItem.Id);
                    if (isdeleted)
                    {
                        await DisplayAlert("başarılı", "silindi", "ok");
                        RefreshData();
                    }
                    else
                    {
                        await DisplayAlert("başarısız", "silinemedi", "ok");
                    }
                }
            }
            RefreshData();
        }


        public void RefreshData()
        {
            var allProductCount = _myBasketManager.GetAllCount();
            if (allProductCount > 0 && allProductCount != 0)
            {
                myBasketListView.IsVisible = true;
                Ozet.IsVisible = true;
                titleCount.IsVisible = true;
                Yok.IsVisible = false;
                AllProductCount.IsVisible = true;
                btnClearAll.IsVisible = true;
                Yok.Text = "";


            }
            else
            {
                myBasketListView.IsVisible = false;
                Ozet.IsVisible = false;
                titleCount.IsVisible = false;
                Yok.IsVisible = true;
                Yok.Text = "Sepetinizde Hiç Ürün Bulunmamaktadır!";

                AllProductCount.IsVisible = false;
                btnClearAll.IsVisible = false;


            }
            myBasketListView.BindingContext = _myBasketManager.GetAll().ToList();
            AllProductCount.Text = allProductCount.ToString();
        }



        private async void AllMyProductClear(object sender, EventArgs e)
        {
            //var allBasketItem = _myBasketManager.GetAll().ToList();
            //foreach (var item in allBasketItem)
            //{
                _myBasketManager.DeleteAll();
            //}
            Yok.Text = "Sepetinizde Hiç Ürün Bulunmamaktadır!";
            await DisplayAlert("BAŞARILI", "Bütün Ürünlerin Silindi", "OK");

            RefreshData();
        }
    }
}