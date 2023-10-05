namespace SaleOnIce.Models
{
    public class Purchase
    {
  
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Purchase()
        {
            Date = DateTime.Now;
        }
    }
}