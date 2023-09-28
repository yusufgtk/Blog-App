using blogsite.entity;

namespace blogsite.business.Abstract
{
    public interface IBlogService
    {
        void Create(Blog entity);
        void Update(Blog entity);
        void Delete(Blog entity);
        List<Blog> GetAll();
        Blog GetBlogById(int id);
        List<Blog> GetBlogsTop10();
        List<Blog> GetBlogsBySearch(string search);
        List<Blog> GetBlogsByCategoryId(int categoryId);
    }
}