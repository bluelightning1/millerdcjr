using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Enums
{
    public enum EEnteredType
    {
        [EnteredTypeAttribute()]
        Uknown,
        [EnteredTypeAttribute("4500983", "Y", "Device Entered")]
        Device_Entered,
        [EnteredTypeAttribute("4500982", "N", "Self Entered")]
        Self_Entered
    }
}
