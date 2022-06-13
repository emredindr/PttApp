using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PttApp.Domain.Entities;

namespace PttApp.Application.Abstractions
{
    public interface ICategoryManager
    {
        List<MainCategory> GetMainCategories();
        List<SubCategory> GetSubCategories();
        List<SubOfSubCategory> GetSubOfSubCategories();
        List<SubCategory> GetSubCategories(MainCategory mainCategory);
        List<SubOfSubCategory> GetSubOfSubCategories(SubCategory subCategory);
        List<SubCategory> GetElektronicPopulerCategories();
        List<SubCategory> GetBabyPopulerCategories();

    }
}