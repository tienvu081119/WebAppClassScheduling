using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProfessorController : Controller
    {
        ProfessorRepository repository;

        public ProfessorController(CSContext context)
        {
            repository = new ProfessorRepository(context);
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return Redirect("/professor");
        }


        public IActionResult Index()
        {
            return View(repository.GetProfessors());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Professor obj)
        {
            repository.Add(obj);
            return Redirect("/professor");
        }
    }
}
