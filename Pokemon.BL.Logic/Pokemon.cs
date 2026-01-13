using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.BL.Logic
{
    public class Pokemon
    {
        public int DexNum { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public List<Type> Types { get; set; } = new List<Type>();
    }
}
