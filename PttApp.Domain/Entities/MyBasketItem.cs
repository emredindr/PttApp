using SQLite;

namespace PttApp.Domain.Entities
{
    public class MyBasketItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int MainCategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int SubOfSubCategoryId { get; set; }
        public int ProductCount { get; set; }
        public float ProductPrice { get; set; }
    }
}