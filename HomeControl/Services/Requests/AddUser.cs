using HomeControl.Services.Responses;
using JetBrains.Annotations;
using ServiceStack;

namespace HomeControl.Services.Requests
{
    [Route("/user/add/")]
    [UsedImplicitly]
    public class AddUser : IReturn<AddUserResponse>
    {
        [UsedImplicitly]
        public string Forename { get; set; }
        [UsedImplicitly]
        public string Surname { get; set; }
        [UsedImplicitly]
        public string RFIDId { get; set; }
    }
}