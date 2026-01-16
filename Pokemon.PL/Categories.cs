using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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

        public List<Category> Select()
        {
            try
            {
                return categories.SelectAll();
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load categories.", ex);
            }
        }

        public Category Select(int id)
        {
            try
            {
                return categories.Select(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load category.", ex);
            }
        }

        public void Insert(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            try
            {
                categories.Insert(category);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to add category.", ex);
            }
        }

        public void Update(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            try
            {
                categories.Update(category);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to update category.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                categories.Delete(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to delete category.", ex);
            }
        }

        /* ---------- Async ---------- */

        public async Task<List<Category>> SelectAsync()
        {
            try
            {
                return await categories.SelectAllAsync();
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load categories.", ex);
            }
        }

        public async Task<Category> SelectAsync(int id)
        {
            try
            {
                return await categories.SelectAsync(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load category.", ex);
            }
        }

        public async Task InsertAsync(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            try
            {
                await categories.InsertAsync(category);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to add category.", ex);
            }
        }

        public async Task UpdateAsync(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            try
            {
                await categories.UpdateAsync(category);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to update category.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await categories.DeleteAsync(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to delete category.", ex);
            }
        }
    }
}
