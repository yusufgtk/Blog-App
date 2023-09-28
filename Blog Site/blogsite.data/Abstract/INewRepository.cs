using blogsite.entity;

namespace blogsite.data.Abstract
{
    public interface INewRepository : IRepository<New>
    {
        New GetNewsById(int id);
        List<New> GetNewsTop50();
        List<New> GetNewsBySearch(string search);
        List<New> GetNewsByCategoryId(int categoryId);
    }
}