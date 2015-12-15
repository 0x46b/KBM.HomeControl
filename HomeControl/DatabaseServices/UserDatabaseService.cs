using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HomeControl.Data;
using HomeControl.Data.Interfaces;
using Ninject.Extensions.Logging;

namespace HomeControl.DatabaseServices
{
    class UserDatabaseService : IUserDatabaseService
    {
        private readonly IDatabaseContextFactory _databaseContextFactory;
        private readonly ILogger _logger;

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
                _logger.Info($"Added user with id {newUser.Id}");
                return newUser.Id;
            }
        }

        public async Task<int> AddUserAsync(string forename, string surname, byte[] RFIDId)
        {
            var userToAdd = new User
            {
                Forename = forename,
                Surname = surname,
                RFIDId = RFIDId
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
                _logger.Info($"Removed user with id {savedUser.Id}");
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
    }
}
