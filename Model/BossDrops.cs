using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearOptimizer.Model
{
    [Table("BossDrops")]
    public class BossDrops
    {
        public int BossId { get; set; }
        public virtual Boss Boss { get; set; }
        public int DropId { get; set; }
        public virtual Drop Drop { get; set; }
    }
}
