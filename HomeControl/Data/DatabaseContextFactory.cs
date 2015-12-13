using HomeControl.Data.Interfaces;
using JetBrains.Annotations;

namespace HomeControl.Data
{
    [UsedImplicitly]
    class DatabaseContextFactory : IDatabaseContextFactory
    {
        public DatabaseContext GetContext()
        {
            return new DatabaseContext();
        }
    }
}
