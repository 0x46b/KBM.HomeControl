using Funq;
using HomeControl.Data;
using HomeControl.Data.Interfaces;
using HomeControl.DatabaseServices;
using HomeControl.LoggingAdapter;
using HomeControl.Services;
using Ninject;
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
          : base("HttpListener Self-Host", typeof(UserService).Assembly)
        { }

        public override void Configure(Container container)
        {
            InitializeLogging();

            var kernel = new StandardKernel();
            RegisterServices(kernel);

            container.Adapter = new NinjectIocAdapter(kernel);

            LogManager.LogFactory = container.Resolve<ILogFactory>();

            InitializeAuthorization(container);
        }

        private void InitializeAuthorization(Container container)
        {
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                new IAuthProvider[]
                {
                    new BasicAuthProvider(),
                    new CredentialsAuthProvider(),
                }));

            Plugins.Add(new RegistrationFeature());

            container.Register<ICacheClient>(new MemoryCacheClient());
            var userRep = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userRep);
        }

        private void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IHelloService>().To<UserService>();
            kernel.Bind<IUserDatabaseService>().To<UserDatabaseService>();
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
            kernel.Bind<IDatabaseContextFactory>().To<DatabaseContextFactory>();
            kernel.Bind<ILogFactory>().To<LoggingAdapterFactory>();
            kernel.Bind<ILog>().To<LoggingAdapter.LoggingAdapter>();
        }

        private void InitializeLogging()
        {
            Log.Logger =  new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.ColoredConsole()
                .ReadFrom.AppSettings()
                .CreateLogger();
        }
    }
}
