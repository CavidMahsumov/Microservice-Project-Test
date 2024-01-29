using InventoryService.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Data.Repositories
{
    public class ItemRepository
    {
        private readonly IMongoCollection<Item> _itemCollection;
        public ItemRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database=client.GetDatabase("InventoryDb");
            _itemCollection = database.GetCollection<Item>("items");
        }

        public async Task<List<Item>?> GetAll()
        {
            var filter = Builders<Item>.Filter.Empty;
            var result = await _itemCollection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<Item?> GetById(string id)
        {
            var filter = Builders<Item>.Filter.Eq(p => p.Id, id);
            var result = await _itemCollection.Find(filter).FirstOrDefaultAsync();
            return result;
        }
        public async Task<Item>Create(Item item)
        {
           await _itemCollection.InsertOneAsync(item);
             return item;    
        }
        public async Task Remove(string id)
        {
            var filter = Builders<Item>.Filter.Eq(p => p.Id, id);

            await _itemCollection.DeleteOneAsync(filter);
        }
        public async Task Update(Item updatedItem)
        {
            var filter = Builders<Item>.Filter.Eq(p => p.Id, updatedItem.Id);

            await _itemCollection.FindOneAndReplaceAsync(filter, updatedItem);
        }
    }
}
