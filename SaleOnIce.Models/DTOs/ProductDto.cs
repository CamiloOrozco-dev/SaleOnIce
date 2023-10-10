namespace SaleOnIce.Models.DTOs
{
    public class ProductDto
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string ImageProduct { get; set; }
        public string? Description { get; set; }
        public double? PreviousPrice { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CountProduct { get; set; }
        public bool StatusStock { get; set; }
    }
}