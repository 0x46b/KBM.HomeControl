using System.Threading.Tasks;
using HomeControl.Data;

namespace HomeControl.DatabaseServices
{
    public interface IUserDatabaseService
    {
        Task<int> AddUserAsync(User user);

        Task<int> AddUserAsync(string forename, string surname, byte[] RFIDId, bool isAuthorized);

        Task RemoveUserAsync(int userId);

        Task<int> UpdateUserAsync(User user);

        Task<bool> IsAuthorized(int userId);
    }
}