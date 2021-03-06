﻿using System;
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
            List<Room> list = _contextDB.ROOM.Include("RoomAmenities").ToList();

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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var room = await _contextInterface.GetRoom(id);
            if (room == null)
                return NotFound();
            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name, Layout, ID")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _contextInterface.UpdateRoom(room);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _contextInterface.DeleteRoom(id);

                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}