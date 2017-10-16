using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Entities.Base;

namespace SANNA.Comun.Data.Core
{
    public interface IContext
    {
        void SaveChanges<T>(IList<T> entities) where T : BaseEntity;
        IList<T> Set<T>() where T : BaseEntity;
    }
}
