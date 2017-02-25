using System;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.ComponentModel;
using Framework.Data.ReferenceTables;


namespace Framework.Validation.Validators
{

    /// <summary>
    /// This validator checks that a value is one of the key values of the specified ITASCA reference table.
    /// </summary>
    [ConfigurationElementType(typeof(CustomValidatorData))]
    public class ReferenceTableValueValidator : Validator<string>
    {

        private string _tableName;

        private Nullable<DateTime> _effectiveDate;
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceTableValueValidator" /> class.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        public ReferenceTableValueValidator(string tableName)
            : this(tableName, null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceTableValueValidator" /> class.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="effectiveDate">The effective date.</param>
        public ReferenceTableValueValidator(string tableName, Nullable<DateTime> effectiveDate)
            : this(tableName, effectiveDate, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceTableValueValidator" /> class.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="effectiveDate">The effective date.</param>
        /// <param name="messageTemplate">The message template.</param>
        public ReferenceTableValueValidator(string tableName, Nullable<DateTime> effectiveDate, string messageTemplate)
            : this(tableName, effectiveDate, messageTemplate, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceTableValueValidator" /> class.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="effectiveDate">The effective date.</param>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="tag">The tag.</param>
        public ReferenceTableValueValidator(string tableName, Nullable<DateTime> effectiveDate, string messageTemplate, string tag)
            : base(messageTemplate, tag)
        {

            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException("tableName is nothing or empty.", "tableName");
            }

            _tableName = tableName;
            _effectiveDate = effectiveDate;
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

            var refTableReader = new ReferenceTableReader(_tableName);
            var returnValue = refTableReader.GetDisplayValue(_effectiveDate, objectToValidate);

            if (string.IsNullOrEmpty(returnValue))
            {
                var message = string.Format(CultureInfo.InvariantCulture, this.MessageTemplate, objectToValidate, _tableName);
                LogValidationResult(validationResults, message, currentTarget, key);
            }
        }

        /// <summary>
        /// Gets the default message template.
        /// </summary>
        /// <value>The default message template.</value>
        protected override string DefaultMessageTemplate
        {
            get { return "The key '{0}' does not exist on reference table '{1}'."; }
        }
    }

    /// <summary>
    /// This validator checks that a value is one of the key values of the specified ITASCA reference table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
    public sealed class ReferenceTableValueValidatorAttribute : ValueValidatorAttribute
    {

        private string _tableName;

        private Nullable<DateTime> _effectiveDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceTableValueValidatorAttribute" /> class.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        public ReferenceTableValueValidatorAttribute(string tableName)
        {
            _tableName = tableName;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceTableValueValidatorAttribute" /> class.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="effectiveDate">The effective date.</param>
        public ReferenceTableValueValidatorAttribute(string tableName, Nullable<DateTime> effectiveDate)
        {
            _tableName = tableName;
            _effectiveDate = effectiveDate;
        }

        /// <summary>
        /// Does the create validator.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <returns></returns>
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new ReferenceTableValueValidator(TableName, EffectiveDate, MessageTemplate, Tag);
        }

        /// <summary>
        /// Gets the effective date.
        /// </summary>
        /// <value>The effective date.</value>
        public Nullable<DateTime> EffectiveDate
        {
            get { return _effectiveDate; }
        }

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        public string TableName
        {
            get { return _tableName; }
        }

    }

}
