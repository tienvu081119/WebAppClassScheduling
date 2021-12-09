using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class ImageController : BaseController
    {


        public ImageController(SiteProvider provider) : base(provider) { }

        public IActionResult DragAndDrop()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DragAndDrop(IFormFile[] af)
        {
            if (af != null)
            {
                string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                List<Image> list = new List<Image>();
                foreach(IFormFile f in af)
                {
                    string ext = Path.GetExtension(f.FileName);
                    string imageUrl = Helper.RandomString(32 - ext.Length) + ext;
                    using (Stream stream = new FileStream(Path.Combine(root, imageUrl),FileMode.Create))
                    {
                        f.CopyTo(stream);
                    }
                    list.Add(new Image {
                        Id = Guid.NewGuid(),
                        Original = f.FileName,
                        Size = f.Length,
                        Type = f.ContentType,
                        Url = imageUrl
                    });
                }
                return Json(provider.Image.Add(list));
            }
            return NotFound();
        }

        public IActionResult WebCam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WebCam(string f)
        {
            byte[] bytes = Convert.FromBase64String(f);
            string fileName = Helper.RandomString(28) + ".png";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                stream.Write(bytes,0,bytes.Length);
            }
            Image image = new Image
            {
                Id = Guid.NewGuid(),
                Original = fileName,
                Url = fileName,
                Size = bytes.Length,
                Type = "image/png"

            };
            return Json(provider.Image.Add(image));

        }


        public IActionResult WebUrl()
        {
            return View();
        }

        public IActionResult DownloadCsv()
        {
            if(HttpContext.Request.Method == "POST")
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load("https://www.biz.uiowa.edu/jledolter/DataMining/datatext.html");
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//ul/li/a");
                List<string> list = new List<string>();
                foreach(HtmlNode node in nodes)
                {
                    list.Add(node.GetAttributeValue("href",null));
                }
                return View(list);
            }
            return View();
        }

        [HttpPost]
        public IActionResult WebUrl(string url)
        {
            string extention = Path.GetExtension(url);
            string imageUrl = Helper.RandomString(32- extention.Length) + extention;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",imageUrl);
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, path);
            }
            Image image = new Image
            {
                Id = Guid.NewGuid(),
                Original = Path.GetFileName(url),
                Size = 0,
                Type = extention,
                Url = imageUrl
            };

            provider.Image.Add(image);
            return Redirect("/dashboard/image");

        }

        public IActionResult Icon()
        {
            return View();
        }
        
        [HttpPost]

        public IActionResult Icon(IFormFile f)
        {
            return Create(f);
        }

        public IActionResult Multiple()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Multiple(IFormFile[] af)
        {
            if (af != null)
            {
                string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                List<Image> list = new List<Image>();
                foreach (IFormFile f in af)
                {
                    string extension = Path.GetExtension(f.FileName);
                    string imageUrl = Helper.RandomString(32 - extension.Length) + extension;
                    using (FileStream stream = new FileStream(Path.Combine(root, imageUrl), FileMode.Create))
                    {
                        f.CopyTo(stream);
                    }
                    list.Add(new Image {
                        Id = Guid.NewGuid(),
                        Original = f.FileName,
                        Url = imageUrl,
                        Size = f.Length,
                        Type = f.ContentType
                    });
                    
                }
                provider.Image.Add(list);
                return Redirect("/dashboard/image");
            }
            ModelState.AddModelError("", "Please choose image");
            return View();
        }

        public IActionResult Index()
        {
            return View(provider.Image.GetImages());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile f)
        {
            if (f != null)
            {
                string imageUrl = Helper.RandomString(28) + Path.GetExtension(f.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageUrl);
                using (FileStream stream = new FileStream(path,FileMode.Create))
                {
                    f.CopyTo(stream);
                }
                Image image = new Image
                {
                    Id = Guid.NewGuid(),
                    Original = f.FileName,
                    Url = imageUrl,
                    Size = f.Length,
                    Type = f.ContentType
                };
                provider.Image.Add(image);
                return Redirect("/dashboard/image");

            }
            ModelState.AddModelError("", "Please choose image");
            return View();
        }
    }
}
