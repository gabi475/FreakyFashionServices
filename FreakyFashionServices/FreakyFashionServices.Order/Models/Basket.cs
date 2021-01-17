using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FreakyFashionServices.Order.Models
{
    public class Basket
    {
        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }
}
