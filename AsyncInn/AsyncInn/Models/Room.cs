using System.Collections.Generic;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }

        ICollection<HotelRoom> HotelRoom { get; set; }
        ICollection<Hotel> Hotel { get; set; }
    }

    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom,
    }
}