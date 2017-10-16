using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Entities.Base;

namespace SANNA.Data.IRepository
{
    public interface IEntityRepository <T> where T : BaseEntity 
    {

        T GetById(int id);

        T Insert(T item);

        T Update(T item);

        void Delete(T item);

        IQueryable<T> Entities { get; }
    }
}
