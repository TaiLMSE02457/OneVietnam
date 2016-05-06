using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Properties;
using MongoDB.Driver;

namespace DAL
{
    public class OneVietnamContext
    {
        private IMongoClient client;
        private IMongoDatabase database;

        public OneVietnamContext()
        {
            client = new MongoClient(Settings.Default.OneVietnamConnectionString);
            database = client.GetDatabase(Settings.Default.OneVietnamDatabaseName);
        }

        public OneVietnamContext(string connectionString, string databaseName)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public OneVietnamContext(string connectionString)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase(Settings.Default.OneVietnamDatabaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return database;
        }
    }
}
