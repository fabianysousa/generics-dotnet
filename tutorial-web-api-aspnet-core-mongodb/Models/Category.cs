using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BooksApi.Models
{
    public class Category : Entity
    {
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string CategoryName { get; set; }
    }

}


