using API.Model;
using Microsoft.Data.SqlClient;


namespace API.Repository
{
    public class PostRepository
    {

        string _connectionString = "Data Source=localhost;Initial Catalog=Blog;User ID=sa;Password=primitivo7;TrustServerCertificate=True;";

        public List<BlogPost> GetPosts(int limit)
        {
            List<BlogPost> posts = new List<BlogPost>();

            string query = "SELECT TOP (@Limit) * FROM POSTS ORDER BY fecha DESC";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Limit", limit);
                    connection.Open();

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var post = new BlogPost
                                {
                                    Id = Convert.ToInt32(dataReader["id"]),
                                    Titulo = dataReader["titulo"].ToString(),
                                    Fecha = Convert.ToDateTime(dataReader["fecha"]),
                                    Contenido = dataReader["contenido"].ToString(),
                                };
                                posts.Add(post);
                            }
                        }
                    }
                }
            }

            return posts;
        }

        public void Add(BlogPost blogPost)
        {
            string query = "INSERT INTO POSTS (titulo, fecha, contenido) VALUES (@Titulo, @Fecha, @Contenido)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titulo", blogPost.Titulo);
                    command.Parameters.AddWithValue("@Fecha", blogPost.Fecha);
                    command.Parameters.AddWithValue("@Contenido", blogPost.Contenido);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

