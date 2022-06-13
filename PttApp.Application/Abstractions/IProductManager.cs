﻿using System.Collections.Generic;
using PttApp.Domain.Entities;

namespace PttApp.Application.Abstractions
{
    public interface IProductManager
    {
        List<Product> GetProducts();
        List<Product> GetProducts(ProductFilter productFilter);
        Product GetProductById(int productId);
    }
}