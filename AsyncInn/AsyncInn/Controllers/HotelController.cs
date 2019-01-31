using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsyncInn.Models;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelManeger _contextInterface;
        private AsyncInnDbContext _contextDB { get; set; }


        public HotelController(IHotelManeger context, AsyncInnDbContext contextDB)
        {
            _contextInterface = context;
            _contextDB = contextDB;
        }
        
        public IActionResult Index()
        {
           List<Hotel> list = _contextDB.HOTEL.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var hotels = from h in _contextDB.HOTEL
                         select h;

            if (!String.IsNullOrEmpty(searchString))
            {
                 hotels = hotels.Where(s => s.Name.Contains(searchString));
            }

            return View(await hotels.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, City, Phone")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _contextInterface.CreateHotel(hotel);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await _contextInterface.GetHotel(id);
            if (hotel == null)
                return NotFound();
            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name, City, Phone, ID")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                 await _contextInterface.UpdateHotel(hotel);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _contextInterface.DeleteHotel(id);

                return RedirectToAction("Index");
            }
            // Will need to refactor
            // Send to 404 page
            return NotFound();
        }
    }
}