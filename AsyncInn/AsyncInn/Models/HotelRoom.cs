using System.Collections.Generic;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string Rate { get; set; }

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}