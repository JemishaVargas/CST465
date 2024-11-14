using Assignment3;

namespace Assignment3
{
    public static class BlogPostExtension
    {
        public static BlogPost ToDataObject(BlogPostModel model)
        {
            return new BlogPost
            {
                ID = model.ID,
                Title = model.Title,
                Content = model.Content,
                Author = model.Author,
                Timestamp = DateTime.Now
            };
        }
        public static BlogPostModel ToModel(BlogPost post)
        {
            return new BlogPostModel
            {
                ID = post.ID,
                Title = post.Title,
                Content = post.Content,
                Author = post.Author,
            };
        }
    }   
}