namespace PttApp.Domain.Entities
{
    public class ProductFilter
    {
        public int? MainCategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? SubOfSubCategoryId { get; set; }
        public string Title { get; set; }
    }
}