using HomeControl.Data;
using HomeControl.Data.Interfaces;
using HomeControl.DatabaseServices;
using HomeControl.LoggingAdapter;
using HomeControl.Services;
using Ninject;
using Ninject.Activation;
using Serilog;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Logging;

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

            LogManager.LogFactory = container.Resolve<ILogFactory>();

            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                    new IAuthProvider[] {
                    new BasicAuthProvider(), //Sign-in with HTTP Basic Auth
                    new CredentialsAuthProvider(), //HTML Form post of UserName/Password credentials
                  }));

            Plugins.Add(new RegistrationFeature());

            container.Register<ICacheClient>(new MemoryCacheClient());
            var userRep = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userRep);
        }

        private void RegisterServices(IKernel kernel)
        {
            InitializeLogging();
            kernel.Bind<IHelloService>().To<HelloService>();
            kernel.Bind<ILogger>().ToMethod(CreateContextLogger);
            kernel.Bind<IUserDatabaseService>().To<UserDatabaseService>();
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
            kernel.Bind<IDatabaseContextFactory>().To<DatabaseContextFactory>();
            kernel.Bind<ILogFactory>().To<SerilogFactory>();
            kernel.Bind<ILog>().To<SeriLogAdapter>();
        }

        private ILogger CreateContextLogger(IContext context)
        {
            var requestingType = context.Request?.ParentRequest?.ParentRequest?.Target?.Member?.DeclaringType;
            return requestingType == null ? Log.Logger : Log.Logger.ForContext(requestingType);
        }

        private void InitializeLogging()
        {
            Log.Logger =  new LoggerConfiguration().MinimumLevel.Debug().WriteTo.ColoredConsole().CreateLogger();
        }
    }
}
