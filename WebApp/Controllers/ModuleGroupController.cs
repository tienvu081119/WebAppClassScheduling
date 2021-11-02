using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace WebApp.Controllers
{
    public class ModuleGroupController : Controller
    {
        ModuleGroupRepository repository;

        public ModuleGroupController(CSContext context)
        {
            repository = new ModuleGroupRepository(context);
        }

        public IActionResult Index()
        {
            return View(repository.GetModuleGroups());
        }

        [HttpPost]

        public IActionResult Excel(IFormFile f)
        {
            List<ModuleGroup> list = new List<ModuleGroup>();
            using (Stream stream = f.OpenReadStream())
            {
                XSSFWorkbook wookbook = new XSSFWorkbook(stream);
                ISheet sheet = wookbook.GetSheetAt(0);
                for(int i = 1; i < sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    list.Add(new ModuleGroup {
                        ModuleId = Convert.ToInt32(row.GetCell(0).NumericCellValue),
                        GroupId = Convert.ToInt32(row.GetCell(0).NumericCellValue)
                    });
                }

            }
            repository.Add(list);
            return Redirect("/modulegroup");
        }


        [HttpPost]

        public IActionResult Create(IFormFile f)
        {
            //.csv
            string root = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","data");

            string filename = Guid.NewGuid().ToString() + Path.GetExtension(f.FileName);
            using (Stream stream = new FileStream(Path.Combine(root,filename),FileMode.Create))
            {
                f.CopyTo(stream);
            }
            int ret = repository.Add(Path.Combine(root, filename));
            return Redirect("/modulegroup");
        }
    }
}
