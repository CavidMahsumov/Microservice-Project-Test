using AccountService.API.Entities;
using MongoDB.Driver;

namespace AccountService.API.Repositories
{
    public class PlayerRepository
    {
        private readonly IMongoCollection<Player> _playerCollection;
        public PlayerRepository()
        {
            //if db exist connect that db but db not exist create new db
            var client=new MongoClient("mongodb://localhost:27017");
            var database= client.GetDatabase("AccountStructureDb");//create or connect db 

            _playerCollection=database.GetCollection<Player>("players");
           
        }

        public async Task<Player>Create(Player player)
        {
            await _playerCollection.InsertOneAsync(player);
            return player;
        }
    }
}
