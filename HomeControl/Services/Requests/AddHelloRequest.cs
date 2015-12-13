using JetBrains.Annotations;
using ServiceStack;

namespace HomeControl.Services.Requests
{
    [Route("/hello/add/{Forename}/{Surname}/{RFIDId}")]
    [UsedImplicitly]
    public class AddHelloRequest
    {
        [UsedImplicitly]
        public string Forename { get; set; }
        [UsedImplicitly]
        public string Surname { get; set; }
        [UsedImplicitly]
        public string RFIDId { get; set; }
    }
}