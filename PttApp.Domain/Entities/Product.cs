using PttApp.Domain.Entities.Common;
using Xamarin.Forms;

namespace PttApp.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int SubOfSubCategoryId { get; set; }
        public string ProductIconSource { get; set; }

        public string Title { get; set; }
        public float Price { get; set; }
        public string PriceWithTL => (Price.ToString() + ".00 TL");
    }
}