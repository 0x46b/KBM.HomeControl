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
    public class UserService : Service, IHelloService
    {
        private readonly IUserDatabaseService _userDatabaseService;
        private readonly ILogger _logger;

        public UserService(ILogger logger, IUserDatabaseService userDatabaseService)
        {
            _logger = logger;
            _userDatabaseService = userDatabaseService;
        }

        public object Any(Hello request)
        {
            _logger.Debug("Sending response");
            return new HelloResponse { Result = "Hello, " + request.Name };
        }

        public async Task<AddUserResponse> Get(AddUser request)
        {
            var parsedRFIDId = ConvertToByte(request.RFIDId);
            var id = await _userDatabaseService.AddUserAsync(request.Forename, request.Surname, parsedRFIDId);
            return new AddUserResponse(id);
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
