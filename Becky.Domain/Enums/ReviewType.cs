using System.ComponentModel;

namespace Becky.Domain.Enums
{
    public enum ReviewType
    {
        [Description("Fair")]
        Fair = 1,

        [Description("Good")]
        Good = 2,

        [Description("Not Good")]
        NotGood = 3
    }
}