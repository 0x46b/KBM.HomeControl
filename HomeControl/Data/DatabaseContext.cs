using JetBrains.Annotations;

namespace HomeControl.Data
{
    using System.Data.Entity;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
        }

        [UsedImplicitly]
        public DbSet<User> Users { get; set; }
    }

}
