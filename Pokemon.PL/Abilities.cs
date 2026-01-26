using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.BL.Logic;

namespace Pokemon.PL
{
    public class Abilities
    {
        private readonly BL.Abilities abilities;

        public Abilities(string connectionString)
        {
            abilities = new BL.Abilities(connectionString);
        }

        public List<Ability> Select()
        {
            try
            {
                return abilities.SelectAll();
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load abilities.", ex);
            }
        }

        public Ability Select(int id)
        {
            try
            {
                return abilities.Select(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load ability.", ex);
            }
        }

        public void Insert(Ability ability)
        {
            if (ability == null)
                throw new ArgumentNullException(nameof(ability));

            try
            {
                abilities.Insert(ability);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to add ability.", ex);
            }
        }

        public void Update(Ability ability)
        {
            if (ability == null)
                throw new ArgumentNullException(nameof(ability));

            try
            {
                abilities.Update(ability);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to update ability.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                abilities.Delete(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to delete ability.", ex);
            }
        }

        /* ---------- Async ---------- */

        public async Task<List<Ability>> SelectAsync()
        {
            try
            {
                return await abilities.SelectAllAsync();
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load abilities.", ex);
            }
        }

        public async Task<Ability> SelectAsync(int id)
        {
            try
            {
                return await abilities.SelectAsync(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load ability.", ex);
            }
        }

        public async Task InsertAsync(Ability ability)
        {
            if (ability == null)
                throw new ArgumentNullException(nameof(ability));

            try
            {
                await abilities.InsertAsync(ability);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to add ability.", ex);
            }
        }

        public async Task UpdateAsync(Ability ability)
        {
            if (ability == null)
                throw new ArgumentNullException(nameof(ability));

            try
            {
                await abilities.UpdateAsync(ability);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to update ability.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await abilities.DeleteAsync(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to delete ability.", ex);
            }
        }
    }
}
