using blogsite.business.Abstract;
using blogsite.data.Abstract;
using blogsite.entity;

namespace blogsite.business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }
        public void Create(Category entity)
        {
            _categoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public List<Category> GetCategoriesBySearch(string search)
        {
            return _categoryRepository.GetCategoriesBySearch(search);
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}