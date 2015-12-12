using ServiceStack;

namespace HomeControl.Services
{
    [Route("/hello/add/{Forename}/{Surname}/{RFIDId}")]
    public class AddHelloRequest
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string RFIDid { get; set; }
    }
}