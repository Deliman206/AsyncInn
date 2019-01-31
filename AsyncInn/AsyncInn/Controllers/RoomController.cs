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
    public class RoomController : Controller
    {
        private readonly IRoomManeger _contextInterface;
        private AsyncInnDbContext _contextDB { get; set; }


        public RoomController(IRoomManeger context, AsyncInnDbContext contextDB)
        {
            _contextInterface = context;
            _contextDB = contextDB;
        }

        public IActionResult Index()
        {
            List<Room> list = _contextDB.ROOM.ToList();
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var rooms = from h in _contextDB.ROOM
                         select h;

            if (!String.IsNullOrEmpty(searchString))
            {
                rooms = rooms.Where(s => s.Name.Contains(searchString));
            }

            return View(await rooms.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Layout")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _contextInterface.CreateRoom(room);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}