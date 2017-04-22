using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearOptimizer.Model
{
    [Table("Drops")]
    public class Drop
    {
        public int DropId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public virtual ICollection<BossDrops> BossDrops { get; set; }
    }
}
