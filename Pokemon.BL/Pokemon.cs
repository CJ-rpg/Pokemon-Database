using System;
using System.Collections.Generic;
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
                    string query = "SELECT Id, Name, CategoryId, Height, Weight FROM Pokemon";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        pokemon.Add(new BL.Logic.Pokemon
                        {
                            DexNum = (int)reader["DexNum"],
                            Name = reader["Name"].ToString(),
                            CategoryId = (int)reader["CategoryID"],
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
                    string query = "SELECT Id, Name, CategoryId, Height, Weight FROM Pokemon WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pokemon = new BL.Logic.Pokemon
                        {
                            DexNum = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            CategoryId = (int)reader["CategoryID"],
                            Height = (int)reader["Height"],
                            Weight = (int)reader["Weight"]
                        };
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
                    cmd.Parameters.AddWithValue("@NDexNum", pokemon.Name);
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
                throw new Exception("Error Updating Pokemon in database.", ex);
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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Pokemon from database.", ex);
            }
        }

        public void DeleteAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Pokemon";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting all Pokemon from database.", ex);
            }
        }
    }
}
