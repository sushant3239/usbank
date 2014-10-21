using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsBank.Infrastructure;

namespace UsBank.Container
{
    class TypeResolver : ITypeResolver
    {
        private UnityContainer _container;
        private static ITypeResolver _instance;
        private TypeResolver()
        {
            _container = ContainerBuilder.Container;
            _container.RegisterInstance<ITypeResolver>(this);
        }

        public static ITypeResolver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TypeResolver();
                }
                return _instance;
            }
        }

        public T Resolve<T>()
        {
            if (_container.IsRegistered<T>())
            {
                return _container.Resolve<T>();
            }

            throw new Exception("Type not registered");
        }


        public List<T> ResolveAll<T>()
        {
            return _container.ResolveAll<T>().ToList();
        }
    }
}
