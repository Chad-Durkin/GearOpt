using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GearOptimizer.Models
{
    [Table("FullSetBosses")]
    public class FullSetBoss
    {
        public int FullSetId { get; set; }
        public virtual FullSet FullSet { get; set; }
        public int BossId { get; set; }
        public virtual Boss Boss { get; set; }
    }
}