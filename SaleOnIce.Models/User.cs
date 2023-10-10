namespace SaleOnIce.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DebitCard? debitCard { get; set; } = null;
    }
}