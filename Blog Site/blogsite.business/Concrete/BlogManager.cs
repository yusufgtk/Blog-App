using blogsite.business.Abstract;
using blogsite.data.Abstract;
using blogsite.entity;

namespace blogsite.business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository=blogRepository;
        }
        public void Create(Blog entity)
        {
            _blogRepository.Create(entity);
        }

        public void Delete(Blog entity)
        {
            _blogRepository.Delete(entity);
        }

        public List<Blog> GetAll()
        {
            return _blogRepository.GetAll();
        }

        public Blog GetBlogById(int id)
        {
            return _blogRepository.GetBlogById(id);
        }

        public List<Blog> GetBlogsByCategoryId(int categoryId)
        {
            return _blogRepository.GetBlogsByCategoryId(categoryId);
        }

        public List<Blog> GetBlogsBySearch(string search)
        {
            return _blogRepository.GetBlogsBySearch(search);
        }

        public List<Blog> GetBlogsTop10()
        {
            return _blogRepository.GetBlogsTop10();
        }

        public void Update(Blog entity)
        {
            _blogRepository.Update(entity);
        }
    }
}