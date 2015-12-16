using System.Threading.Tasks;
using HomeControl.Services.Requests;
using HomeControl.Services.Responses;
using JetBrains.Annotations;

namespace HomeControl.Services.Interfaces
{
    public interface IUserService
    {
        [UsedImplicitly]
        object Get(Hello request);

        Task<AddUserResponse> Post(AddUser request);
    }
}