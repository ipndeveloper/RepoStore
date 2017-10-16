using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SANNA.Comun.Entities.Base;
using SANNA.Cross.Helpers.Data;

namespace SANNA.Comun.Data.Core
{
    public class MemoryContext : IContextMemory
    {


        public void SaveChanges<T>(IList<T> entities) where T : BaseEntity
        {

            if (entities == null)
                return;
            try
            {
                    
                var NameMethod = string.Format("ArrayOf{0}", typeof(T).Name.ToString());
                this.ReaderData<T>(NameMethod).Add(entities.LastOrDefault());
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }

        public IList<T> Set<T>() where T : BaseEntity
        {
            try
            {
                var NameMethod = string.Format("ArrayOf{0}", typeof(T).Name.ToString());
                return this.ReaderData<T>(NameMethod);
            }
            catch (Exception ex)
            {
                throw;
            }
            
           
            
        }
        public IList<T> ReaderData<T>(string name) where T : BaseEntity
        {

            try
            {
                IList<T> items = new List<T>();
                Type Memory = (typeof(DataMemory));
                MethodInfo[] myArrayMethodInfo = Memory.GetMethods(System.Reflection.BindingFlags.Static | BindingFlags.Public);

                if (myArrayMethodInfo.Any(x => x.Name == name))
                {
                    items = (List<T>)Memory.GetMethod(name).Invoke(null, null);
                }

                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
