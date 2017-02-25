using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Framework.Validation.Validators
{
    /// <summary>
    /// A TypeConversionValidator that ignores null values.
    /// </summary>
    public class IgnoreNullTypeConversionValidator : TypeConversionValidator
    {

        #region "Constructors"

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullTypeConversionValidator" /> class.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        public IgnoreNullTypeConversionValidator(Type targetType)
            : base(targetType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullTypeConversionValidator" /> class.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullTypeConversionValidator(Type targetType, bool negated)
            : base(targetType, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullTypeConversionValidator" /> class.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="messageTemplate">The message template.</param>
        public IgnoreNullTypeConversionValidator(Type targetType, string messageTemplate)
            : base(targetType, messageTemplate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullTypeConversionValidator" /> class.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullTypeConversionValidator(Type targetType, string messageTemplate, bool negated)
            : base(targetType, messageTemplate, negated)
        {
        }

        #endregion


        /// <summary>
        /// Validates by comparing the length for <paramref name="objectToValidate" /> with the constraints
        /// specified for the validator.
        /// </summary>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The object on the behalf of which the validation is performed.</param>
        /// <param name="key">The key that identifies the source of <paramref name="objectToValidate" />.</param>
        /// <param name="validationResults">The validation results to which the outcome of the validation should be stored.</param>
        /// <remarks>
        /// <see langword="null" /> is considered a failed validation.
        /// </remarks>
        protected override void DoValidate(string objectToValidate, object currentTarget, string key, Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResults validationResults)
        {
            if (string.IsNullOrEmpty(objectToValidate))
                return;

            base.DoValidate(objectToValidate, currentTarget, key, validationResults);
        }


    }
}