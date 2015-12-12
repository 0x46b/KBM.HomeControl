using Ninject;
using ServiceStack.Configuration;

namespace HomeControl
{
    public class NinjectIocAdapter : IContainerAdapter
    {
        private readonly IKernel kernel;

        public NinjectIocAdapter(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public T Resolve<T>()
        {
            return kernel.Get<T>();
        }

        public T TryResolve<T>()
        {
            return kernel.CanResolve<T>() ? kernel.Get<T>() : default(T);
        }
    }
}
