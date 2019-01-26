using System.Linq;

namespace MicWay.Driver.Library.Repository.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        T Find(int id);
        IQueryable<T> List();
        void Add(T item);
        void Remove(T item);
        void Edit(T item);
        void Remove(int id);
    }
}
