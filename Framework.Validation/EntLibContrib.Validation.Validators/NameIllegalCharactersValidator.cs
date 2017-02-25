using System;
using System.Globalization;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Text.RegularExpressions;

namespace Framework.Validation.Validators
{
    /// <summary>
    /// 
    /// </summary>
    [ConfigurationElementType(typeof(CustomValidatorData))]
    public class NameIllegalCharactersValidator : Validator<string>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="NameIllegalCharactersValidator"/> class.
        /// </summary>
        public NameIllegalCharactersValidator()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameIllegalCharactersValidator"/> class.
        /// </summary>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="tag">The tag.</param>
        public NameIllegalCharactersValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameIllegalCharactersValidator" /> class.
        /// </summary>
        /// <param name="messageTemplate">The message template.</param>
        public NameIllegalCharactersValidator(string messageTemplate)
            : base(messageTemplate, null)
        {
        }

        /// <summary>
        /// Gets the message template to use when logging results no message is supplied.
        /// </summary>
        /// <value></value>
        protected override string DefaultMessageTemplate
        {
            get { return " Invalid Character(s) found in '{0}'."; }
        }

        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The current target.</param>
        /// <param name="key">The key.</param>
        /// <param name="validationResults">The validation results.</param>
        protected override void DoValidate(string objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            if (string.IsNullOrEmpty(objectToValidate))
                return;

            if ((isValidName(objectToValidate) == false))
            {
                var message = string.Format(CultureInfo.InvariantCulture, MessageTemplate, objectToValidate);
                LogValidationResult(validationResults, message, currentTarget, key);
            }
        }
        
        private static bool isValidName(string value)
        {
            // Regex tests
            bool valid = Regex.IsMatch(value, "^[^<>`~!@\\#}$%:;.,?)(_^{*=|'+]+$");
            if (!valid) return valid;

            // Consecutive spaces tests and starting or ending with illegal chars
            if (value.IndexOf("  ", StringComparison.Ordinal) >= 0 ||
                value.StartsWith(" ", StringComparison.Ordinal) ||
                value.EndsWith(" ", StringComparison.Ordinal) ||
                value.StartsWith("&", StringComparison.Ordinal) ||
                value.EndsWith("&", StringComparison.Ordinal) ||
                value.StartsWith("/", StringComparison.Ordinal) || 
                value.EndsWith("/", StringComparison.Ordinal) ||
                value.StartsWith("-", StringComparison.Ordinal) ||
                value.EndsWith("-", StringComparison.Ordinal))
            {
                valid = false;
            }
            if (!valid) return valid;

            
            if (value.IndexOf('&') >= 0)
            {
                valid = value.IndexOf(" &", StringComparison.Ordinal) < 0 || value.IndexOf("& ", StringComparison.Ordinal) < 0 
                    ? false : true;
            }

            if (value.IndexOf('/') >= 0)
            {
                valid = value.IndexOf(" /", StringComparison.Ordinal) >= 0 || value.IndexOf("/ ", StringComparison.Ordinal) >= 0 
                    ? false : true;
            }

            if (value.IndexOf('-') >= 0)
            {
                valid = value.IndexOf(" -", StringComparison.Ordinal) >= 0 || value.IndexOf("- ", StringComparison.Ordinal) >= 0 
                    ? false : true;
            }

            return valid;
        }
    }

    /// <summary>
    /// This validator checks that a string value does not contain 
    /// illegal characters for the IRS name, entity name, or individual name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
    public sealed class NameIllegalCharactersValidatorAttribute : ValueValidatorAttribute
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
            return new NameIllegalCharactersValidator(base.MessageTemplate, base.Tag);
        }

    }
}