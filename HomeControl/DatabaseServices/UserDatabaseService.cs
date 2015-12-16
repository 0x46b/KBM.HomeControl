using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HomeControl.Data.Entities;
using HomeControl.Data.Interfaces;
using JetBrains.Annotations;
using Ninject.Extensions.Logging;

namespace HomeControl.DatabaseServices
{
    [UsedImplicitly]
    class UserDatabaseService : IUserDatabaseService
    {
        private readonly IDatabaseContextFactory _databaseContextFactory;
        private readonly ILogger _logger;
        private const ServerPermissions DefaultPermission = ServerPermissions.Read;
        public UserDatabaseService(IDatabaseContextFactory databaseContextFactory, ILoggerFactory loggerFactory)
        {
            _databaseContextFactory = databaseContextFactory;
            _logger = loggerFactory.GetCurrentClassLogger();
        }

        public async Task<int> AddUserAsync(User user)
        {
            using (var context = _databaseContextFactory.GetContext())
            {
                var newUser = context.Users.Create();
                newUser.Forename = user.Forename;
                newUser.Surname = user.Surname;
                newUser.RFIDId = user.RFIDId;
                context.Users.Add(newUser);

                await context.SaveChangesAsync().ConfigureAwait(false);
                _logger.Info($"Created new user: {newUser.Forename} {newUser.Surname} : {BitConverter.ToString(newUser.RFIDId)}");
                await AddPermissionAsync(newUser.Id, DefaultPermission);
                return newUser.Id;
            }
        }

        public async Task<int> AddUserAsync(string forename, string surname, byte[] rfidId)
        {
            var userToAdd = new User
            {
                Forename = forename,
                Surname = surname,
                RFIDId = rfidId
            };
            return await AddUserAsync(userToAdd).ConfigureAwait(false);
        }

        public async Task RemoveUserAsync(int userId)
        {
            using (var context = _databaseContextFactory.GetContext())
            {
                var savedUser = await context.Users.FirstOrDefaultAsync(user => user.Id == userId);
                if (savedUser == null)
                {
                    return;
                }
                context.Users.Remove(savedUser);
                await context.SaveChangesAsync().ConfigureAwait(false);
                _logger.Info($"Deleted user with id {savedUser.Id}");
            }
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            if (user.Id < 0)
            {
                throw new UserNotFoundException($"User with id {user.Id} not found");
            }
            using (var context = _databaseContextFactory.GetContext())
            {
                var savedUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
                if (savedUser == null)
                {
                    throw new UserNotFoundException($"User with id {user.Id} not found");
                }
                savedUser.Forename = user.Forename;
                savedUser.RFIDId = user.RFIDId;
                savedUser.Surname = user.Surname;

                await context.SaveChangesAsync().ConfigureAwait(false);
                _logger.Info($"Updated user with id {savedUser.Id}");
                return savedUser.Id;
            }
        }

        public async Task<int> AddPermissionAsync(int userId, ServerPermissions permission)
        {
            using (var context = _databaseContextFactory.GetContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    throw new UserNotFoundException($"User with id {userId} not found");
                }

                var newPermission = context.Permissions.Create();
                newPermission.User = user;
                newPermission.Permissions = permission;
                context.Permissions.Add(newPermission);
                await context.SaveChangesAsync().ConfigureAwait(false);
                _logger.Info($"Added permission ({newPermission.Id}) for user with id {user.Id}");
                return newPermission.Id;
            }
        }
    }
}
