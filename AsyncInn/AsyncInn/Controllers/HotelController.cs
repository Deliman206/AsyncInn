using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsyncInn.Models;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.ViewModels;

namespace AsyncInn.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelManeger _context;

        public HotelController(IHotelManeger context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(HotelCreateViewModel hotel2)
        {
            Hotel newHotel = hotel2.Hotel;
            if (ModelState.IsValid)
            {
                await _context.CreateHotel(newHotel);

                return RedirectToAction(nameof(Index));
            }
            return View(newHotel);
        }
    }
}