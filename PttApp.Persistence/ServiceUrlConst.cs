using System;
using System.Collections.Generic;
using System.Text;

namespace PttApp.Persistence
{
    public static class ServiceUrlConst
    {
        
        //Category
        public static string MainCategory = "http://192.168.43.183:84/api/Category/GetAllMainCategories";
        public static string SubCategory = "http://192.168.43.183:84/api/Category/GetAllSubCategories";
        public static string SubOfSubCategory = "http://192.168.43.183:84/api/Category/GetAllSubOfSubCategories";


        //Basket
        
        public static string GetAllBasketItem = "http://192.168.43.183:84/api/MyBasket/GetAllBasketItem";
        public static string AddMyBasket = "http://192.168.43.183:84/api/MyBasket/AddBasketItem";
        public static string DeleteItem = "http://192.168.43.183:84/api/MyBasket/DeleteItem";
        public static string DeleteAll = "http://192.168.43.183:84/api/MyBasket/DeleteAll";

        //Product
        public static string Product = "http://192.168.43.183:84/api/Product/GetAllProduct";

        //Home
        public static string Banner = "http://192.168.43.183:84/api/Home/Banner";

        //Account
        public static string AccountPageItem = "http://192.168.43.183:84/api/Account/GetAllItems";
        public static string AccountPageItemLogined = "http://192.168.43.183:84/api/Account/GetAllItemsLogined";

    }
}
