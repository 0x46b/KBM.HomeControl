using System.Threading.Tasks;
using HomeControl.Data.Interfaces;
using HomeControl.Services.Responses;
using JetBrains.Annotations;
using Serilog;
using ServiceStack;

namespace HomeControl.Services
{
    public class HelloService : Service, IHelloService
    {
        private readonly IDatabaseContextFactory _dbContextFactory;
        private readonly ILogger _logger;

        public HelloService(ILogger logger, IDatabaseContextFactory dbContextFactory)
        {
            _logger = logger;
            _dbContextFactory = dbContextFactory;
        }

        public object Any(Hello request)
        {
            _logger.Debug("Sending response");
            return new HelloResponse { Result = "Hello, " + request.Name };
        }

        public async Task<AddHelloResponse> Get(AddHelloRequest request)
        {
            using(var context = _dbContextFactory.GetContext())
            {
                var newUser = context.Users.Create();
                newUser.Forename = request.Forename;
                newUser.Surname = request.Surname;
                context.Users.Add(newUser);
                await context.SaveChangesAsync();
                return new AddHelloResponse(newUser.Id);
            }
            
        }
    }

    public interface IHelloService
    {
        [UsedImplicitly]
        object Any(Hello request);
    }
}
