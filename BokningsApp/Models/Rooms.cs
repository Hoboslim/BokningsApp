using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.Models
{
    internal class Rooms
    {
        public ObjectId Id  { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public string RoomDescription { get; set; }
        public int Slots { get; set; }
        public List<ObjectId> Bookings { get; set; }

    }
}
