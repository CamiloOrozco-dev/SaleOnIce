using SaleOnIce.Models.ViewModels;

namespace SaleOnIce.Models
{
    public class User
    {
       
        public int Id { get; set; }

        public string Name { get; set; }
        public byte Image { get; set; }

        public List<Product> productsUser { get; set; }

        public DebitCardView? debitCard { get; set; }
    }
}