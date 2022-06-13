using System.Collections.Generic;
using System.Linq;
using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;

namespace PttApp.Persistence.Managers { 
public class ProductManager: IProductManager
{
        private readonly RestServiceManager<List<Product>> _restServiceProductManager;
        public ProductManager()
        {
            _restServiceProductManager = new RestServiceManager<List<Product>>();
        }
    public List<Product> GetProducts()
    {
        return _restServiceProductManager.GetServiceResponse(ServiceUrlConst.Product);
    }

    public List<Product> GetProducts(ProductFilter productFilter)
    {
        var allProduct = _restServiceProductManager.GetServiceResponse(ServiceUrlConst.Product);

            if (productFilter.MainCategoryId.HasValue)
            allProduct = allProduct.Where(x => x.CategoryId == productFilter.MainCategoryId.Value).ToList();

        if (productFilter.SubCategoryId.HasValue)
            allProduct = allProduct.Where(x => x.SubCategoryId == productFilter.SubCategoryId.Value).ToList();

        if (productFilter.SubOfSubCategoryId.HasValue)
            allProduct = allProduct.Where(x => x.SubOfSubCategoryId == productFilter.SubOfSubCategoryId.Value).ToList();



        return allProduct;
    }

    public Product GetProductById(int productId)
    {
        var allProduct = _restServiceProductManager.GetServiceResponse(ServiceUrlConst.Product);
            var result = allProduct.FirstOrDefault(x => x.Id == productId);
        return result;
    }

}
}