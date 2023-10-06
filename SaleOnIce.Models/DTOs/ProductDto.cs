using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOnIce.Models.DTOs
{
    public class ProductDto
    {
        public int? Id { get; set; }
        public string NameProduct { get; set; }
        public string ImageProduct { get; set; }
        public string? Description { get; set; }
        public double? PreviousPrice { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
