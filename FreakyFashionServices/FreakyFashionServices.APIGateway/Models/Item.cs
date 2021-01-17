using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FreakyFashionServices.APIGateway.Models
{
    public class Item
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [JsonPropertyName("unitPrice")]
        public int UnitPrice { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
