using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.BL.Logic;

namespace Pokemon.PL
{
    public class PokemonPL
    {
        private readonly BL.Pokemon pokemonBL;

        public PokemonPL(string connectionString)
        {
            pokemonBL = new BL.Pokemon(connectionString);
        }

        public List<BL.Logic.Pokemon> Select()
        {
            try
            {
                return pokemonBL.SelectAll();
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load pokemon.", ex);
            }
        }

        public BL.Logic.Pokemon Select(int id)
        {
            try
            {
                return pokemonBL.Select(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load pokemon.", ex);
            }
        }

        public void Insert(BL.Logic.Pokemon pokemon)
        {
            if (pokemon == null)
                throw new ArgumentNullException(nameof(pokemon));

            try
            {
                pokemonBL.Insert(pokemon);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to add pokemon.", ex);
            }
        }

        public void Update(BL.Logic.Pokemon pokemon)
        {
            if (pokemon == null)
                throw new ArgumentNullException(nameof(pokemon));

            try
            {
                pokemonBL.Update(pokemon);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to update pokemon.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                pokemonBL.Delete(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to delete pokemon.", ex);
            }
        }

        /* ---------- Async ---------- */

        public async Task<List<BL.Logic.Pokemon>> SelectAsync()
        {
            try
            {
                return await pokemonBL.SelectAllAsync();
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load pokemon.", ex);
            }
        }

        public async Task<BL.Logic.Pokemon> SelectAsync(int id)
        {
            try
            {
                return await pokemonBL.SelectAsync(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to load pokemon.", ex);
            }
        }

        public async Task InsertAsync(BL.Logic.Pokemon pokemon)
        {
            if (pokemon == null)
                throw new ArgumentNullException(nameof(pokemon));

            try
            {
                await pokemonBL.InsertAsync(pokemon);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to add pokemon.", ex);
            }
        }

        public async Task UpdateAsync(BL.Logic.Pokemon pokemon)
        {
            if (pokemon == null)
                throw new ArgumentNullException(nameof(pokemon));

            try
            {
                await pokemonBL.UpdateAsync(pokemon);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to update pokemon.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await pokemonBL.DeleteAsync(id);
            }
            catch (DbException ex)
            {
                throw new ApplicationException("Unable to delete pokemon.", ex);
            }
        }
    }
}
