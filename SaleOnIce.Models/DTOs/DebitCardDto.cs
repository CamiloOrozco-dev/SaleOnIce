namespace SaleOnIce.Models.DTOs
{
    public class DebitCardDto

    {
        public string CardHolderName { get; }
        public string CardNumber { get; }
        public DateTime ExpDate { get; }
        public string CVC { get; }
    }
}