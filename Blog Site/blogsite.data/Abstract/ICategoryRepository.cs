using blogsite.entity;

namespace blogsite.data.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Category GetCategoryById(int id);
        List<Category> GetCategoriesBySearch(string search);
        
    }
}