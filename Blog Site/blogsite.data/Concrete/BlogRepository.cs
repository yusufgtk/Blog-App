using blogsite.data.Abstract;
using blogsite.entity;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace blogsite.data.Concrete
{
    public class BlogRepository : Repository<Blog, DataContext>, IBlogRepository
    {
        public Blog GetBlogById(int id)
        {
            using(var context = new DataContext())
            {
                return context.Blogs.FirstOrDefault(i=>i.Id==id);
            }
        }

        public List<Blog> GetBlogsByCategoryId(int categoryId)
        {
            using(var context = new DataContext())
            {
                return context.Blogs.Where(i=>i.CategoryId==categoryId).ToList();
            }
        }

        public List<Blog> GetBlogsBySearch(string search)
        {
            using(var context = new DataContext())
            {
                return context.Blogs.Where(i=>i.Title.ToLower().Contains(search.ToLower())).ToList();
            }
        }

        public List<Blog> GetBlogsTop10()
        {
            using(var context = new DataContext())
            {
                return context.Blogs.OrderByDescending(i=>i.NumberOfClicks).Take(10).ToList();
            }
        }
    }
}