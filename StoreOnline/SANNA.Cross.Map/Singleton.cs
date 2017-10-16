using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANNA.Cross.Map
{
    public static class Singleton<T> where T : class
    {
        private static volatile T _instancia;
        private static readonly object _locker = new object();

        static Singleton() { }
        public static T Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (_locker)
                    {
                        if (_instancia == null)
                            _instancia = Activator.CreateInstance(typeof(T), true) as T;
                    }
                }
                return _instancia;
            }
        }
    }
}
