using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SpongeProduction.Models
{
    public class SpongeShapeViewModel
    {
        public List<Sponge> Sponges { get; set; }
        public SelectList Shapes { get; set; }
        public string SpongeShape { get; set; }
        public string SearchString { get; set; }
    }
}
