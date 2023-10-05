using SaleOnIce.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOnIce.Models
{
    public class DebitCardView 
    {
        public string CardHolderName { get; }
        public string CardNumber { get; }
        public DateTime ExpDate { get; }
        public string CVC { get; }
    }
}
