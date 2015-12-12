using HomeControl.Data.Interfaces;

namespace HomeControl.Data
{
    public class User : IDatabaseEntity
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public byte[] RFIDId { get; set; }
    }
}
