using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpongeProduction.Models
{
    public class Sponge
    {
        public int Id { get; set; }
        public string Company { get; set; }

        public string Colour { get; set; }

        public string Shape { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
