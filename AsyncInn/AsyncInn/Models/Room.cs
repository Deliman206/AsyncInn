using System.Collections.Generic;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }

    }

    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom,
    }
}