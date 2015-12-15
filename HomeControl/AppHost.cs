using HomeControl.Data;
using HomeControl.Data.Interfaces;
using HomeControl.DatabaseServices;
using HomeControl.Services;
using Ninject;
using Ninject.Activation;
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
            InitializeLogging();
            kernel.Bind<IHelloService>().To<HelloService>();
            kernel.Bind<ILogger>().ToMethod(CreateContextLogger);
            kernel.Bind<IUserDatabaseService>().To<UserDatabaseService>();
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
            kernel.Bind<IDatabaseContextFactory>().To<DatabaseContextFactory>();
        }

        private ILogger CreateContextLogger(IContext context)
        {
            var requestingType = context.Request?.ParentRequest?.ParentRequest?.Target?.Member?.DeclaringType;
            if (requestingType == null)
            {
                return Log.Logger;
            }

            return Log.Logger.ForContext(requestingType);
        }

        private void InitializeLogging()
        {
            Log.Logger =  new LoggerConfiguration().MinimumLevel.Debug().WriteTo.ColoredConsole().CreateLogger();
        }
    }
}
