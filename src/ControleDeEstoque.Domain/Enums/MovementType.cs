using System.ComponentModel;

namespace InventoryManagement.Domain.Enums
{
    public enum MovementType
    {
        [Description("Outbound")]
        Outbound = 0,

        [Description("Inbound")]
        Inbound = 1
    }
}
