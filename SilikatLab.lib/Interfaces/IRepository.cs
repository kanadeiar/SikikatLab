using System.Collections.Generic;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.lib.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        int Add(T entity);
        int AddRange(IEnumerable<T> entities);
        T GetOne(int id);
        IEnumerable<T> GetAll();
        int Save(T entity);
        int Delete(T entity);
        int Delete(int Id, byte[] Timestamp);
    }
}
