using MongoDB.Bson;
using System;

namespace NewTosken.Models
{
    public class combat
    {
        public ObjectId Id { get; set; }
        public string name { get; set; }
        public Int32 initiative { get; set; }
        public Int32 activity { get; set; }       
        public Int32 haste_rounds { get; set; }
        public Int32 current_hp { get; set; }
        public Int32 stun_rounds { get; set;  }
        public Int32 mp_rounds { get; set; }
        public Int32 up_rounds { get; set; }
        public Int32 bleed_hp { get; set; }
        public Int32 bleed_rounds { get; set; }
        public String move_speed { get; set; }
        public Double speed_rate { get; set; }
        public Int32 speed_rounds { get; set; }
    }
}
