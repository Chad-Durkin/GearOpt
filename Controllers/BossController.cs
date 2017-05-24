using System.Linq;
using System;
using GearOptimizer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GearOptimizer.Controllers
{
    public class BossController : Controller
    {
        private IHostingEnvironment _environment;
        private readonly GearOptimizerDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public BossController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, GearOptimizerDbContext db, IHostingEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _environment = environment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_db.Bosses.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Boss boss)
        {
            _db.Bosses.Add(boss);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisBoss = _db.Bosses.FirstOrDefault(boss => boss.Id == id);
            return View(thisBoss);
        }
        [HttpPost]
        public IActionResult Edit(Boss editedBoss)
        {
            _db.Entry(editedBoss).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var deleteBoss = _db.Bosses.FirstOrDefault(boss => boss.Id == id);
            return View(deleteBoss);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleteBoss = _db.Bosses.FirstOrDefault(boss => boss.Id == id);
            _db.Bosses.Remove(deleteBoss);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var bossDetails = _db.Bosses.FirstOrDefault(boss => boss.Id == id);;
            return View(bossDetails);
        }
    }
}
