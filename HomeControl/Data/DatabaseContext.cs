using HomeControl.Data.Entities;

namespace HomeControl.Data
{
    using System.Data.Entity;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Permission> Permissions { get; set; }
    }

}
