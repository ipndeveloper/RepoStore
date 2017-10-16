using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SANNA.Comun.Entities.Base;

namespace SANNA.Comun.Data.Core
{
    public partial class XmlContext : IContext
    {
        public XmlContext(string DataConnectionString)
        {
            _xmlFileLocation = DataConnectionString;
        }

        readonly string _xmlFileLocation;

        public void SaveChanges<T>(IList<T> entities)
            where T : BaseEntity
        {
            if (entities == null)
                return;

            try
            {
                string filePath = Path.Combine(_xmlFileLocation, $"{typeof(T).Name}.xml");
                using (var writer = new StreamWriter(filePath))
                {
                    var serializer = new XmlSerializer(typeof(List<T>));
                    serializer.Serialize(writer, entities);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public IList<T> Set<T>()  where T : BaseEntity
        {
            try
            {
                var entityName = string.Format("{0}.xml", typeof(T).Name.ToString());
                var entityPluralize = string.Format("ArrayOf{0}", typeof(T).Name.ToString());
                string filePath = Path.Combine(_xmlFileLocation, entityName);
                IList<T> entities = new List<T>();
                if (File.Exists(filePath))
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(entityPluralize));
                        entities = serializer.Deserialize(stream) as List<T>;
                    }
                }
                return entities.OrderBy(e => e.Id).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

          
        }

    }
}
