namespace SaleOnIce.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public List<Product> Products { get; set; }

        public double Total { get; set; }

        public DateTime Date { get; set; }
    }
}