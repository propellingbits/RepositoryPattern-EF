namespace Framework.Validation.Ssn
{
    internal static class SsnValidationResult
    {
        internal const string SsnFormatException = "SSN format is not valid.";
        internal const string SsnAreaNumberException = "The SSN area number '{0:D3}' is not valid.";
        internal const string SsnGroupNumberException = "The SSN group number '{0:D2}' is not valid.";
        internal const string SsnSerialNumberException = "The SSN serial number '{0:D4}' is not valid.";
        internal const string SsnInvalidatedBySsaException = "The Social Security Administration invalidated this SSN.";
    }
}