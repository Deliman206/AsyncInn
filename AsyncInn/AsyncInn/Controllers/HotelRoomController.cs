using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.ViewModel;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Controllers
{
    public class HotelRoomController : Controller
    {
        private readonly IHotelManeger _hotels;
        private readonly IRoomManeger _rooms;

        private AsyncInnDbContext _context { get;}


        public HotelRoomController(IHotelManeger contextHotel, IRoomManeger contextRoom, AsyncInnDbContext context)
        {
            _hotels = contextHotel;
            _rooms = contextRoom;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            List<HotelRoom> listHotelRoom = _context.HOTELROOM.ToList();
            foreach (HotelRoom hr in listHotelRoom)
            {
                Hotel hotel = await _context.HOTEL.FindAsync(hr.HotelID);
                Room room = await _context.ROOM.FindAsync(hr.RoomID);
                hr.Hotel = hotel;
                hr.Room = room;
            }
            return View(listHotelRoom);

        }
        public IActionResult Create()
        {
            ViewData["Hotels"] = new SelectList(_context.HOTEL, "ID", "Name");
            ViewData["Rooms"] = new SelectList(_context.ROOM, "ID", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("HotelID, RoomID, RoomNumber, Rate")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.HOTELROOM.Add(hotelRoom);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int hotel, int room)
        {
            var hr = await _context.HOTELROOM.Where(h => h.HotelID == hotel && h.RoomID == room).FirstOrDefaultAsync();
            if (hr == null)
                return NotFound();
            ViewData["Hotels"] = new SelectList(_context.HOTEL, "ID", "Name");
            ViewData["Rooms"] = new SelectList(_context.ROOM, "ID", "Name");
            return View(hr);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("HotelID, RoomID, RoomNumber, Rate, PetFriendly")] HotelRoom hr)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.HOTELROOM.Update(hr);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    _context.HOTELROOM.Add(hr);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int hotel, int room)
        {
            if (ModelState.IsValid)
            {
                var hr = await _context.HOTELROOM.Where(h => h.HotelID == hotel && h.RoomID == room).FirstOrDefaultAsync();
                if (hr == null)
                    return NotFound();

                _context.HOTELROOM.Remove(hr);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }

    
}