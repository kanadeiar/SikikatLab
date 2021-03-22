using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.Interfaces
{
    interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Add(T item);
        void Update(T item);
        bool Delete(int id);
    }
}
