using System;
namespace ShopsRUsDiscounts.Domain.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(Guid Id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
    }
}

