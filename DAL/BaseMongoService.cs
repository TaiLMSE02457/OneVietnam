using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DAL
{
    public abstract class BaseMongoService<T> : IBaseService<T>
    {
        protected string ConnectionName => typeof (T).Name;
        protected readonly IMongoDatabase MongoDatabase = null;
        private IMongoCollection<T> _collection;

        protected internal IMongoCollection<T> Collection
        {
            get { return _collection ?? MongoDatabase.GetCollection<T>(ConnectionName); }
            set {_collection = value; }
        }

        protected BaseMongoService()
        {
            MongoDatabase = DbConfig.GetMongoConnection().GetDatabase();
        }       
        public async Task Create(T instance)
        {
            try
            {
                await Collection.InsertOneAsync(instance);
            }
            catch (MongoConnectionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw  new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<T>> Find(Func<T, bool> func)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(IMongoQuery spec)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(IMongoQuery spec, params string[] excludedFields)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            try
            {
                var filter = new BsonDocument();
                List<T> list = new List<T>();
                var cursor = await Collection.FindAsync(filter);
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    list.AddRange(batch);
                }
                return list;
            }
            catch (MongoConnectionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> FindByFilter(FilterDefinition<T> filter)
        {
            return await Collection.Find(filter).ToListAsync();
        }
        public async Task<IEnumerable<T>> FindAllActive()
        {
            try
            {
                var builder = Builders<T>.Filter;                
                var filter = builder.Eq("DeletedFlag", false);
                return await Collection.Find(filter).ToListAsync();
            }
            catch (MongoConnectionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<T> FindById(string id)
        {
            try
            {
                return await FindById(new ObjectId(id));                
            }
            catch (MongoConnectionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        public async Task<T> FindActiveById(string id)
        {
            try
            {
                var builder = Builders<T>.Filter;
                var filter = builder.Eq("_id", new ObjectId(id)) & builder.Eq("DeletedFlag", false);
                return await Collection.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoConnectionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<T> FindById(ObjectId id)
        {
            try
            {                
                var filter = Builders<T>.Filter.Eq("_id", id);
                return await Collection.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoConnectionException ex)
            {
                throw  new Exception(ex.Message);
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<T>> GetPaging(IMongoQuery spec, int idx, int pcount, out long total, params string[] excludedFields)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetPaging(IMongoQuery spec, int idx, int pcount, out long total, SortByBuilder sortBy = null)
        {
            throw new NotImplementedException();
        }        
        public Task<MapReduceResult> MapReduce(IMongoQuery spec, BsonJavaScript map, BsonJavaScript reduce)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TMapReduceType>> MapReduce<TMapReduceType>(IMongoQuery spec, BsonJavaScript map, BsonJavaScript reduce, string outputCollectioName)
        {
            throw new NotImplementedException();
        }

        public async Task Remove( string id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                await Collection.DeleteOneAsync(filter);
            }
            catch(MongoConnectionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public async Task LogicalRemove(string id)
        {            
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                var update = Builders<T>.Update.Set("DeletedFlag", true);
                await Collection.UpdateOneAsync(filter, update);
            }
            catch (MongoConnectionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }                
        public async Task Save(T instance, string id)
        {            
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));                
                await Collection.ReplaceOneAsync(filter, instance);
            }
            catch (MongoConnectionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw  new Exception(ex.Message);
            }
        }
    }
}
