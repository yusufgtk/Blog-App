using blogsite.business.Abstract;
using blogsite.data.Abstract;
using blogsite.entity;

namespace blogsite.business.Concrete
{
    public class NewManager : INewService
    {
        private readonly INewRepository _newRepository;
        public NewManager(INewRepository newRepository)
        {
            _newRepository=newRepository;
        }
        public void Create(New entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(New entity)
        {
            throw new NotImplementedException();
        }

        public List<New> GetAll()
        {
            throw new NotImplementedException();
        }

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
            return _newRepository.GetNewsBySearch(search);
        }

        public List<New> GetNewsTop50()
        {
            return _newRepository.GetNewsTop50();
        }

        public void Update(New entity)
        {
            throw new NotImplementedException();
        }
    }
}