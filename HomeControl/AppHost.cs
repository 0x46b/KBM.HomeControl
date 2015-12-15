using HomeControl.Data;
using HomeControl.Data.Interfaces;
using HomeControl.DatabaseServices;
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
          : base("Home-Controller", typeof(UserService).Assembly)
        { }

        public override void Configure(Funq.Container container)
        {
            IKernel kernel = new StandardKernel();
            RegisterServices(kernel);
            container.Adapter = new NinjectIocAdapter(kernel);
            Plugins.Add(new AuthFeature(() => new AuthUserSession(), new IAuthProvider[]
            {
                new BasicAuthProvider(),
                new CredentialsAuthProvider(),  
            }));
            Plugins.Add(new RegistrationFeature());

            container.Register<ICacheClient>(new MemoryCacheClient());
            var userRep = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userRep);
            LogManager.LogFactory = new ConsoleLogFactory(debugEnabled: true);
        }

        private void RegisterServices(IKernel kernel)
        {
            InitializeLogging();
            kernel.Bind<IHelloService>().To<UserService>();
            kernel.Bind<ILogger>().ToMethod(CreateContextLogger);
            kernel.Bind<IUserDatabaseService>().To<UserDatabaseService>();
            kernel.Bind<IDatabaseContextFactory>().To<DatabaseContextFactory>();
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
