using Icatu.Domain.Entities;
using System.Collections.Generic;

namespace Icatu.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(int id);
    }
}
