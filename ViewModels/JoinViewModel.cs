using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GearOptimizer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GearOptimizer.ViewModels
{
    public class JoinViewModel
    {
        public FullSetGear[] FullSetGears { get; set; }
        public FullSetBoss[] FullSetBosses { get; set; }
        public ProfileFullSet[] ProfileFullSets { get; set; }
    }
}
