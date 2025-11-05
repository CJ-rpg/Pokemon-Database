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
                    string query = "SELECT Id, Name FROM abilities";
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
                    string query = "SELECT Id, Name FROM abilities WHERE Id = @Id";
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
                    cmd.ExecuteNonQuery();
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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting all abilities from database.", ex);
            }
        }
    }
}
