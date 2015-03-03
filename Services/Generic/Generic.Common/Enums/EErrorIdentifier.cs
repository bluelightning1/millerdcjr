using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Enums
{
    public enum EErrorIdentifier
    {
        MissingICN = 100,
        MissingDFN = 101,
        MissingSSN = 102,
        MissingName = 103,
        MissingDOB = 104,
        MissingPID = 105,
        MissingPD1 = 106,
        MissingPV1 = 107,
        MissingConsult = 108,
        MissingCareCoordinator = 109,
        InvalidICN = 200,
        InvalidDFN = 201,
        invalidSSN = 202,
        InvalidName = 203,
        InvalidDOB = 204,
        InvalidConsultNumber = 208,
        InvalidCareCoordinator = 209,
        DuplicateICN = 300,
        DuplicateDFN = 301,
        DuplicateSSN = 302,
        Rejected = 304,
        InconsistentICN = 305,
        InconsistentSSN = 306,
        InconsistentDFN = 307,
        InconsistentNameOrDOB = 308,
        /// <summary>
        ///  309 Patient active at "facility number"113 
        ///  Sign Up message (activation) or Inactivation for a patient that is already active at another facility.
        /// </summary>
        PatientActiveAtFacility = 309,
        MalformedAddress = 311,
        MalformedTelephoneNumber = 312,
        UnknownFacilityNumber = 313,
        LegacyPatientWithInconsistentNameOrDOB = 314,
        CannotLocatePatientWithICN = 315,
        GeneralError = 400,
        UnsupportedMessageType = 401,
        UnsupportedSegmentType = 402,
        WrongReceivingFacility = 403,
        WrongSendingFacilityOrApplication = 404,
        DuplicateAcceptedMessage = 405,
        UnsupportedMessageTypeEventCombination = 406
    }
}
