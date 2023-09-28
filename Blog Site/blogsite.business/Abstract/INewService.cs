using blogsite.entity;

namespace blogsite.business.Abstract
{
    public interface INewService
    {
        void Create(New entity);
        void Update(New entity);
        void Delete(New entity);
        List<New> GetAll();
        New GetNewsById(int id);
        List<New> GetNewsTop50();
        List<New> GetNewsBySearch(string search);
        List<New> GetNewsByCategoryId(int categoryId);
    }
}