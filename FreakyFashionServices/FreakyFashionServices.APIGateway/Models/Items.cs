using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FreakyFashionServices.APIGateway.Models
{
    public partial class Items
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("price")]
        public int Price { get; set; }
        [JsonPropertyName("availableStock")]
        public int AvailableStock { get; set; }
    }
}
