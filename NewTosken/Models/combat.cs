using MongoDB.Bson;
using System;

namespace NewTosken.Models
{
    public class combat
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public Int32 initiative { get; set; }
        public Int32 activity { get; set; }
        
        public Int32 haste_rounds { get; set; }
        public Int32 current_hp { get; set; }
        public Int32 stun_rounds { get; set;  }



    }
}
