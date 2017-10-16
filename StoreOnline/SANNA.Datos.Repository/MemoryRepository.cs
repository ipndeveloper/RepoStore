using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Data.Core;
using SANNA.Data.IRepository;
using SANNA.Comun.Entities.Base;
namespace SANNA.Data.Repository
{
    public class MemoryRepository<T> : IEntityRepository<T> where T : BaseEntity
    {

      
        private readonly IContextMemory _xmlContext;
        public MemoryRepository(IContextMemory xmlContext)
        {
            _xmlContext = xmlContext;
        }


        IList<T> _entities;

        public IQueryable<T> Entities
        {
            get
            {
                return XmlEntities.AsQueryable();
            }
        }

        protected IList<T> XmlEntities
        {
            get
            {
                return _entities ?? (_entities = _xmlContext.Set<T>());
            }
        }

        public void Delete(T item)
        {
            object locked = new object();
            lock (locked)
            {
                if (XmlEntities.Any(i => i.Id == item.Id))
                {

                     XmlEntities.Remove(item);
                    //_xmlContext.SaveChanges(XmlEntities);

                }
            }
        }

        public T GetById(int id)
        {
            return Entities.FirstOrDefault(x => x.Id == id);
        }

        public T Insert(T item)
        {
             object locked = new object();
            if (item.Id == default(int)) //only add if id = default(int)
            {
                lock (locked)
                {
                    var lastEntity = Entities.LastOrDefault();
                    if (lastEntity != null)
                        item.Id = lastEntity.Id + 1;
                    else
                        item.Id = 1;
                    List<T> _item = new List<T>();
                     _item.Add(item);
                    _xmlContext.SaveChanges(_item);
                }
            }
            return item;
        }

        public T Update(T item)
        {
            object locked = new object();
            lock (locked)
            {

                    var orginal = XmlEntities.FirstOrDefault(i => i.Id == item.Id);
                    XmlEntities.Remove(orginal);
                    List<T> _item = new List<T>();
                    _item.Add(item);
                    _xmlContext.SaveChanges(_item);


                
            }

            return item;
        }

        //protected object Locked { get { return new object(); } }
    }
}
