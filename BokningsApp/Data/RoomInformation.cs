
using BokningsApp.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.Data
{
    public class RoomInformation
    {
        //hämtar rum från rumtyper från MongoDB
        public List<Models.Rooms> GetRoomsByType(string roomType)
        {
            var collection = DB.GetRoomCollection();
            var filter = Builders<Models.Rooms>.Filter.Eq(r => r.RoomType, roomType);
            var rooms = collection.Find(filter).ToList();
            return rooms;
        }

        //Hämtar alla rumtyper från MongoDB
        public List<Models.RoomTypes> GetAllRoomTypes()
        {
            var collection = DB.GetRoomTypesCollection();
            var roomTypes = collection.Find(_ => true).ToList();
            return roomTypes;
        }


        //hämtar rum detajer från mongoDB
        public Models.Rooms GetRoomByName(string roomName)
        {
            var collection = DB.GetRoomCollection();
            var filter = Builders<Models.Rooms>.Filter.Eq(r => r.RoomName, roomName);
            var room = collection.Find(filter).FirstOrDefault();
            return room;
        }
    }
}
