namespace SaleOnIce.Models
{
    public class ShoppingCart
    {
        public virtual IList<Product> Products { get; set; }
        public Purchase purchase { get; set; }
    }
}