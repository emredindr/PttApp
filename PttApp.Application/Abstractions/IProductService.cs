using System;
using System.Collections.Generic;
using System.Text;
using PttApp.Domain.Entities;

namespace PttApp.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetAllProduct();
    }
}
