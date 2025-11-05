using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Pokemon.BL.Logic;
using Type = Pokemon.BL.Logic.Type;

namespace Pokemon.BL
{
    public class Types
    {
        private readonly string _connectionString;

        public Types(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Type> SelectAll() {
            List<Type> types = new List<Type>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, Name FROM Types";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        types.Add(new Type
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString()
                        });
                    }
                }

                return types;
            }
            catch (Exception ex)
            {
                throw new Exception("Error selecting all Types from database.", ex);
            }
        }

        public Type Select(int id) {
            Type type = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, Name FROM Types WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        type = new Type
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString()
                        };
                    }
                }

                return type;
            }
            catch (Exception ex)
            {
                throw new Exception("Error selecting Type from database.", ex);
            }
        }

        public void Insert(Type type)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Types (Name) VALUES (@Name)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", type.Name);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting Type into database.", ex);
            }
        }

        public void Update(Type type) {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Types SET Name = @Name WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", type.Id);
                    cmd.Parameters.AddWithValue("@Name", type.Name);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating Type in database.", ex);
            }
        }

        public void Delete(int id) {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Types WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Type from database.", ex);
            }
        }

        public void DeleteAll() {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Types";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting all Types from database.", ex);
            }
        }
    }
}
