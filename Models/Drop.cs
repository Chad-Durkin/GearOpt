using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearOptimizer.Models
{
    [Table("Drops")]
    public class Drop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public virtual ICollection<BossDrop> BossDrops { get; set; }
    }
}
