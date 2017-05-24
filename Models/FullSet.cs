using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearOptimizer.Models
{
    [Table("FullSets")]
    public class FullSet
    {
        [Key]
        public int Id { get; set; }
        public string SetName { get; set; }
        public int BossId { get; set; }
        public virtual ICollection<FullSetGear> FullSetGears { get; set; }
        public virtual ICollection<FullSetBoss> FullSetBosses { get; set; }
        public virtual ICollection<ProfileFullSet> ProfileFullSets { get; set; }
    }
}
