using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.BL.Logic;

namespace Pokemon.BL
{
    public class Abilities
    {
        private readonly string _connectionString;

        public Abilities(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Ability> SelectAll()
        {
            List<Ability> abilities = new List<Ability>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, Name, Description FROM abilities";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        abilities.Add(new Ability
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString()
                        });
                    }
                }

                return abilities;
            }
            catch (Exception ex)
            {
                throw new Exception("Error selecting all abilities from database.", ex);
            }
        }

        public Ability Select(int id)
        {
            Ability ability = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, Name, Description FROM abilities WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ability = new Ability
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                    }
                }

                return ability;
            }
            catch (Exception ex)
            {
                throw new Exception("Error selecting Ability from database.", ex);
            }
        }

        public void Insert(Ability ability)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO abilities (Name, Description) VALUES (@Name, @Description)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", ability.Name);
                    cmd.Parameters.AddWithValue("@Description", ability.Description);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting Ability into database.", ex);
            }
        }

        public void Update(Ability ability)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE abilities SET Name = @Name, Description = @Description WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", ability.Id);
                    cmd.Parameters.AddWithValue("@Name", ability.Name);
                    cmd.Parameters.AddWithValue("@Description", ability.Description);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating Ability in database.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM abilities WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    Console.WriteLine(cmd);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new Exception("No Ability was updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Ability from database.", ex);
            }
        }

        public void DeleteAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM abilities";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    Console.WriteLine(cmd);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new Exception("No Ability was updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting all abilities from database.", ex);
            }
        }

        /* ---------- Async ---------- */

        public async Task<List<Ability>> SelectAllAsync()
        {
            var abilities = new List<Ability>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "SELECT Id, Name, Description FROM Abilities", conn))
                {
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            abilities.Add(new Ability
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                            });
                        }
                    }
                }

                return abilities;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error selecting all Abilities from database.", ex);
            }
        }

        public async Task<Ability> SelectAsync(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                        "SELECT Id, Name, Description FROM Abilities WHERE Id = @Id",
                        conn))
                {

                    cmd.Parameters.AddWithValue("@Id", id);

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Ability
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString()
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error selecting Ability from database.", ex);
            }
        }

        public async Task InsertAsync(Ability ability)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "INSERT INTO Abilities (Name, Description) VALUES (@Name, @Description)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", ability.Name);
                    cmd.Parameters.AddWithValue("@Description", ability.Description);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error inserting Ability into database.", ex);
            }
        }

        public async Task UpdateAsync(Ability ability)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "UPDATE Abilities SET Name = @Name Description = @Description WHERE Id = @Id",
                    conn))
                {

                    cmd.Parameters.AddWithValue("@Id", ability.Id);
                    cmd.Parameters.AddWithValue("@Name", ability.Name);
                    cmd.Parameters.AddWithValue("@Description", ability.Description);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error updating Ability in database.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "DELETE FROM Abilities WHERE Id = @Id",
                    conn))
                {

                    cmd.Parameters.AddWithValue("@Id", id);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error deleting Ability from database.", ex);
            }
        }

        public async Task DeleteAllAsync()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                        "DELETE FROM Abilities",
                        conn))
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error deleting all Abilities from database.", ex);
            }
        }
    }
}
