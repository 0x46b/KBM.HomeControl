using JetBrains.Annotations;

namespace HomeControl.Data.Entities
{
    [UsedImplicitly]
    public class User : DatabaseEntity
    {
        public string Forename { get; set; }

        public string Surname { get; set; }

        [UsedImplicitly]
        public byte[] RFIDId { get; set; }
    }
}
