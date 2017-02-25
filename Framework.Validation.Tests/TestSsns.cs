using System;

namespace Validation.Tests
{
    /// <summary>
    /// Contains a set of test SSNs.
    /// </summary>
    internal static class TestSsn
    {
        internal const string FormatInvalid = "123-DE-ASDF";
        internal const string AreaNumberInvalid = "666-01-1111";       
        internal const string SerialNumberInvalid = "121-01-0000";
        internal const string InvalidatedBySsa = "078-05-1120";

        internal const string InvalidAreaAndSerialNumber = "666-01-0000";
        internal const string InvalidGroupAndSerialNumber = "691-02-0000";  

        internal const string SsnFormatException = "SSN format is not valid.";
        internal const string SsnAreaNumberException = "The SSN area number is not valid.";
        internal const string SsnGroupNumberException = "The SSN group number is not valid.";
        internal const string SsnSerialNumberException = "The SSN serial number is not valid.";
        internal const string SsnInvalidatedBySsaException = "The Social Security Administration invalidated this SSN.";

        internal const string SsnFormatExceptionKey = "SSN:Format";
        internal const string SsnAreaNumberExceptionKey = "SSN:Area Number";
        internal const string SsnGroupNumberExceptionKey = "SSN:Group Number";
        internal const string SsnSerialNumberExceptionKey = "SSN:Serial Number";
        internal const string SsnInvalidatedBySsaExceptionKey = "SSN";


        #region GROUP 1 of 4: Low Odd Group Numbers
        // Low Odd Group Numbers range defined as 01 <= X <= 09
        // This group is assigned FIRST by the SSA (01, 03, ..., 07, 09)
        // IMPORTANT: As of June 2008, the High Group number published by
        // the SSA for area number 699 is 09.  Future changes to the published high number
        // may invalidate the test (in which case it would need to be adjusted).
        internal const string ValidLowOddGroupNumber = "699-01-0001";
        internal const string InvalidLowOddGroupNumber = "699-02-0001";
        #endregion

        #region GROUP 2 of 4: High Even Group Numbers
        // High Even Group Numbers range defined as 10 <= X <= 98
        // This group is assigned SECOND by the SSA (10, 12, ..., 96, 98)
        // IMPORTANT: As of June 2010, the High Group number published by
        // the SSA for area number 050 is 02.  Future changes to the published high number
        // may invalidate the test (in which case it would need to be adjusted).
        internal const string ValidHighEvenGroupNumber = "050-02-0001";
        internal const string InvalidHighEvenGroupNumber = "050-04-0001";
        #endregion

        #region GROUP 3 of 4: Low Even Group Numbers
        // Low Even Group Numbers range defined as 02 <= X <= 08
        // This group is assigned THIRD by the SSA (02, 04, ..., 06, 08)
        // IMPORTANT: As of October 2008, the High Group number published by
        // the SSA for area number 332 is 08.  Future changes to the published high number
        // may invalidate the test (in which case it would need to be adjusted).
        internal const string ValidLowEvenGroupNumber = "332-98-0001";
        internal const string InvalidLowEvenGroupNumber = "332-11-0001";
        #endregion

        #region GROUP 4 of 4: Low Odd Group Numbers
        // High Odd Group Numbers range defined as 11 <= X <= 99
        // This group is assigned FOURTH by the SSA (11, 13, ..., 97, 99)
        // IMPORTANT: As of October 2010, the High Group number published by
        // the SSA for area number 520 is 61.  Future changes to the published high number
        // may invalidate the test (in which case it would need to be adjusted).
        internal const string ValidHighOddGroupNumber = "520-98-0001";
        internal const string InvalidHighOddGroupNumber = "520-69-0001";
        #endregion

        [Obsolete("", false)]
        internal const string GroupNumberInvalid = "691-02-1111";

        [Obsolete("", false)]
        internal const string Valid = "Please provide...";
    }
}
