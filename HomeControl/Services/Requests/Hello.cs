using HomeControl.Services.Responses;
using JetBrains.Annotations;
using ServiceStack;

namespace HomeControl.Services.Requests
{
    [Route("/hello/{Name}")]
    [UsedImplicitly]
    public class Hello : IReturn<HelloResponse>
    {
        [UsedImplicitly]
        public string Name { get; set; }
    }
}