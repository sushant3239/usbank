using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsBank.Infrastructure
{
    public interface ITypeResolver
    {
        T Resolve<T>();

        List<T> ResolveAll<T>();
    }
}
