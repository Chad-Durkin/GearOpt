using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearOptimizer.Model
{
    [Table("Bosses")]
    public class Boss
    {
        [Key]
        public int BossId { get; set; }
        public string Name { get; set; }
        public string Weakness { get; set; }
        public string AtkStyle { get; set; }
        public virtual ICollection<FullSet> FullSets { get; set; }
        public virtual ICollection<BossDrops> BossDrops { get; set; }
    }
}
