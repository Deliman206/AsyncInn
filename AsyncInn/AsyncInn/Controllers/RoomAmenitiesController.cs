using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Controllers
{
    public class RoomAmenitiesController : Controller
    {
        private readonly IAmenitiesManager _am;
        private readonly IRoomManeger _rooms;

        private AsyncInnDbContext _context { get; }

        public RoomAmenitiesController(IAmenitiesManager contextAmen, IRoomManeger contextRoom, AsyncInnDbContext context)
        {
            _am = contextAmen;
            _rooms = contextRoom;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<RoomAmenities> listRA = _context.ROOMAMENITIES.ToList();
            foreach(RoomAmenities ra in listRA)
            {
                Amenities a = await _am.GetAmenities(ra.AmenitiesID);
                Room r = await _rooms.GetRoom(ra.RoomID);
                ra.Amenities = a;
                ra.Room = r;
            }
            return View(listRA);
        }
        public IActionResult Create()
        {
            ViewData["Amentities"] = new SelectList(_context.AMENITIES, "ID", "Name");
            ViewData["Rooms"] = new SelectList(_context.ROOM, "ID", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("RoomID, AmenitiesID")] RoomAmenities ra)
        {
            if (ModelState.IsValid)
            {
                _context.ROOMAMENITIES.Add(ra);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int amenities, int room)
        {
            var ra = await _context.ROOMAMENITIES.Where(h => h.AmenitiesID == amenities && h.RoomID == room).FirstOrDefaultAsync();
            if (ra == null)
                return NotFound();
            ViewData["Amenities"] = new SelectList(_context.AMENITIES, "ID", "Name");
            ViewData["Rooms"] = new SelectList(_context.ROOM, "ID", "Name");
            return View(ra);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("RoomID, AmenitiesID")] RoomAmenities ra)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.ROOMAMENITIES.Update(ra);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    _context.ROOMAMENITIES.Add(ra);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int amenities, int room)
        {
            if (ModelState.IsValid)
            {
                var ra = await _context.ROOMAMENITIES.Where(h => h.AmenitiesID == amenities && h.RoomID == room).FirstOrDefaultAsync();
                if (ra == null)
                    return NotFound();

                _context.ROOMAMENITIES.Remove(ra);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}