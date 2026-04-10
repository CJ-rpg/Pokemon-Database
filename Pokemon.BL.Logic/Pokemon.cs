using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.BL.Logic
{
    public class Pokemon
    {
        [Key]
        public int DexNum { get; set; }

        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

        [Column("Height(m)")]
        public decimal Height { get; set; }

        [Column("Weight(kg)")]
        public decimal Weight { get; set; }

        public List<Type> Types { get; set; } = new List<Type>();
        public List<Ability> Abilities { get; set; } = new List<Ability>();
    }
}
