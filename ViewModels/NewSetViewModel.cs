using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GearOptimizer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GearOptimizer.ViewModels
{
    public class NewSetViewModel
    {
        public int FullSetId { get; set; }
        public string SetName { get; set; }
        public int HeadSlotId { get; set; }
        public int ChestSlotId { get; set; }
        public int LegSlotId { get; set; }
        public int BootsId { get; set; }
        public int GlovesId { get; set; }
        public int CapeId { get; set; }
        public int NecklaceId { get; set; }
        public int RingId { get; set; }
        public int ArrowSlotId { get; set; }
        public int MainHandId { get; set; }
        public int OffHandId { get; set; }
        public int SpecWeaponId { get; set; }
        public int BossId { get; set; }
    }
}
