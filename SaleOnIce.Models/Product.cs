﻿namespace SaleOnIce.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string? Description { get; set; }

        public double? PreviousPrice { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public bool InStock { get; set; }
    }
}