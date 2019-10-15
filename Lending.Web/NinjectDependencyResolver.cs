using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;

namespace Lending.Web
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public virtual IDependencyScope BeginScope()
        {
            return (IDependencyScope)this;

        }

        public void Dispose()
        {
            this.kernel.Dispose();
        }
    }
}