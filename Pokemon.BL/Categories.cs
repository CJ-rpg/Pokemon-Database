using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.BL.Logic;

namespace Pokemon.BL
{
    public class Categories
    {
        private readonly string _connectionString;

        public Categories(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Category> SelectAll()
        {
            List<Category> categories = new List<Category>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, Name FROM Categories";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString()
                        });
                    }
                }

                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error selecting all Categories from database.", ex);
            }
        }

        public Category Select(int id)
        {
            Category category = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, Name FROM Categories WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        category = new Category
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString()
                        };
                    }
                }

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Error selecting Category from database.", ex);
            }
        }

        public void Insert(Category category)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Categories (Name) VALUES (@Name)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting Category into database.", ex);
            }
        }

        public void Update(Category category)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Categorys SET Name = @Name WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", category.Id);
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating Category in database.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Categorys WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Category from database.", ex);
            }
        }

        public void DeleteAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Categorys";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    Console.WriteLine(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting all Categorys from database.", ex);
            }
        }
    }
}
