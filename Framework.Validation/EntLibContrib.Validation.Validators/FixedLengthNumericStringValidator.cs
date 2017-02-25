using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Framework.Validation.Validators
{

    /// <summary>
    /// This validator checks that a string is of a specified length and that it is a numeric value.
    /// </summary>
    [ConfigurationElementType(typeof(CustomValidatorData))]
    public class FixedLengthNumericStringValidator : AndCompositeValidator
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedLengthNumericStringValidator" /> class.
        /// </summary>
        /// <param name="length">The length.</param>
        public FixedLengthNumericStringValidator(byte length)
            : base(new IgnoreNullTypeConversionValidator(typeof(Int32), "TODO Non-numeric message"), new IgnoreNullStringLengthValidator(length, RangeBoundaryType.Inclusive, length, RangeBoundaryType.Inclusive, "TODO ValidationMessageTemplate.Range.ExactLength"))
        {
        }

    }

    /// <summary>
    /// This validator checks that a string is of a specified length and that it is a numeric value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
    public sealed class FixedLengthNumericStringValidatorAttribute : ValueValidatorAttribute
    {


        private byte _length;
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedLengthNumericStringValidatorAttribute" /> class.
        /// </summary>
        /// <param name="length">The length.</param>
        public FixedLengthNumericStringValidatorAttribute(byte length)
        {
            if (length < 0)
                throw new ArgumentException("The length must be a positive byte.", "length");
            _length = length;
        }

        /// <summary>
        /// Creates the <see cref="T:Microsoft.Practices.EnterpriseLibrary.Validation.Validator"/> described by the attribute object providing validator specific
        /// information.
        /// </summary>
        /// <param name="targetType">The type of object that will be validated by the validator.</param>
        /// <returns>
        /// The created <see cref="T:Microsoft.Practices.EnterpriseLibrary.Validation.Validator"/>.
        /// </returns>
        /// <remarks>This operation must be overriden by subclasses.</remarks>
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new FixedLengthNumericStringValidator(Length);
        }

        /// <summary>
        /// The length that the numeric string should be checked against.
        /// </summary>
        /// <value>The length.</value>
        public byte Length
        {
            get { return _length; }
        }

    }

}
