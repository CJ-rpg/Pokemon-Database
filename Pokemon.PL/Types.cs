using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.BL;
using Pokemon.BL.Logic;

namespace Pokemon.PL
{
    public class TypesPL
    {
        private readonly BL.Types types;

        public TypesPL(string connectionString)
        {
            types = new BL.Types(connectionString);
        }

        public List<BL.Logic.Type> Select()
        {
            try
            {
                return types.SelectAll();
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load types.", ex);
            }
        }

        public BL.Logic.Type Select(int id)
        {
            try
            {
                return types.Select(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load Types.", ex);
            }
        }

        public void Insert(BL.Logic.Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            try
            {
                types.Insert(type);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to add type.", ex);
            }
        }

        public void Update(BL.Logic.Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            try
            {
                types.Update(type);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to update type.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                types.Delete(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to delete type.", ex);
            }
        }

        /* ---------- Async ---------- */

        public async Task<List<BL.Logic.Type>> SelectAsync()
        {
            try
            {
                return await types.SelectAllAsync();
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load types.", ex);
            }
        }

        public async Task<BL.Logic.Type> SelectAsync(int id)
        {
            try
            {
                return await types.SelectAsync(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load type.", ex);
            }
        }

        public async Task InsertAsync(BL.Logic.Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            try
            {
                await types.InsertAsync(type);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to add type.", ex);
            }
        }

        public async Task UpdateAsync(BL.Logic.Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            try
            {
                await types.UpdateAsync(type);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to update type.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await types.DeleteAsync(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to delete type.", ex);
            }
        }
    }
}
