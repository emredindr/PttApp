using System;
using System.Collections.Generic;
using System.Text;
using PttApp.Application.Abstractions;

namespace PttApp.Models
{
    public class Product
    {
        public List<Domain.Entities.Product>Products { get; set; }
        public Product(IProductManager productManager)
        {
            Products = productManager.GetProducts();
        }
    }
}
