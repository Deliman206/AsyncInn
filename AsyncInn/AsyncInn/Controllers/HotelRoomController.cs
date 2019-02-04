using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.ViewModel;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Controllers
{
    public class HotelRoomController : Controller
    {
        private readonly IHotelManeger _hotels;
        private readonly IRoomManeger _rooms;

        private AsyncInnDbContext _context { get; set; }


        public HotelRoomController(IHotelManeger contextHotel, IRoomManeger contextRoom, AsyncInnDbContext context)
        {
            _hotels = contextHotel;
            _rooms = contextRoom;
            _context = context;
        }
        public IActionResult Index()
        {
            List<HotelRoom> listHotelRoom = _context.HOTELROOM.ToList();
            return View(listHotelRoom);
        }
        public IActionResult Create()
        {
            List<Hotel> listHotel = _context.HOTEL.ToList();
            List<Room> listRoom = _context.ROOM.ToList();
            HotelRoomCreateViewModel vm = new HotelRoomCreateViewModel();
            vm.Hotels = listHotel;
            vm.Rooms = listRoom;

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("HotelID, RoomID, RoomNumber, Rate")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                HotelRoom hr = hotelRoom as HotelRoom;
                Hotel hotel = await _hotels.GetHotel(hr.HotelID);
                Room room = await _rooms.GetRoom(hr.RoomID);

                hr.Hotel = hotel;
                hr.Room = room;

                hotel.HotelRoom.Add(hr);
                _context.HOTELROOM.Add(hr);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hr = _context.HOTELROOM.FirstOrDefault(h => h.ID == id);
            if (hr == null)
                return NotFound();
            return View(hr);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("HotelID, RoomID, RoomNumber, Rate, PetFriendly")] HotelRoom hr)
        {
            if (ModelState.IsValid)
            {
                _context.HOTELROOM.Update(hr);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                HotelRoom hr = _context.HOTELROOM.FirstOrDefault(h => h.ID == id);
                Hotel hotel = await _hotels.GetHotel(hr.HotelID);

                hotel.HotelRoom.Remove(hr);
                _context.HOTELROOM.Remove(hr);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }

    
}