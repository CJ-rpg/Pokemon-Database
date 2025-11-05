using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.BL.Logic
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PossibleAbilities> PossibleAbilities { get; set; } = new List<PossibleAbilities>();
    }
}
