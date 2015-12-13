using JetBrains.Annotations;

namespace HomeControl.Migrations
{
    using System.Data.Entity.Migrations;

    [UsedImplicitly]
    internal sealed class Configuration : DbMigrationsConfiguration<Data.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }
    }
}
