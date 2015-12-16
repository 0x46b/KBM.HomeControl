using HomeControl.Data.Interfaces;
using ServiceStack.DataAnnotations;

namespace HomeControl.Data.Entities
{
    public class DatabaseEntity : IDatabaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
    }
}