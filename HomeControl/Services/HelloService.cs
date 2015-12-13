using System;
using System.Threading.Tasks;
using HomeControl.DatabaseServices;
using HomeControl.Services.Requests;
using HomeControl.Services.Responses;
using JetBrains.Annotations;
using Serilog;
using ServiceStack;

namespace HomeControl.Services
{
    public class HelloService : Service, IHelloService
    {
        private readonly IUserDatabaseService _userDatabaseService;
        private readonly ILogger _logger;

        public HelloService(ILogger logger, IUserDatabaseService userDatabaseService)
        {
            _logger = logger;
            _userDatabaseService = userDatabaseService;
            var byteArray = new byte[]
            {
                0xBA,
                0xDB,
                0xAB,
                0xE0,
            };
            var test = Convert.ToBase64String(byteArray);
            _logger.Error(test);
        }

        public object Any(Hello request)
        {
            _logger.Debug("Sending response");
            return new HelloResponse { Result = "Hello, " + request.Name };
        }

        public async Task<AddHelloResponse> Get(AddHelloRequest request)
        {
            var parsedRFIDId = ConvertToByte(request.RFIDId);
            var id = await _userDatabaseService.AddUserAsync(request.Forename, request.Surname, parsedRFIDId);
            return new AddHelloResponse(id);
        }

        private byte[] ConvertToByte(string rfidId)
        {
            return Convert.FromBase64String(rfidId);
        }
    }

    public interface IHelloService
    {
        [UsedImplicitly]
        object Any(Hello request);
    }
}
