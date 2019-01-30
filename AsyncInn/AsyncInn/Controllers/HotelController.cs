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
        private AsyncInnDbContext _contextDB { get; }


        public HotelController(IHotelManeger context, AsyncInnDbContext contextDB)
        {
            _contextInterface = context;
            _contextDB = contextDB;
        }

        // Initial Render
        // refactor to async
        public IActionResult Index()
        {
            return View(_contextDB.HOTEL.ToList());
        }

        public IActionResult Create()
        {
            return View();
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
        public async Task<IActionResult> Edit(int id, [Bind("Name, City, Phone")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                 await _contextInterface.UpdateHotel(hotel);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
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