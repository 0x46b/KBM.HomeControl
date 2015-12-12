namespace HomeControl.Data.Interfaces
{
    public interface IDatabaseContextFactory
    {
        DatabaseContext GetContext();
    }
}
