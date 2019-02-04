using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.ViewModel
{
    public class HotelRoomCreateViewModel
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public HotelRoom HotelRoom { get; set; }

        public HotelRoomCreateViewModel() { }

       public HotelRoomCreateViewModel(int hotelID, int roomId, string roomNumber, string rate)
        {
            HotelRoom hr = new HotelRoom();
            hr.HotelID = hotelID;
            hr.RoomID = roomId;
            hr.RoomNumber = roomNumber;
            hr.Rate = rate;

            HotelRoom = hr;
        }
    }
}
