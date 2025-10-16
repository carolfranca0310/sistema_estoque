using System.ComponentModel;

namespace InventoryManagement.Domain.Enums
{
    public enum Status
    {
        [Description("Cleared")]
        Cleared = 0,

        [Description("Active")]
        Active = 1,

        [Description("Inactive")]
        Inactive = 2,

        [Description("Expired")]
        Expired = 3
    }
}
