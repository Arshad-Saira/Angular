using System.Data;
using System.Data.SqlClient;
using WebApplication2.Models;

namespace WebApplication2.DataAccessLayer
{
    public class BookDAL
    {
        private readonly string _connectionString;

        public BookDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Book> GetBooks()
        {
            var books = new List<Book>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllBooks", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var book = new Book
                        {
                            Id = (int)reader["Id"],
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = (decimal)reader["Price"],
                            ImageUrl = reader["ImageUrl"].ToString()
                        };

                        books.Add(book);
                    }
                }
            }
            return books;
        }

        public Book GetBook(int id)
        {
            Book book = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetBookById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        book = new Book
                        {
                            Id = (int)reader["Id"],
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = (decimal)reader["Price"],
                            ImageUrl = reader["ImageUrl"].ToString()
                        };
                    }
                }
            }
            return book;
        }
        public Book GetBook(string author)
        {
            Book book = null;
            Console.Write(author);
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetBookByAuthor", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Author", author);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("got itt");
                        book = new Book
                        {
                            Id = (int)reader["Id"],
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = (decimal)reader["Price"],
                            ImageUrl = reader["ImageUrl"].ToString()
                        };
                    }
                }
            }

            return book;
        }
        public void AddBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddBook", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Description", book.Description);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@Imageurl", book.ImageUrl);
                Console.WriteLine(cmd.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateBook", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Description", book.Description);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@Imageurl", book.ImageUrl);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteBook(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteBook", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}