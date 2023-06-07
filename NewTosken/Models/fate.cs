using MongoDB.Bson;
using System;
using System.Runtime.Serialization;

namespace NewTosken.Models
{
    public class fate
    {
        public ObjectId id { get; set; }

        public String name { get; set; }

        public Int32 fate_change { get; set; }

        public String change_reason { get; set; }

        public Int32 current_fate { get; set; }
  
        public DateTime date_time { get; set; }

    }
}
