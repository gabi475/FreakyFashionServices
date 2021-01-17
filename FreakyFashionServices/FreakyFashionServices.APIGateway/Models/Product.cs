using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace FreakyFashionServices.APIGateway.Models
{
    public class Product
    {
        [JsonPropertyName("articleNumber")]
        public string articleNumber { get; set; }
        [JsonPropertyName("price")]
        public int price { get; set; }
    }
}
