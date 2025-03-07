using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.Models
{
    internal class Bookings
    {
        public ObjectId Id  { get; set; }
        public ObjectId UserId { get; set; }
        public ObjectId RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Endtime { get; set; }
        public List<ObjectId> Participants { get; set; }
    }
}
