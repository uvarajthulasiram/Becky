using System.ComponentModel;

namespace Becky.Domain.Enums
{
    public enum ActionStatus
    {
        [Description("Successful")]
        Successful,

        [Description("Failed")]
        Failed
    }
}