using FiapStore.Entities;

namespace FiapStore.Interface
{
    public interface IRepository<T> where T : Entity
    {
        IList<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
