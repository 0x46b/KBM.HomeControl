using HomeControl.Data.Interfaces;

namespace HomeControl.Data
{
    class DatabaseContextFactory : IDatabaseContextFactory
    {
        public DatabaseContext GetContext()
        {
            return new DatabaseContext();
        }
    }
}
