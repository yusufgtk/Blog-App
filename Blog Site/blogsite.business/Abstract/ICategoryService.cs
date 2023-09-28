using blogsite.entity;

namespace blogsite.business.Abstract
{
    public interface ICategoryService
    {
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        List<Category> GetAll();
        List<Category> GetCategoriesBySearch(string search);
        Category GetCategoryById(int id);
    }
}