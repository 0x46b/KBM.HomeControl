﻿using System;
using System.Threading.Tasks;
using HomeControl.DatabaseServices;
using HomeControl.Services.Interfaces;
using HomeControl.Services.Requests;
using HomeControl.Services.Responses;
using Ninject.Extensions.Logging;
using ServiceStack;

namespace HomeControl.Services
{
    public class UserService : Service, IUserService
    {
        private readonly IUserDatabaseService _userDatabaseService;
        private readonly ILogger _logger;

        public UserService(ILoggerFactory loggerFactory, IUserDatabaseService userDatabaseService)
        {
            _logger = loggerFactory.GetCurrentClassLogger();
            _userDatabaseService = userDatabaseService;
        }

        public object Get(Hello request)
        {
            var result = $"Hello, {request.Name}, nice to meet you! :D";
            _logger.Debug($"Sending response: {result}");
            return new HelloResponse { Result = result };
        }

        public async Task<AddUserResponse> Post(AddUser request)
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
}
