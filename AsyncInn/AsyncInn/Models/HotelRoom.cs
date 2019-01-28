using System.Collections.Generic;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        public decimal RoomNumber { get; set; }
        public int RoomID { get; set; }
        public decimal Rate { get; set; }
        public byte PetFriendly { get; set; }

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}