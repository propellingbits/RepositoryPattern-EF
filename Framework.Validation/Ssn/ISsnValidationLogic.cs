using System;


namespace Framework.Validation.Ssn
{
    /// <summary>
    /// SSN validation logic interface.
    /// </summary>
    public interface ISsnValidationLogic
    {
        /// <summary>
        /// Validates the specified SSN.
        /// </summary>
        /// <param name="ssn">The SSN.</param>
        void Validate(String ssn);
    }
}