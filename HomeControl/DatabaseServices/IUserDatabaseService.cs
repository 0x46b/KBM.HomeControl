using System.Threading.Tasks;
using HomeControl.Data;
using HomeControl.Data.Entities;

namespace HomeControl.DatabaseServices
{
    public interface IUserDatabaseService
    {
        Task<int> AddUserAsync(User user);

        Task<int> AddUserAsync(string forename, string surname, byte[] rfidId);

        Task RemoveUserAsync(int userId);

        Task<int> UpdateUserAsync(User user);

        Task<int> AddPermissionAsync(int userId, ServerPermissions permission);
    }
}