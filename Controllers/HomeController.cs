using System.Linq;
using System;
using GearOptimizer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using GearOptimizer.ViewModels;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GearOptimizer.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;
        private readonly GearOptimizerDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, GearOptimizerDbContext db, IHostingEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _environment = environment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            Gear.UpdatePrice(_db);
            return View(_db.Bosses.ToList());
        }
        
        public IActionResult GearSets(int bossId)
        {
            FullSetViewModel fullsetInfo = new FullSetViewModel(_db);
            fullsetInfo.BossId = bossId;

            return Json(fullsetInfo);
        }
        public IActionResult GrabJoins()
        {
            JoinViewModel joinModel = new JoinViewModel {
                FullSetBosses = _db.FullSetBosses.ToArray(),
                FullSetGears = _db.FullSetGears.ToArray()
            };
            return Json(joinModel);
        }

        public IActionResult GetPrice(string itemName)
        {
            var id = Item.LoadJsonFindId(itemName);
            if(id != 0)
            {
                var result = Item.GetPrices("/api/catalogue/detail.json?item=" + id);
                return Json(result);

            }

            return RedirectToAction("Index");
        }
    }
}
