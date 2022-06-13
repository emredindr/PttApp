using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PttApp.Domain.Entities.Common;

namespace PttApp.Domain.Entities
{
    public class SubOfSubCategory : BaseEntity
    {
        public int SubOfSubId { get; set; } 
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string Title { get; set; }
    }
}