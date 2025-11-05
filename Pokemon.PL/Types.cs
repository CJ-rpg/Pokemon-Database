using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.BL;
using Pokemon.BL.Logic;

namespace Pokemon.PL
{
    public class TypesPL
    {
        private readonly Types types;

        public TypesPL(string connectionString)
        {
            types = new BL.Types(connectionString);
        }

        public List<BL.Logic.Type> GetAll()
        {
            return types.SelectAll();
        }

        public BL.Logic.Type Get(int id)
        {
            return types.Select(id);
        }

        public void Add(int id, string name)
        {
            BL.Logic.Type type = new BL.Logic.Type { Id = id, Name = name };
            types.Insert(type);
        }

        public void Edit(string name)
        {
            BL.Logic.Type type = new BL.Logic.Type { Name = name };
            types.Update(type);
        }

        public void Remove(int id)
        {
            types.Delete(id);
        }

        public void RemoveAll()
        {
            types.DeleteAll();
        }
    }
}
