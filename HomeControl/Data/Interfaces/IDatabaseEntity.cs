using JetBrains.Annotations;

namespace HomeControl.Data.Interfaces
{
    interface IDatabaseEntity
    {
        [UsedImplicitly]
        int Id { get; set; }
    }
}
