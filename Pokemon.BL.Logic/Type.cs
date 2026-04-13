using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.BL.Logic
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PokemonTypes> PokemonTypes { get; set; }
    }
}
