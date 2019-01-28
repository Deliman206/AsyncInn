using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; } = "Async Inn";
        public int Phone { get; set; }
        
        public ICollection<HotelRoom> HotelRoom { get; set; }

    }

}
