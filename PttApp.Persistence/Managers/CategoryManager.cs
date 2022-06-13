using System.Collections.Generic;
using System.Linq;
using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;

namespace PttApp.Persistence.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly RestServiceManager<List<MainCategory>> _restServiceMainCategoryManager;
        private readonly RestServiceManager<List<SubCategory>> _restServiceSubCategoryManager;
        private readonly RestServiceManager<List<SubOfSubCategory>> _restServiceSubOfSubCategoryManager;

        public CategoryManager()
        {
            _restServiceMainCategoryManager = new RestServiceManager<List<MainCategory>>();
            _restServiceSubCategoryManager = new RestServiceManager<List<SubCategory>>();
            _restServiceSubOfSubCategoryManager = new RestServiceManager<List<SubOfSubCategory>>();
        }
        public List<MainCategory> GetMainCategories()
        {
            return _restServiceMainCategoryManager.GetServiceResponse(ServiceUrlConst.MainCategory);
        }

        public List<SubCategory> GetSubCategories()
        {
            return _restServiceSubCategoryManager.GetServiceResponse(ServiceUrlConst.SubCategory);
        }

        public List<SubOfSubCategory> GetSubOfSubCategories()
        {
           
            return _restServiceSubOfSubCategoryManager.GetServiceResponse(ServiceUrlConst.SubOfSubCategory);
        }

        //Bunlar dışarda kullanılan base methodlar
        public List<SubCategory> GetSubCategories(MainCategory mainCategory)
        {
            var allSubCategories = _restServiceSubCategoryManager.GetServiceResponse(ServiceUrlConst.SubCategory);
            var result = allSubCategories.Where(x => x.CategoryId == mainCategory.Id).ToList();
            return result;
        }

        public List<SubOfSubCategory> GetSubOfSubCategories(SubCategory subCategory)
        {
            var allSubOfSubCategories = _restServiceSubOfSubCategoryManager.GetServiceResponse(ServiceUrlConst.SubOfSubCategory);
            var resultSub = allSubOfSubCategories.Where(x => x.SubCategoryId == subCategory.SubId && x.CategoryId == subCategory.CategoryId ).ToList();
            return resultSub;
        }

         

        public List<SubCategory> GetElektronicPopulerCategories()
        {
            var allSubCategories = _restServiceSubCategoryManager.GetServiceResponse(ServiceUrlConst.SubCategory);
            var result = allSubCategories.Where(x => x.IsPopularForElecktronic == true).ToList();
            return result;
        }

        public List<SubCategory> GetBabyPopulerCategories()
        {
            var allSubCategories = _restServiceSubCategoryManager.GetServiceResponse(ServiceUrlConst.SubCategory);
            var result = allSubCategories.Where(x => x.IsPopularForBaby == true).ToList();
            return result;
        }
    }
}