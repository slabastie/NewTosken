using MongoDB.Bson;
using System;
using System.Runtime.Serialization;

namespace NewTosken.Models
{
    public class fate
    {
        public ObjectId id;

        public String name;

        public Int32 fate_change;

        public String change_reason;

        public Int32 current_fate;
    }
}
