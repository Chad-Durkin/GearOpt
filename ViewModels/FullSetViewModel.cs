using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GearOptimizer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GearOptimizer.ViewModels
{
    public class FullSetViewModel
    {
        public int BossId { get; set; }
        public FullSet[] FullSets { get; set; }
        public Gear[] Gears { get; set; }
        public Boss[] Bosses { get; set; }
        public FullSetGear[] FullSetGears { get; set; }
        public FullSetBoss[] FullSetBosses { get; set; }
        public Gear[] HeadSlot { get; set; }
        public Gear[] ChestSlot { get; set; }
        public Gear[] LegSlot { get; set; }
        public Gear[] Boots { get; set; }
        public Gear[] Gloves { get; set; }
        public Gear[] Cape { get; set; }
        public Gear[] Necklace { get; set; }
        public Gear[] Ring { get; set; }
        public Gear[] ArrowSlot { get; set; }
        public Gear[] MainHand { get; set; }
        public Gear[] OffHand { get; set; }
        public Gear[] SpecWeapon { get; set; }
        public Profile[] Profiles { get; set; }
        public ProfileFullSet[] ProfileFullSets { get; set; }

        public FullSetViewModel(GearOptimizerDbContext _db)
        {
            HeadSlot = _db.Gears.Where(m => m.Slot == "HeadSlot").ToArray();
            ChestSlot = _db.Gears.Where(m => m.Slot == "ChestSlot").ToArray();
            LegSlot = _db.Gears.Where(m => m.Slot == "LegSlot").ToArray();
            Boots = _db.Gears.Where(m => m.Slot == "Boots").ToArray();
            Gloves = _db.Gears.Where(m => m.Slot == "Gloves").ToArray();
            Cape = _db.Gears.Where(m => m.Slot == "Cape").ToArray();
            Necklace = _db.Gears.Where(m => m.Slot == "Necklace").ToArray();
            Ring = _db.Gears.Where(m => m.Slot == "Ring").ToArray();
            ArrowSlot = _db.Gears.Where(m => m.Slot == "ArrowSlot").ToArray();
            MainHand = _db.Gears.Where(m => m.Slot == "MainHand").ToArray();
            OffHand = _db.Gears.Where(m => m.Slot == "Offhand").ToArray();
            SpecWeapon = _db.Gears.Where(m => m.Slot == "SpecWeapon").ToArray();
            Gears = _db.Gears.ToArray();
            Bosses = _db.Bosses.ToArray();
            Profiles = _db.Profiles.ToArray();
            FullSets = _db.FullSets.ToArray();
        }
    }
}
