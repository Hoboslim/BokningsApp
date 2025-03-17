using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.Models
{
    public class Bookings
    {
        public ObjectId Id  { get; set; }   
        public ObjectId UserId { get; set; }
        public string RoomName { get; set; }
        public string Email { get; set; }
        public ObjectId RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
       
    }
}
