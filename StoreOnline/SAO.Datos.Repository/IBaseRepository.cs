using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Entities.Base;

namespace SANNA.Data.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
    }
}
