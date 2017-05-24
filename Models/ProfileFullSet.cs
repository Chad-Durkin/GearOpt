using System.ComponentModel.DataAnnotations.Schema;

namespace GearOptimizer.Models
{
    [Table("ProfileFullSets")]
    public class ProfileFullSet
    {
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int FullSetId { get; set; }
        public FullSet FullSet { get; set; }
    }
}
