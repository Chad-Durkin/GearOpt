using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GearOptimizer.Models
{
    [Table("FullSetGears")]
    public class FullSetGear
    {
        public int FullSetId { get; set; }
        public virtual FullSet FullSet { get; set; }
        public int GearId { get; set; }
        public virtual Gear Gear { get; set; }
    }
}
