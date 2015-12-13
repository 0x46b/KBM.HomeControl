using System.Threading.Tasks;
using HomeControl.Data;

namespace HomeControl.DatabaseServices
{
    public interface IUserDatabaseService
    {
        Task<int> AddUserAsync(User user);

        Task<int> AddUserAsync(string forename, string surname, byte[] RFIDId);

        Task RemoveUserAsync(int userId);

        Task<int> UpdateUserAsync(User user);
    }
}