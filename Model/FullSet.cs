using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearOptimizer.Model
{
    [Table("FullSets")]
    public class FullSet
    {
        [Key]
        public int Id { get; set; }
        public string SetName { get; set; }
        public int FullSetId { get; set; }
        public int HeadSlotId { get; set; }
        public int ChestSlotId { get; set; }
        public int LegSlotId { get; set; }
        public int BootsId { get; set; }
        public int GlovesId { get; set; }
        public int CapeId { get; set; }
        public int NecklaceId { get; set; }
        public int RingId { get; set; }
        public int MainHandId { get; set; }
        public int OffHandId { get; set; }
        public int ArrowSlotId { get; set; }
        public int BossId { get; set; }
        public virtual Boss Boss { get; set; }


    }
}
