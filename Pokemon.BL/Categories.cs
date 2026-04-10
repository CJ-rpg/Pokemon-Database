using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
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

        /* ---------- Sync ---------- */

        public List<Category> SelectAll()
        {
            var categories = new List<Category>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "SELECT Id, Name FROM Categories",
                    conn))
                {

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            categories.Add(new Category
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString()
                            });
                        }
                    }
                }

                return categories;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error selecting all Categories from database.", ex);
            }
        }

        public Category Select(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "SELECT Id, Name FROM Categories WHERE Id = @Id",
                    conn))
                {

                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            return new Category
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString()
                            };
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error selecting Category from database.", ex);
            }
        }
        public void Insert(Category category)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "INSERT INTO Categories (Name) VALUES (@Name)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", category.Name);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error inserting Category into database.", ex);
            }
        }

        public void Update(Category category)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "UPDATE Categories SET Name = @Name WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", category.Id);
                    cmd.Parameters.AddWithValue("@Name", category.Name);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error updating Category in database.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "DELETE FROM Categories WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new Exception("No Category was updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error deleting Category from database.", ex);
            }
        }

        public void DeleteAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Categories";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    Console.WriteLine(cmd);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new Exception("No Category was updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting all Categories from database.", ex);
            }
        }

        /* ---------- Async ---------- */

        public async Task<List<Category>> SelectAllAsync()
        {
            var categories = new List<Category>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "SELECT Id, Name FROM Categories", conn))
                {
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            categories.Add(new Category
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString()
                            });
                        }
                    }
                }

                return categories;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error selecting all Categories from database.", ex);
            }
        }

        public async Task<Category> SelectAsync(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                        "SELECT Id, Name FROM Categories WHERE Id = @Id",
                        conn))
                {

                    cmd.Parameters.AddWithValue("@Id", id);

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Category
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString()
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error selecting Category from database.", ex);
            }
        }

        public async Task InsertAsync(Category category)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "INSERT INTO Categories (Name) VALUES (@Name)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", category.Name);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error inserting Category into database.", ex);
            }
        }

        public async Task UpdateAsync(Category category)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "UPDATE Categories SET Name = @Name WHERE Id = @Id",
                    conn))
                {

                    cmd.Parameters.AddWithValue("@Id", category.Id);
                    cmd.Parameters.AddWithValue("@Name", category.Name);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error updating Category in database.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "DELETE FROM Categories WHERE Id = @Id",
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
                    "Error deleting Category from database.", ex);
            }
        }

        public async Task DeleteAllAsync()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                        "DELETE FROM Categories",
                        conn))
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Error deleting all Categories from database.", ex);
            }
        }
    }
}
