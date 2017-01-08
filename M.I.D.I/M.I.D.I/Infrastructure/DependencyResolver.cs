using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveModule;
using Ninject;

namespace M.I.D.I.Infrastructure
{
    public class DependencyResolver
    {
        public IKernel kernel;

        public DependencyResolver()
        {
            kernel = new StandardKernel();
            ResolveConfig.Configure(kernel);
        }
    }
}
