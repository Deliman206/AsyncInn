using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly IAmenitiesManager _contextInterface;
        private AsyncInnDbContext _contextDB { get; set; }


        public AmenitiesController(IAmenitiesManager context, AsyncInnDbContext contextDB)
        {
            _contextInterface = context;
            _contextDB = contextDB;
        }

        public IActionResult Index()
        {
            List<Amenities> list = _contextDB.AMENITIES.ToList();
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var amenities = from h in _contextDB.AMENITIES
                         select h;

            if (!String.IsNullOrEmpty(searchString))
            {
                amenities = amenities.Where(s => s.Name.Contains(searchString));
            }

            return View(await amenities.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, ID")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                await _contextInterface.CreateAmenities(amenities);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var amenities = await _contextInterface.GetAmenities(id);
            if (amenities == null)
                return NotFound();
            return View(amenities);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name, ID")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                await _contextInterface.UpdateAmenities(amenities);

                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _contextInterface.DeleteAmenities(id);

                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}