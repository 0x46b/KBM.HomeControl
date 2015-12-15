using JetBrains.Annotations;

namespace HomeControl.Services.Responses
{
    public class AddHelloResponse
    {
        [UsedImplicitly]
        public int Id { get; set; }
        
        public AddHelloResponse(int id)
        {
            Id = id;
        }
    }
}