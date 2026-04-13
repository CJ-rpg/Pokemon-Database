using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.BL.Logic
{
    public class PossibleAbilities
    {
        public int Id { get; set; }
        public int DexNum { get; set; }
        public BL.Logic.Pokemon Pokemon { get; set; }
        public int AbilityId { get; set; }
        public Ability Ability { get; set; }
        public bool Hidden { get; set; }
    }
}
