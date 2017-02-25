using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Diagnostics.CodeAnalysis;


namespace Framework.Validation.Validators
{

    /// <summary>
    /// This validator checks that a numeric string value contains the correct check digit as computed by the Luhn algorithm 
    /// with a constant of 0.
    /// </summary>
    /// <remarks>
    /// See https://www.impactsiis.org/help/defaults-npi.htm for the specification.
    /// </remarks>
    [ConfigurationElementType(typeof(CustomValidatorData))]
    public class CreditCardNumberChecksumValidator : Validator<string>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardNumberChecksumValidator" /> class.
        /// </summary>
        public CreditCardNumberChecksumValidator()
            : base(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardNumberChecksumValidator" /> class.
        /// </summary>
        /// <param name="messageTemplate">The message template.</param>
        public CreditCardNumberChecksumValidator(string messageTemplate)
            : base(messageTemplate, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardNumberChecksumValidator" /> class.
        /// </summary>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="tag">The tag.</param>
        public CreditCardNumberChecksumValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        /// <summary>
        /// Gets the message template to use when logging results no message is supplied.
        /// </summary>
        /// <value></value>
        protected override string DefaultMessageTemplate
        {
            get { return "NPI number '{0}' does not have valid check digit."; }
        }

        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The current target.</param>
        /// <param name="key">The key.</param>
        /// <param name="validationResults">The validation results.</param>
        protected override void DoValidate(string objectToValidate, object currentTarget, string key, Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResults validationResults)
        {
            if (string.IsNullOrEmpty(objectToValidate))
                return;

            if (!CheckDigitIsValid(objectToValidate))
            {
                var message = string.Format(CultureInfo.InvariantCulture, MessageTemplate, objectToValidate);
                LogValidationResult(validationResults, message, currentTarget, key);
            }

        }

        /// <summary>
        /// The formula verifies a number against its included check digit, which is 
        /// usually appended to a partial account number to generate the full account number.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>
        /// <list type="number">
        /// <item>
        /// <term>Step 1</term>
        /// <description>Counting from the check digit, which is the rightmost, and moving left, double the value of every second digit.</description>
        /// </item>
        /// <item>
        /// <term>Step 2</term>
        /// <description>Sum the digits of the products together with the undoubled digits from the original number.</description>
        /// </item>
        /// <item>
        /// <term>Step 3</term>
        /// <description>If the total ends in 0 (put another way, if the total modulo 10 is equal to 0), then the number is valid according to the Luhn formula; else it is not valid.</description>
        /// </item>
        /// </list>
        /// </remarks>
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int32.Parse(System.String)", Justification = "False positive.")]
        private static bool CheckDigitIsValid(string value)
		{
			var oddIndexedElements = value.Reverse().Where((character, index) => index % 2 == 1);
			var oddIndexedElementDoubled = from digit in oddIndexedElements
                                           select (int.Parse(digit.ToString(CultureInfo.InvariantCulture)) * 2).ToString(CultureInfo.InvariantCulture);

			List<char> summedDoubledDigits = new List<char>();
			foreach (var doubledDigit in oddIndexedElementDoubled) 
            {
				var sum = doubledDigit.AsEnumerable().Sum(x => Int32.Parse(x.ToString(), CultureInfo.InvariantCulture));
				summedDoubledDigits.Add(char.Parse(sum.ToString(CultureInfo.InvariantCulture)));
			}

			var evenIndexedElements = value.Reverse().Where((character, index) => index % 2 == 0);
			var finalSequence = evenIndexedElements.Concat(summedDoubledDigits);

			const int ChecksumConstant = 0;
			var finalSum = finalSequence.Sum(x => Int32.Parse(x.ToString(), CultureInfo.InvariantCulture)) + ChecksumConstant;

			return (finalSum % 10 == 0);

		}

    }

    /// <summary>
    /// This validator checks that a numeric string value contains the correct check digit as computed by the Luhn algorithm 
    /// with an added constant of 24.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
    public sealed class NpiChecksumValidatorAttribute : ValueValidatorAttribute
    {
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
            return new CreditCardNumberChecksumValidator(MessageTemplate, Tag);
        }
    }

}
