using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.Data
{
    class DB
    {
        private static MongoClient GetClient()
        {
            const string connectionUri = "mongodb+srv://teddyblomgren:Teddy1Plugg1@cluster0.0wmw6.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            return client;
        }
    }
}
