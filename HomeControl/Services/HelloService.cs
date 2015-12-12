using HomeControl.Data.Interfaces;
using Serilog;
using ServiceStack;

namespace HomeControl.Services
{
    [Route("/hello/{Name}")]
    public class Hello
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }

    public class HelloService : Service, IHelloService
    {
        private IDatabaseContextFactory _dbContextFactory;
        private ILogger _logger;

        public HelloService(ILogger logger, IDatabaseContextFactory dbContextFactory)
        {
            _logger = logger;
            _dbContextFactory = dbContextFactory;
        }

        public object Any(Hello request)
        {
            _logger.Debug($"Sending response");
            return new HelloResponse { Result = "Hello, " + request.Name };
        }

        public object Get(AddHelloRequest request)
        {
            using(var context = _dbContextFactory.GetContext())
            {
                var newUser = context.Users.Create();
                newUser.Forename = request.Forename;
                newUser.Surname = request.Surname;
                context.Users.Add(newUser);
                context.SaveChanges();
                return new AddHelloResponse(newUser);
            }
            
        }
    }

    public interface IHelloService
    {
        object Any(Hello request);
    }
}
