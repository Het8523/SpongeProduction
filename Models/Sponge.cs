using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpongeProduction.Models
{
    public class Sponge
    {
        public int Id { get; set; }
        public string Company { get; set; }

        public string Colour { get; set; }

        public string Shape { get; set; }


        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int Rating { get; set; }

    }
}
        