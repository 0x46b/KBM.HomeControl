using JetBrains.Annotations;
using ServiceStack;

namespace HomeControl.Services
{
    [Route("/hello/{Name}")]
    [UsedImplicitly]
    public class Hello
    {
        [UsedImplicitly]
        public string Name { get; set; }
    }
}