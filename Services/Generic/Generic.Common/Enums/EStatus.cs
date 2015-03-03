using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Enums
{
    [Serializable]
    public enum EStatus
    {
        [Description("Y")]
        Active,
        [Description("N")]
        Discharge,
        [Description("R")]
        Rejected,
        [Description("P")]
        Pending
    }
}
