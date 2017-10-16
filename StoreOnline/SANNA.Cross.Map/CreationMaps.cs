using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SANNA.Cross.Map
{
    public class CreationMaps
    {

        private CreationMaps()
        {
            Mapper.ForSourceType<string>().AddFormatter<TrimmingFormater>();
            Masters.CreateMaps();
            //Maestros.CrearMapas();
            //Comun.CrearMapas();
            //Configuracion.CrearMapas();
            //Seguimiento.CrearMapas();
            //Registro.CrearMapas();
        }
        public static void Create()
        {
            var instancia = Singleton<CreationMaps>.Instancia;
        }
    }
}
