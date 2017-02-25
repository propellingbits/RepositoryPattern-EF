using System;
using System.Globalization;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;


namespace Framework.Validation.Validators
{

    /// <summary>
    /// 
    /// </summary>
    [ConfigurationElementType(typeof(CustomValidatorData))]
    public class CityIllegalCharactersValidator : Validator<string>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CityIllegalCharactersValidator"/> class.
        /// </summary>
        public CityIllegalCharactersValidator()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CityIllegalCharactersValidator"/> class.
        /// </summary>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="tag">The tag.</param>
        public CityIllegalCharactersValidator(string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CityIllegalCharactersValidator" /> class.
        /// </summary>
        /// <param name="messageTemplate">The message template.</param>
        public CityIllegalCharactersValidator(string messageTemplate)
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
        protected override void DoValidate(string objectToValidate, object currentTarget, string key, Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResults validationResults)
        {
            if (string.IsNullOrEmpty(objectToValidate))
                return;

            if ((validateCityName(objectToValidate) == false))
            {
                var message = string.Format(CultureInfo.InvariantCulture, this.MessageTemplate, objectToValidate);
                LogValidationResult(validationResults, message, currentTarget, key);
            }
        }

        private static bool validateCityName(string Value)
        {
            bool valid = true;


            valid = System.Text.RegularExpressions.Regex.IsMatch(Value, "^[^<>`~!/@\\#}$%:;.,?)(_^{&*=|'+]+$") ? true : false;

            if (valid == true)
            {
                //' Consecutive Spaces
                if (Value.IndexOf("  ", StringComparison.Ordinal) >= 0)
                {
                    valid = false;

                }
                else if (Value.StartsWith(" ", StringComparison.Ordinal) | Value.EndsWith(" ", StringComparison.Ordinal))
                {
                    valid = false;
                }
                else
                {
                    valid = true;
                }

            }
            if (valid == true)
            {
                if (Value.IndexOf('-') >= 0)
                {
                    valid = false;

                }
            }

            return valid;

        }


    }
    /// <summary>
    /// This validator checks that a string value does not contain 
    /// illegal characters for the CityNames.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
    public sealed class CityIllegalCharactersValidatorAttribute : ValueValidatorAttribute
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
            return new CityIllegalCharactersValidator(base.MessageTemplate, base.Tag);
        }

    }
}