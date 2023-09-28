using blogsite.data.Abstract;
using blogsite.entity;

namespace blogsite.data.Concrete
{
    public class CategoryRepository : Repository<Category, DataContext>, ICategoryRepository
    {
        public List<Category> GetCategoriesBySearch(string search)
        {
            using(var context = new DataContext())
            {
                return context.Categories.Where(i=>i.Name.ToLower().Contains(search.ToLower())).ToList();
            }
        }

        public Category GetCategoryById(int id)
        {
            using(var context = new DataContext())
            {
                return context.Categories.FirstOrDefault(i=>i.Id==id);
            }
        }
    }
}