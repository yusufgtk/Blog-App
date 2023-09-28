using blogsite.entity;

namespace blogsite.data.Abstract
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog GetBlogById(int id);
        List<Blog> GetBlogsTop10();
        List<Blog> GetBlogsBySearch(string search);
        List<Blog> GetBlogsByCategoryId(int categoryId);
    }
}