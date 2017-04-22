using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GearOptimizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GearOptimizer.Controllers
{
    public class GearController : Controller
    {
        private GearOptimizerDbContext db = new GearOptimizerDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Gears.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Gear newGear)
        {
            db.Gears.Add(newGear);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
