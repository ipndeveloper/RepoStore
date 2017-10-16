using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Entities.Base;
using SANNA.Data.IRepository;
using SANNA.Comun.Data.Core;

namespace SANNA.Data.Repository
{

    public class XmlRepository<T> : IEntityRepository<T>  where T : BaseEntity
    {

        //readonly XmlContext _xmlContext;
        private readonly IContext _xmlContext;
        public XmlRepository(IContext xmlContext)
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
            try
            {
                object locked = new object();
                lock (locked)
                {
                    if (XmlEntities.Any(i => i.Id == item.Id))
                    {
                        XmlEntities.Remove(item);
                        _xmlContext.SaveChanges(XmlEntities);
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public T GetById(int id)
        {
            return Entities.FirstOrDefault(x => x.Id == id);
        }

        public T Insert(T item)
        {

            try
            {
                if (item.Id == default(int)) //only add if id = default(int)
                {
                    var lastEntity = Entities.LastOrDefault();
                    if (lastEntity != null)
                        item.Id = lastEntity.Id + 1;
                    else
                        item.Id = 1;

                    XmlEntities.Add(item);
                    _xmlContext.SaveChanges(XmlEntities);
                }
                return item;
            }
            catch(Exception ex)
            {
                throw;
            }
     
        }

        public T Update(T item)
        {
            try
            {
                object locked = new object();
                lock (locked)
                {
                    var original = XmlEntities.FirstOrDefault(x => x.Id == item.Id);
                    XmlEntities.Remove(original);
                    XmlEntities.Add(item);
                    _xmlContext.SaveChanges(XmlEntities);
                    return item;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
