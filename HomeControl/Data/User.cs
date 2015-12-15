using HomeControl.Data.Interfaces;
using JetBrains.Annotations;

namespace HomeControl.Data
{
    [UsedImplicitly]
    public class User : IDatabaseEntity
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        [UsedImplicitly]
        public byte[] RFIDId { get; set; }

        public bool IsAuthorized { get; set; }
    }
}
