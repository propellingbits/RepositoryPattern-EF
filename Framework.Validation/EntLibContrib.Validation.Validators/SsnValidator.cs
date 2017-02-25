using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Framework.Validation.Ssn;


[module: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "namespace", Target = "EntLibContrib.Validation.Validators", MessageId = "Ent")]
[module: SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Scope = "namespace", Target = "PA.DPW.CustomValidators.SSNValidation", MessageId = "SSN")]
namespace Framework.Validation.Validators
{

    /// <summary>
    /// Enterprise Library Validation Block SSN validator.
    /// </summary>
    [ConfigurationElementType(typeof(CustomValidatorData))]
    public sealed class SsnValidator : Validator<String>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SsnValidator"/> class.
        /// </summary>
        public SsnValidator() : base(null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SsnValidator"/> class.
        /// </summary>
        /// <param name="messageTemplate">The message template.</param>
        public SsnValidator(string messageTemplate) : base(messageTemplate, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SsnValidator"/> class.
        /// </summary>
        /// <param name="messageTemplate">The template to use when logging validation results, or <see langword="null"/> we the
        /// default message template is to be used.</param>
        /// <param name="tag">The tag to set when logging validation results, or <see langword="null"/>.</param>
        public SsnValidator(string messageTemplate, string tag) : base(messageTemplate, tag) { }

        /// <summary>
        /// Implements the validation logic for the receiver.
        /// </summary>
        /// <remarks>Subclasses must provide a concrete implementation the validation logic.
        /// </remarks>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The object on the behalf of which the validation is
        /// performed.</param>
        /// <param name="key">The key that identifies the source of <paramref
        /// name="objectToValidate"/>.</param>
        /// <param name="validationResults">The validation results to which the outcome of
        /// the validation should be stored.</param>
        protected override void DoValidate(String objectToValidate,
                                           object currentTarget,
                                           string key,
                                           ValidationResults validationResults)
        {
            if (String.IsNullOrEmpty(objectToValidate)) return;

            try
            {
                SsnValidationLogic.Validate(objectToValidate);
            }
            catch (InvalidSsnException ex)
            {
                var messageBuilder = new StringBuilder();
                foreach (DictionaryEntry entry in ex.Data)
                {
                    messageBuilder.AppendLine(String.Format(CultureInfo.InvariantCulture, MessageTemplate, objectToValidate, entry.Value.ToString()));
                }
                LogValidationResult(validationResults, messageBuilder.ToString(), currentTarget, key);
            }
        }

        /// <summary>
        /// Gets the message template to use when logging results no message is supplied.
        /// </summary>
        protected override string DefaultMessageTemplate
        {
            get { return "'{0}': {1}"; }
        }

        /// <summary>
        /// Gets the message representing a failed validation.
        /// </summary>
        /// <param name="objectToValidate">The object for which validation was performed.</param>
        /// <param name="key">The key representing the value being validated for <paramref name="objectToValidate"/>.</param>
        /// <returns>
        /// The message representing the validation failure.
        /// </returns>
        /// <remarks>The default validation maessage formatting provides the object to validate, the key and the tag.<para/>
        /// Subclasses may provide additional formatting parameters.
        /// </remarks>
        protected override string GetMessage(object objectToValidate, string key)
        {
            return base.GetMessage(objectToValidate, key);
        }

    }

    /// <summary>
    /// Validates the provided string is a valid Social Security Number.  Note that the message template is always ignored.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = true, Inherited = false)]
    public sealed class SsnValidatorAttribute : ValueValidatorAttribute
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
            // user message templates have to be ignored because multiple error messages may be 
            return new SsnValidator(null, Tag);
        }

    }
}