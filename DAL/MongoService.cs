using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Entities;

namespace DAL
{
    public class MongoService<T> : BaseMongoService<T>
    {        
    }

    public class UsersMongoService : BaseMongoService<User>
    {
        public UsersMongoService()
        {
            CreateIndexes().Wait();

        }

        public async Task CreateIndexes()
        {
            var keys = Builders<User>.IndexKeys.Ascending("UserData").Ascending("UserName");
            await Collection.Indexes.CreateOneAsync(keys);
        }

        public IMongoCollection<User> getCollection()
        {
            return Collection;
        }
    }
}
    