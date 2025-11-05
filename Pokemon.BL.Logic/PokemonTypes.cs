using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.BL.Logic
{
    public class PokemonTypes
    {
        public int Id { get; set; }
        public int DexNum { get; set; }
        public Pokemon Pokemon { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}
