using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.BL.Logic;

namespace Pokemon.BL
{
    public class Pokemon
    {
        private readonly string _connectionString;
        private bool allowDeleteAll = false;

        public Pokemon(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<BL.Logic.Pokemon> SelectAll()
        {
            List<BL.Logic.Pokemon> pokemon = new List<BL.Logic.Pokemon>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, p.Name, c.Name as Category, Height, Weight " +
                        "FROM Pokemon p join Categories c on p.CategoryId=c.Id";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        pokemon.Add(new BL.Logic.Pokemon
                        {
                            DexNum = (int)reader["DexNum"],
                            Name = reader["Name"].ToString(),
                            Category = reader["Category"].ToString(),
                            Height = (int)reader["Height"], 
                            Weight = (int)reader["Weight"]
                        });
                    }
                }

                return pokemon;
            }
            catch (Exception ex)
            {
                throw new Exception("Error selecting all Pokemon from database.", ex);
            }
        }

        public BL.Logic.Pokemon Select(int id)
        {
            BL.Logic.Pokemon pokemon = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT p.DexNum, p.Name, c.Name AS Category, p.Height, p.Weight, " +
                        "t.Id AS TypeId, t.Name AS TypeName a.Name AS AbilityName" +
                        "FROM Pokemon p JOIN Categories c ON p.CategoryId = c.Id " +
                        "LEFT JOIN PokemonTypes pt ON p.DexNum = pt.DexNum " +
                        "LEFT JOIN Types t ON pt.TypeId = t.Id " +
                        "LEFT JOIN PossibleAbilities pa ON p.DexNum = pa.DexNum " +
                        "LEFT JOIN Abilities a ON pa.AbilityId = a.Id " +
                        "WHERE p.DexNum = @DexNum";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (pokemon == null)
                        {
                            pokemon = new BL.Logic.Pokemon
                            {
                                DexNum = (int)reader["DexNum"],
                                Name = reader["Name"].ToString(),
                                Category = reader["Category"].ToString(),
                                Height = (int)reader["Height"],
                                Weight = (int)reader["Weight"]
                            };
                        }
                        if (reader["TypeId"] != DBNull.Value)
                        {
                            pokemon.Types.Add(new BL.Logic.Type
                            {
                                Id = (int)reader["TypeId"],
                                Name = reader["TypeName"].ToString()
                            });
                        }
                    }
                }

                return pokemon;
            }
            catch (Exception ex)
            {
                throw new Exception("Error selecting Pokemon from database.", ex);
            }
        }

        public void Insert(BL.Logic.Pokemon pokemon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Pokemon (DexNum, Name, CategoryId, Height, Weight) VALUES" +
                        " (@DexNum, @Name, @CategoryId, @Height, @Weight)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DexNum", pokemon.DexNum);
                    cmd.Parameters.AddWithValue("@Name", pokemon.Name);
                    cmd.Parameters.AddWithValue("@CategoryId", pokemon.CategoryId);
                    cmd.Parameters.AddWithValue("@Height", pokemon.Height);
                    cmd.Parameters.AddWithValue("@Weight", pokemon.Weight);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting Pokemon into database.", ex);
            }
        }

        public void Update(BL.Logic.Pokemon pokemon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Pokemon SET Name = @Name, CategoryId = @CategoryId, Height = @Height, Weight = @Weight WHERE DexNum = @DexNum";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@DexNum", SqlDbType.Int).Value = pokemon.DexNum;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = pokemon.Name;
                    cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = pokemon.CategoryId;
                    cmd.Parameters.Add("@Height", SqlDbType.Int).Value = pokemon.Height;
                    cmd.Parameters.Add("@Weight", SqlDbType.Int).Value = pokemon.Weight;
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating Pokemon in database.", ex);
            }
        }

        public void AddTypeToPokemon(int dexNum, int typeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand(
                        "INSERT INTO PokemonTypes (DexNum, TypeId) VALUES (@DexNum, @TypeId)",
                        conn
                    );

                    cmd.Parameters.AddWithValue("@DexNum", dexNum);
                    cmd.Parameters.AddWithValue("@TypeId", typeId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Adding Type to Pokemon in database.", ex);
            }
        }

        public void RemoveTypeFromPokemon(int dexNum, int typeId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                "DELETE FROM PokemonTypes WHERE DexNum = @DexNum AND TypeId = @TypeId",
                conn
                );
                cmd.Parameters.AddWithValue("@DexNum", dexNum);
                cmd.Parameters.AddWithValue("@TypeId", typeId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddAbilityToPokemon(int dexNum, int abilityId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand(
                        "INSERT INTO PossibleAbilities (DexNum, AbilityId) VALUES (@DexNum, @AbilityId)",
                        conn
                    );

                    cmd.Parameters.AddWithValue("@DexNum", dexNum);
                    cmd.Parameters.AddWithValue("@AbilityId", abilityId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Adding Ability to Pokemon in database.", ex);
            }
        }

        public void RemoveAbilityFromPokemon(int dexNum, int abilityId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                "DELETE FROM PossibleAbilities WHERE DexNum = @DexNum AND AbilityId = @AbilityId",
                conn
                );
                cmd.Parameters.AddWithValue("@DexNum", dexNum);
                cmd.Parameters.AddWithValue("@AbilityId", abilityId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Pokemon WHERE DexNum = @DexNum";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DexNum", id);
                    Console.WriteLine(cmd);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new Exception("No Pokemon was updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Pokemon from database.", ex);
            }
        }

        public void DeleteAll()
        {
            if (!allowDeleteAll)
                throw new InvalidOperationException("DeleteAll is disabled.");
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Pokemon";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    Console.WriteLine(cmd);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new Exception("No Pokemon was updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting all Pokemon from database.", ex);
            }
        }
    }
}
