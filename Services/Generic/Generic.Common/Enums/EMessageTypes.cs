using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Enums
{
    public enum EMessageTypes
    {
        Unknown,
        /// <summary>
        /// 
        /// </summary>
        [Description("ACK")]
        ACK,
        /// <summary>
        /// 
        /// </summary>
        [Description("ACK_Q22")]
        ACK_Q22,
        /// <summary>
        /// Inactivation
        /// </summary>
        [Description("ADT_A03")]
        ADT_A03,
        /// <summary>
        /// Main Sign Up Activation type
        /// </summary>
        [Description("ADT_A04")]
        ADT_A04,
        /// <summary>
        /// Update Patient Information
        /// </summary>
        [Description("ADT_A08")]
        ADT_A08,
        /// <summary>
        /// Link Patient Information
        /// </summary>
        [Description("ADT_A24")]
        ADT_A24,
        /// <summary>
        ///  update
        /// </summary>
        [Description("ADT_A31")]
        ADT_A31,
        /// <summary>
        /// Move Patient Information – Patient Identifier List
        /// </summary>
        [Description("ADT_A43")]
        ADT_A43,
        /// <summary>
        /// Progress note
        /// </summary>
        [Description("MDM_T02")]
        MDM_T02,
        /// Medical order - no specified format just yet.
        [Description("ORM_O01")]
        ORM_O01,
        /// <summary>
        /// Part of Sign Up Activation type
        /// </summary>
        [Description("QBP_Q22")]
        QBP_Q22,
        /// <summary>
        /// Part of Sign Up Activation type
        /// </summary>
        [Description("RSP_K22")]
        RSP_K22,
        /// <summary>
        /// Part of Sign Up Activation type
        /// </summary>
        [Description("ORU_R01")]
        ORU_R01
    }
}
