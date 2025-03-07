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
            const string connectionUri = "mongodb+srv://Noel:Noel123@cluster0.0wmw6.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            return client;
        }

        public static IMongoCollection<Models.User> GetUserCollection()
        {
            var client = GetClient();
            var database = client.GetDatabase("BokningsApp");
            var collection = database.GetCollection<Models.User>("Users");
            return collection;
        }

        public static IMongoCollection<Models.Rooms> GetRoomCollection()
        {
            var client = GetClient();
            var database = client.GetDatabase("BokningsApp");
            var collection = database.GetCollection<Models.Rooms>("Rooms");
            return collection;
        }

        public static IMongoCollection<Models.Bookings> GetBookingCollection()
        {
            var client = GetClient();
            var database = client.GetDatabase("BokningsApp");
            var collection = database.GetCollection<Models.Bookings>("Bookings");
            return collection;
        }




    }
}
