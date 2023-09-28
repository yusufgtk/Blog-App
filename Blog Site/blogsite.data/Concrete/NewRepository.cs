using blogsite.data.Abstract;
using blogsite.entity;

namespace blogsite.data.Concrete
{
    public class NewRepository : Repository<New, DataContext>, INewRepository
    {
        public New GetNewsById(int id)
        {
            throw new NotImplementedException();
        }

        public List<New> GetNewsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<New> GetNewsBySearch(string search)
        {
            using(var context = new DataContext())
            {
                return context.News.Where(i=>i.Title.ToLower().Contains(search.ToLower())).ToList();
            }
        }

        public List<New> GetNewsTop50()
        {
            using(var context = new DataContext())
            {
                return context.News.OrderByDescending(i=>i.CreatedAt).Take(50).ToList();
            }
        }
    }
}