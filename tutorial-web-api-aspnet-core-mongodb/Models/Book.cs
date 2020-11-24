using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BooksApi.Models
{
    public class Book : Entity
    {
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public Entity Author { get; set; }
    }
}


