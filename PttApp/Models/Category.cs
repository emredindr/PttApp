using System;
using System.Collections.Generic;
using System.Text;
using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;

namespace PttApp.Models
{
    public class Category
    {
        public List<MainCategory> MainCategories { get; set; }
        public List<SubCategory> BabyPopulerCategories { get; set; }
        public List<SubCategory> ElektronicPopulerCategories { get; set; }
        public Category(ICategoryManager categoryManager)
        {
            MainCategories = categoryManager.GetMainCategories();
            ElektronicPopulerCategories = categoryManager.GetElektronicPopulerCategories();
            BabyPopulerCategories = categoryManager.GetBabyPopulerCategories();
        }
    }
}
