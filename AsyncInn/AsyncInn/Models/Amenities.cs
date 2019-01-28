using System.Collections.Generic;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}