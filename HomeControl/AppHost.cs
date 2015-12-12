using HomeControl.Services;
using Ninject;
using Serilog;
using ServiceStack;

namespace HomeControl
{
    public class AppHost : AppSelfHostBase
    {
        public AppHost()
          : base("HttpListener Self-Host", typeof(HelloService).Assembly)
        { }

        public override void Configure(Funq.Container container)
        {
            IKernel kernel = new StandardKernel();
            RegisterServices(kernel);
            container.Adapter = new NinjectIocAdapter(kernel);
        }

        private void RegisterServices(IKernel kernel)
        {
            var logger = CreateLogger();
            kernel.Bind<IHelloService>().To<HelloService>();
            kernel.Bind<ILogger>().ToConstant(logger);
        }

        private ILogger CreateLogger()
        {
            return new LoggerConfiguration().MinimumLevel.Debug().WriteTo.ColoredConsole().CreateLogger();
        }
    }
}
