using AccountService.Data.Entities;
using MongoDB.Driver;

namespace AccountService.Data.Repositories
{
    public class PlayerRepository
    {
        private readonly IMongoCollection<Player> _playerCollection;
        public PlayerRepository()
        {
            //if db exist connect that db but db not exist create new db
            var client=new MongoClient("mongodb://localhost:27017");
            var database= client.GetDatabase("AccountStructureDb");//create or coannect db 

            _playerCollection=database.GetCollection<Player>("players");
           
        }

        public async Task<Player>Create(Player player)
        {
            await _playerCollection.InsertOneAsync(player);
            return player;
        }


        

        public async Task<List<Player>?> GetAll()
        {
            var filter = Builders<Player>.Filter.Empty;
            var result= await _playerCollection.Find(filter).ToListAsync();
            return result;
            //await _playerCollection.Find(x => true).ToListAsync();- solution two
        }

        public async Task<Player?> GetById(string id)
        {
           var filter= Builders<Player>.Filter.Eq(p=>p.Id,id);
           var result = await _playerCollection.Find(filter).FirstOrDefaultAsync();
           return result ;
        }

        public async Task Update(Player UpdatedPlayer)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, UpdatedPlayer.Id);
            //var updated = Builders<Player>.Update.Set(x => x.FirstName, UpdatedPlayer.FirstName);
            //_playerCollection.UpdateOne(filter,updated) - solution two ;

            await _playerCollection.FindOneAndReplaceAsync(filter, UpdatedPlayer);
        }

        public async Task Remove(string id)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);

            await _playerCollection.DeleteOneAsync(filter);
        }
    }
}
