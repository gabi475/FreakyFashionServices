using System;
using System.Collections.Generic;

namespace FreakyFashionServices.Catalog.Models
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AvailableStock { get; set; }
    }
}
