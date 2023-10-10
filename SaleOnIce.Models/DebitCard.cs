namespace SaleOnIce.Models
{
    public class DebitCard
    {
        public string CardHolderName { get; }
        public string CardNumber { get; }
        public DateTime ExpDate { get; }
        public string CVC { get; }
    }
}