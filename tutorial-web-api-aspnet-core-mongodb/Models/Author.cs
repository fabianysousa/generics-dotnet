using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace BooksApi.Models
{
    public class Author : Entity
    {
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string AuthorName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}


