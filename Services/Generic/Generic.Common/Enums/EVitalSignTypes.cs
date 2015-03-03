using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Enums
{
    public enum EVitalSignTypes
    {
        [Description("AUDIOMETRY")]
        AUDIOMETRY,
        [Description("BLOOD PRESSURE")]
        BLOOD_PRESSURE_Systolic,
        [Description("BLOOD PRESSURE")]
        BLOOD_PRESSURE_Diastolic,
        [Description("CENTRAL VENOUS PRESSURE")]
        CENTRAL_VENOUS_PRESSURE,
        [Description("CIRCUMFERENCE/GIRTH")]
        CIRCUMFERENCE_GIRTH,
        [Description("FETAL HEART TONES")]
        FETAL_HEART_TONES,
        [Description("FUNDAL HEIGHT")]
        FUNDAL_HEIGHT,
        [Description("HEARING")]
        HEARING,
        [Description("HEIGHT")]
        HEIGHT,
        [Description("PAIN")]
        PAIN,
        [Description("PULSE")]
        PULSE,
        [Description("PULSE OXIMETRY")]
        PULSE_OXIMETRY,
        [Description("RESPIRATION")]
        RESPIRATION,
        [Description("TEMPERATURE")]
        TEMPERATURE,
        [Description("TONOMETRY")]
        TONOMETRY,
        [Description("VISION CORRECTED")]
        VISION_CORRECTED,
        [Description("VISION UNCORRECTED")]
        VISION_UNCORRECTED,
        [Description("WEIGHT")]
        WEIGHT
    }
}
