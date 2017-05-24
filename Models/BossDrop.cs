using System.ComponentModel.DataAnnotations.Schema;

namespace GearOptimizer.Models
{
    [Table("BossDrops")]
    public class BossDrop
    {
        public int BossId { get; set; }
        public virtual Boss Boss { get; set; }
        public int DropId { get; set; }
        public virtual Drop Drop { get; set; }
    }
}
