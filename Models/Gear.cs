using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearOptimizer.Models
{
    [Table("Gears")]
    public class Gear
    {
        [Key]
        public int Id { get; set; }
        public string Slot { get; set; }
        public string Name { get; set; }
        public string Reqs { get; set; }
        public int Price { get; set; }
        public int AtkStab { get; set; }
        public int AtkSlash { get; set; }
        public int AtkCrush { get; set; }
        public int AtkMagic { get; set; }
        public int AtkRange { get; set; }
        public int DefStab { get; set; }
        public int DefSlash { get; set; }
        public int DefCrush { get; set; }
        public int DefMagic { get; set; }
        public int DefRange { get; set; }
        public int MeleeStr { get; set; }
        public int RangeStr { get; set; }
        public int MagicDmg { get; set; }
        public int Prayer { get; set; }
        public int Undead { get; set; }
        public int Slayer { get; set; }
        public virtual ICollection<FullSetGear> FullSetGears { get; set; }
    }
}
