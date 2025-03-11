using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.Models
{
    internal class RoomTypes
    {
        public ObjectId Id { get; set; }
        public string RoomType { get; set;  }
    }
}
