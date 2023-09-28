using blogsite.data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace blogsite.data.Concrete
{
    public class Repository<T, TContext> : IRepository<T>
    where TContext:DbContext,new()
    where T:class
    {
        public void Create(T entity)
        {
            using(var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using(var context = new TContext())
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using(var context = new TContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Update(T entity)
        {
            using(var context = new TContext())
            {
                context.Entry(entity).State=EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}