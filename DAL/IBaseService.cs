using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace DAL
{
    public interface IBaseService<T>
    {
        Task Create(T instance);
        Task Save(T instance, string id);        
        Task<T> FindById(ObjectId id);
        Task<T> FindById(string id);        
        Task<IEnumerable<T>> Find(IMongoQuery spec);
        Task<IEnumerable<T>> Find(IMongoQuery spec, params string[] excludedFields);
        Task<IEnumerable<T>> Find(Func<T, bool> func);
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindAllActive();        
        Task<IEnumerable<T>> GetPaging(IMongoQuery spec, int idx, int pcount, out long total, SortByBuilder sortBy = null);
        Task<IEnumerable<T>> GetPaging(IMongoQuery spec, int idx, int pcount, out long total, params string[] excludedFields);        
        Task Remove(string id);
        Task LogicalRemove(string id);
        Task<IEnumerable<TMapReduceType>> MapReduce<TMapReduceType>(IMongoQuery spec, BsonJavaScript map, BsonJavaScript reduce, string outputCollectioName);
        Task<MapReduceResult> MapReduce(IMongoQuery spec, BsonJavaScript map, BsonJavaScript reduce);
    }
}