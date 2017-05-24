using System.Linq;
using System;
using GearOptimizer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GearOptimizer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GearOptimizer.Controllers
{
    public class FullSetController : Controller
    {
        private IHostingEnvironment _environment;
        private readonly GearOptimizerDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public FullSetController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, GearOptimizerDbContext db, IHostingEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _environment = environment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //Set FullSetViewModel Variables To All The Gear For Each Slot
            FullSetViewModel fullsetInfo = new FullSetViewModel(_db);
            fullsetInfo.FullSetGears = _db.FullSetGears.ToArray();
            fullsetInfo.FullSetBosses = _db.FullSetBosses.ToArray();
            fullsetInfo.ProfileFullSets = _db.ProfileFullSets.ToArray();
            //};
            return View(fullsetInfo);
        }

        public IActionResult Create()
        {
                //ViewBag For Each Gear Slot To Create Full Sets
                ViewBag.HeadSlotId = new SelectList(_db.Gears.Where(m => m.Slot == "HeadSlot"), "Id", "Name");
                ViewBag.ChestSlotId = new SelectList(_db.Gears.Where(m => m.Slot == "ChestSlot"), "Id", "Name");
                ViewBag.LegSlotId = new SelectList(_db.Gears.Where(m => m.Slot == "LegSlot"), "Id", "Name");
                ViewBag.BootsId = new SelectList(_db.Gears.Where(m => m.Slot == "Boots"), "Id", "Name");
                ViewBag.GlovesId = new SelectList(_db.Gears.Where(m => m.Slot == "Gloves"), "Id", "Name");
                ViewBag.CapeId = new SelectList(_db.Gears.Where(m => m.Slot == "Cape"), "Id", "Name");
                ViewBag.NecklaceId = new SelectList(_db.Gears.Where(m => m.Slot == "Necklace"), "Id", "Name");
                ViewBag.RingId = new SelectList(_db.Gears.Where(m => m.Slot == "Ring"), "Id", "Name");
                ViewBag.ArrowSlotId = new SelectList(_db.Gears.Where(m => m.Slot == "ArrowSlot"), "Id", "Name");
                ViewBag.MainHandId = new SelectList(_db.Gears.Where(m => m.Slot == "MainHand"), "Id", "Name");
                ViewBag.OffHandId = new SelectList(_db.Gears.Where(m => m.Slot == "OffHand"), "Id", "Name");
                ViewBag.SpecWeaponId = new SelectList(_db.Gears.Where(m => m.Slot == "SpecWeapon"), "Id", "Name");
                ViewBag.BossId = new SelectList(_db.Bosses, "Id", "Name");


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewSetViewModel newSetInfo)
        {
            //Create the new FullSet object
            FullSet newFullSet = new FullSet { SetName = newSetInfo.SetName };
            _db.FullSets.Add(newFullSet);

            //Grab the User, Profile, and Boss to add to join tables
            var user = await _userManager.GetUserAsync(User);
            Profile userProfile = _db.Profiles.FirstOrDefault(m => m.User == user);
            Boss boss = _db.Bosses.FirstOrDefault(m => m.Id == newSetInfo.BossId);

            //Add BossId to FullSet
            newFullSet.BossId = boss.Id;

            //**********Add To Join Tables**********

            //Profile Join Table
            ProfileFullSet newProfileSet = new ProfileFullSet { Profile = userProfile, FullSet = newFullSet };
            _db.ProfileFullSets.Add(newProfileSet);

            //Boss Join Table
            FullSetBoss newBossSet = new FullSetBoss { Boss = boss, BossId = boss.Id, FullSet = newFullSet };
            _db.FullSetBosses.Add(newBossSet);

            //Gear Join Table
            //HeadSlot
            FullSetGear headSlot = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.HeadSlotId) };
            _db.FullSetGears.Add(headSlot);
            //ChestSlot
            FullSetGear chestSlot = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.ChestSlotId) };
            _db.FullSetGears.Add(chestSlot);
            //LegSlot
            FullSetGear legSlot = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.LegSlotId) };
            _db.FullSetGears.Add(legSlot);
            //Boots
            FullSetGear boots = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.BootsId) };
            _db.FullSetGears.Add(boots);
            //Gloves
            FullSetGear gloves = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.GlovesId) };
            _db.FullSetGears.Add(gloves);
            //Cape
            FullSetGear cape = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.CapeId) };
            _db.FullSetGears.Add(cape);
            //Necklace
            FullSetGear necklace = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.NecklaceId) };
            _db.FullSetGears.Add(necklace);
            //Ring
            FullSetGear ring = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.RingId) };
            _db.FullSetGears.Add(ring);
            //ArrowSlot
            FullSetGear arrowSlot = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.ArrowSlotId) };
            _db.FullSetGears.Add(arrowSlot);
            //MainHand
            FullSetGear mainHand = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.MainHandId) };
            _db.FullSetGears.Add(mainHand);
            //OffHand
            FullSetGear offHand = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.OffHandId) };
            _db.FullSetGears.Add(offHand);
            //Spec Weapon
            FullSetGear specWeapon = new Models.FullSetGear { FullSet = newFullSet, Gear = _db.Gears.FirstOrDefault(m => m.Id == newSetInfo.SpecWeaponId) };
            _db.FullSetGears.Add(offHand);

            //Save All Changes
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            FullSet editThis = _db.FullSets.FirstOrDefault(m => m.Id == id);
            ViewBag.HeadSlotId = new SelectList(_db.Gears.Where(m => m.Slot == "HeadSlot"), "Id", "Name");
            ViewBag.ChestSlotId = new SelectList(_db.Gears.Where(m => m.Slot == "ChestSlot"), "Id", "Name");
            ViewBag.LegSlotId = new SelectList(_db.Gears.Where(m => m.Slot == "LegSlot"), "Id", "Name");
            ViewBag.BootsId = new SelectList(_db.Gears.Where(m => m.Slot == "Boots"), "Id", "Name");
            ViewBag.GlovesId = new SelectList(_db.Gears.Where(m => m.Slot == "Gloves"), "Id", "Name");
            ViewBag.CapeId = new SelectList(_db.Gears.Where(m => m.Slot == "Cape"), "Id", "Name");
            ViewBag.NecklaceId = new SelectList(_db.Gears.Where(m => m.Slot == "Necklace"), "Id", "Name");
            ViewBag.RingId = new SelectList(_db.Gears.Where(m => m.Slot == "Ring"), "Id", "Name");
            ViewBag.ArrowSlotId = new SelectList(_db.Gears.Where(m => m.Slot == "ArrowSlot"), "Id", "Name");
            ViewBag.MainHandId = new SelectList(_db.Gears.Where(m => m.Slot == "MainHand"), "Id", "Name");
            ViewBag.OffHandId = new SelectList(_db.Gears.Where(m => m.Slot == "OffHand"), "Id", "Name");
            ViewBag.SpecWeaponId = new SelectList(_db.Gears.Where(m => m.Slot == "SpecWeapon"), "Id", "Name");
            ViewBag.BossId = new SelectList(_db.Bosses, "Id", "Name");
            ViewBag.FullSetId = id;

            return View();
        }
        [HttpPost]
        public IActionResult Edit(NewSetViewModel editFullSet)
        {
            //Find the fullset with the ID passed in
            FullSet editThis = _db.FullSets.FirstOrDefault(m => m.Id == editFullSet.FullSetId);
            editThis.SetName = editFullSet.SetName;
            _db.Entry(editThis).State = EntityState.Modified;

            //Remove the previous FullSetGear objects and add the new ones
            //HeadSlot
            var deleteFSGheadslot = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.HeadSlotId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear headSlot = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.HeadSlotId) };
            _db.FullSetGears.Add(headSlot);
            //ChestSlot
            var deleteFSGchestslot = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.ChestSlotId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGchestslot);
            FullSetGear chestSlot = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.ChestSlotId) };
            _db.FullSetGears.Add(chestSlot);
            //LegSlot
            var deleteFSGlegslot = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.LegSlotId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear legSlot = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.LegSlotId) };
            _db.FullSetGears.Add(legSlot);
            //Boots
            var deleteFSGboots = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.BootsId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear boots = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.BootsId) };
            _db.FullSetGears.Add(boots);
            //Gloves
            var deleteFSGgloves = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.GlovesId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear gloves = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.GlovesId) };
            _db.FullSetGears.Add(gloves);
            //Cape
            var deleteFScape = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.CapeId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear cape = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.CapeId) };
            _db.FullSetGears.Add(cape);
            //Necklace
            var deleteFSGnecklace = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.NecklaceId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear necklace = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.NecklaceId) };
            _db.FullSetGears.Add(necklace);
            //Ring
            var deleteFSGring = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.RingId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear ring = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.RingId) };
            _db.FullSetGears.Add(ring);
            //ArrowSlot
            var deleteFSGarrowSlot = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.ArrowSlotId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear arrowSlot = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.ArrowSlotId) };
            _db.FullSetGears.Add(arrowSlot);
            //MainHand
            var deleteFSGmainHand = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.MainHandId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear mainHand = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.MainHandId) };
            _db.FullSetGears.Add(mainHand);
            //OffHand
            var deleteFSGoffHand = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.OffHandId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear offHand = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.OffHandId) };
            _db.FullSetGears.Add(offHand);
            //SpecWeapon
            var deleteFSGspecWeapon = _db.FullSetGears.FirstOrDefault(m => m.GearId == editFullSet.SpecWeaponId && m.FullSetId == editFullSet.FullSetId);
            _db.FullSetGears.Remove(deleteFSGheadslot);
            FullSetGear specWeapon = new Models.FullSetGear { FullSet = editThis, Gear = _db.Gears.FirstOrDefault(m => m.Id == editFullSet.SpecWeaponId) };
            _db.FullSetGears.Add(specWeapon);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var deleteFullSet = _db.FullSets.FirstOrDefault(fullset => fullset.Id == id);
            return View(deleteFullSet);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleteFullSet = _db.FullSets.FirstOrDefault(fullset => fullset.Id == id);
            _db.FullSets.Remove(deleteFullSet);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
