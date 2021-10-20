using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RoomController : Controller
    {
        RoomRepository repository;

        public RoomController(CSContext context)
        {
            repository = new RoomRepository(context);
        }
        
        public IActionResult Edit(int id)
        {
            return View(repository.GetById(id));
        }
        [HttpPost]

        public IActionResult Edit(Room obj)
        {
            repository.Edit(obj);
            return Redirect("/room");
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return Redirect("/room");
        }
        public IActionResult Index()
        {
            return View(repository.GetRooms());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room obj)
        {
            repository.Add(obj);            
            return Redirect("/room");
        }
    }
}
