using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsBank.Container
{
    class ContainerBuilder
    {
        private static UnityContainer _container;

        public static UnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new UnityContainer();
                    RegisterTypes(_container);
                }
                return _container;
            }
        }

        private static void RegisterTypes(UnityContainer _container)
        {
            var allClasses = AllClasses.FromApplication().Where(t => t.AssemblyQualifiedName.StartsWith("UsBank")).ToList();
            _container.RegisterTypes(allClasses,
                  WithMappings.FromMatchingInterface,
                  WithName.Default,
                  WithLifetime.ContainerControlled, overwriteExistingMappings: false);           
        }
    }
}
