using System;
using HomeControl.Data.Interfaces;
using JetBrains.Annotations;
using ServiceStack.DataAnnotations;

namespace HomeControl.Data.Entities
{
    public class Permission : DatabaseEntity
    {
        [UsedImplicitly]
        public User User{ get; set; }

        [UsedImplicitly]
        public ServerPermissions Permissions { get; set; }
    }

    [Flags]
    public enum ServerPermissions
    {
        None = 0x0,
        Read = 0x2,
        Write = 0x4,
    }
}