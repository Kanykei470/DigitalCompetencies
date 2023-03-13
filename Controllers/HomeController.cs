using DigitalСompetencies1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DigitalСompetencies1.Controllers
{
    public class HomeController : Controller
    {
        DigitalСompetenciesContext db = new DigitalСompetenciesContext();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult tlogin()
        {
            return View();
        }

        public IActionResult slogin()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            //Session[]
            //List<TestCategory> li = db.TestCategories.Where(x => x.cat_fk_adid == 1).ToList();
            //ViewData["list"]=li;

            return View();
        }


        [HttpGet]
        public IActionResult AddQuestion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(TestCategory cat)
        {
            
            List<TestCategory> li = db.TestCategories.Where(x => x.cat_fk_adid == 1).ToList();
            ViewData["list"] = li;

            TestCategory c = new TestCategory();
            c.Name = cat.Name;
            c.Descriprion = cat.Descriprion;
            c.cat_fk_adid = 1;

            db.TestCategories.Add(c);
            db.SaveChanges();


            return RedirectToAction("AddCategory");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}