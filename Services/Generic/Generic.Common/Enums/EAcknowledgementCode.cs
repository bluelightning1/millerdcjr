using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Enums
{
    /// <summary>
    /// The value AA indicates that the recipient application has accepted and processed the message. 
    /// The value AR indicates that the recipient application has rejected the message. 
    /// The value AE indicates that the recipient application has found an error in the message.
    /// If the message is a negative acknowledgement, the reason for the negative acknowledgement is (optionally) 
    /// in the MSH-6 field (Error Condition); the MSH-6 field use has been deprecated.
    /// The reasons for rejection are discussed in section 3.12.4. The ERR data segment contains further clarification of a negative acknowledgement. 
    /// The reason for rejection should be specified in the ERR segment.
    /// </summary>
    public enum EAcknowledgementCode
    {
        [Description("AU")]
        Unknown,
        [Description("AA")]
        Accepted,
        [Description("AR")]
        Rejected,
        [Description("AE")]
        Error,
        [Description("ER")]
        ErrorRejectConditions,
        [Description("CA")]
        CommitAccepted,
        [Description("CR")]
        CommitRejected,
        [Description("CE")]
        CommitError,
        [Description("NE")]
        Never,
        [Description("AL")]
        All,
        [Description("PR")]
        PartialRejection
    }
}
