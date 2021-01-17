using System;
using System.Collections.Generic;
using System.Linq;

namespace FreakyFashionServices.ProductPrice.Models
{
    public class Product
    {
        public Product(string articleNumber, int price)
        {
            this.articleNumber = articleNumber;
            this.price = price;
        }

        public string articleNumber { get; set; }
        public int price { get; set; }
    }
}
