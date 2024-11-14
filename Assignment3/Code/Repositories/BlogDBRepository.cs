using Assignment3;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;

public class BlogDBRepository : IDataEntityRepository<BlogPost>
{
    private readonly IConfiguration _Config;
    public BlogDBRepository(IConfiguration configuration)
    {
        _Config = configuration;
    }
    public BlogPost Get(int id)
    {
        return GetList().FirstOrDefault(pt => pt.ID == id);
    }

    public List<BlogPost> GetList()
    {
        List<BlogPost> blogs = new List<BlogPost>();
        using SqlConnection connection = new SqlConnection(_Config["ConnectionStrings:DB_BlogPosts"]);
        using SqlCommand command = new SqlCommand("BlogPost_GetList", connection);

        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        while(reader.Read())
        {
            BlogPost blog = new BlogPost();
            blog.ID = (int)reader["ID"];
            blog.Author = reader["Author"].ToString();
            blog.Content = reader["Content"].ToString();
            blog.Title = reader["Title"].ToString();
            blog.Timestamp = (DateTime)reader["Timestamp"];
            blogs.Add(blog);
        }

        return blogs;
    }

    public void Save(BlogPost entity)
    {
        using SqlConnection connection = new SqlConnection(_Config["ConnectionStrings:DB_BlogPosts"]);
        using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "BlogPost_InsertUpdate";
        command.Connection.Open();
        if(entity.ID > 0)
        {
            command.Parameters.AddWithValue("@ID", entity.ID);
        }
        command.Parameters.AddWithValue("@Author", entity.Author);
        command.Parameters.AddWithValue("@Content", entity.Content);
        command.Parameters.AddWithValue("@Title", entity.Title);
        command.ExecuteNonQuery();
    }
}