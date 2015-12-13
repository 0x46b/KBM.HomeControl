using JetBrains.Annotations;
using ServiceStack;

namespace HomeControl.Services.Requests
{
    [Route("/hello/{Name}")]
    [UsedImplicitly]
    public class Hello
    {
        [UsedImplicitly]
        public string Name { get; set; }
    }
}