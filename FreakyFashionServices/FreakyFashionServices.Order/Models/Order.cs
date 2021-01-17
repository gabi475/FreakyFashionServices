using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Models
{
    public class Order
    {
        [JsonPropertyName("customerIdentifier")]
        public string customerIdentifier { get; set; }
        [JsonPropertyName("firstName")]
        public string firstName { get; set; }
        [JsonPropertyName("lastName")]
        public string lastName { get; set; }
        [JsonPropertyName("basket")]
        public Basket basket { get; set; }
    }
}
