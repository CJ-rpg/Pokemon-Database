using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.BL;
using Pokemon.BL.Logic;

namespace Pokemon.PL
{
    public class Categories
    {
        private readonly BL.Categories categories;

        public Categories(string connectionString)
        {
            categories = new BL.Categories(connectionString);
        }

        public List<Category> GetAll()
        {
            return categories.SelectAll();
        }

        public Category Get(int id)
        {
            return categories.Select(id);
        }

        public void Add(int id, string name)
        {
            Category type = new Category { Id = id, Name = name };
            categories.Insert(type);
        }

        public void Edit(string name)
        {
            Category type = new Category { Name = name };
            categories.Update(type);
        }

        public void Remove(int id)
        {
            categories.Delete(id);
        }

        public void RemoveAll()
        {
            categories.DeleteAll();
        }
    }
}
