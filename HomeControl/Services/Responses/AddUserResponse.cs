using JetBrains.Annotations;

namespace HomeControl.Services.Responses
{
    public class AddUserResponse
    {
        [UsedImplicitly]
        public int Id { get; set; }
        
        public AddUserResponse(int id)
        {
            Id = id;
        }
    }
}