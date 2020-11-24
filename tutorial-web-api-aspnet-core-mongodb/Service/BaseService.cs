using BooksApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Service
{
    public abstract class BaseService<T> 
    {
        protected IMongoCollection<T> _items;
        public BaseService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            
            _items = database.GetCollection<T>(nameof(T));
        }

        public List<T> Get() =>
            _items.AsQueryable().ToList();

        public T Create(T newElement)
        {
            _items.InsertOne(newElement);
            return newElement;
        }
    }
}



