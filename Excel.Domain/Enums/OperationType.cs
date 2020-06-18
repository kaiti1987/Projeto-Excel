using System.ComponentModel;

namespace Excel.Domain.Enums
{
    public enum OperationType
    {
        [Description("C")]
        Buy = 1,

        [Description("V")]
        Sell = 2        
    }
}
