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
        private ILogger _logger;

        public HelloService(ILogger logger)
        {
            _logger = logger;
        }

        public object Any(Hello request)
        {
            _logger.Debug($"Sending response");
            return new HelloResponse { Result = "Hello, " + request.Name };
        }
    }

    public interface IHelloService
    {
        object Any(Hello request);
    }
}
