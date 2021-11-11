using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private IUnitOfWork unitOfWork;
     
        public StudentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var students = unitOfWork.StudentRepository.GetAll();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
