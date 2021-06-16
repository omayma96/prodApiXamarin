using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace prdApi.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Price")]
        public string Price { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }
    }
}
