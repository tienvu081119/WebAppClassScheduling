using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ModuleController : Controller
    {
        //Khuyết điểm
        ModuleRepository repository;
        ProfessorRepository professorRepository;
        ModuleProfessorRepository moduleProfessorRepository;


        public ModuleController(CSContext context)
        {
            repository = new ModuleRepository(context);
            professorRepository = new ProfessorRepository(context);
            moduleProfessorRepository = new ModuleProfessorRepository(context);      
        }

        public IActionResult AddModuleProfessor(ModuleProfessor obj)
        {
            // return Json(moduleProfessorRepository.Add(obj));
            return Json(moduleProfessorRepository.Save(obj));
        }      
        public IActionResult Browse(int id)
        {
            ViewBag.professors = professorRepository.GetProfessorCheckeds(id);
            return View(repository.GetModuleById(id));
        }


        public IActionResult Index()
        {
            ViewBag.modules = repository.GetModules();
            return View();

        }

        [HttpPost]
        public IActionResult Create(Module obj)
        {
            repository.Add(obj);
            return Redirect("/module");
        }

        public IActionResult Detail(int id)
        {
            //ViewBag.professors = professorRepository.GetProfessors();
            //ViewBag.professors = professorRepository.GetProfessorsNotInModule(id);
            //ViewBag.moduleProfessors = moduleProfessorRepository.GetModuleProfessorsByModule(id);
            //ViewBag.professorsModule = professorRepository.GetProfessorsByModuleId(id);
            return View(repository.GetModuleAndProfessors(id));
        }

        [HttpPost]
        public IActionResult Detail (int id,int[] professorId )
        {
            List<ModuleProfessor> list = new List<ModuleProfessor>();
            foreach(var pid in professorId)
            {
                list.Add(new ModuleProfessor { ModuleId = id, ProfessorId = pid });
            }
            moduleProfessorRepository.Add(list);
            return Redirect($"/module/detail/{id}");
        }
    }
}
