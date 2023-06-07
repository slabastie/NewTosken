using MongoDB.Bson;
using System;
using System.Runtime.Serialization;

namespace NewTosken.Models
{
    public class players
    {
        public ObjectId id { get; set; }

        public string name { get; set; }

        public Int32 db_magic { get; set; }

        public Int32 db_missile { get; set; }

        public Int32 db_melee { get; set; }

        public Int32 current_health { get; set; }

        public Int32 max_health { get; set; }

        public Int32 temp_health { get; set; }

    }
}
