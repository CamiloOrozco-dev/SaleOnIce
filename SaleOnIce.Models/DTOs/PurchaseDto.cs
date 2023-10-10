namespace SaleOnIce.Models.DTOs
{
    public class PurchaseDto
    {
        public int Id { get; set; }

        public List<Product> Products { get; set; }

        public double Total { get; set; }

        public DateTime Date { get; set; }
    }
}