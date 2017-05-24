using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearOptimizer.Models
{
    [Table("Bosses")]
    public class Boss
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Weakness { get; set; }
        public string PopGroupSize { get; set; }
        public string AtkStyle { get; set; }
        public virtual ICollection<FullSetBoss> FullSetBosses { get; set; }
        public virtual ICollection<BossDrop> BossDrops { get; set; }
    }
}
