using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Framework.Validation.Validators
{

    /// <summary>
    /// This validator compares the value to be checked with the value of a property, as long as the value to be checked is not null.
    /// </summary>
    public class IgnoreNullPropertyComparisonValidator : PropertyComparisonValidator
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullPropertyComparisonValidator" /> class.
        /// </summary>
        /// <param name="valueAccess">The value access.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        public IgnoreNullPropertyComparisonValidator(ValueAccess valueAccess, ComparisonOperator comparisonOperator)
            : base(valueAccess, comparisonOperator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullPropertyComparisonValidator" /> class.
        /// </summary>
        /// <param name="valueAccess">The value access.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullPropertyComparisonValidator(ValueAccess valueAccess, ComparisonOperator comparisonOperator, bool negated)
            : base(valueAccess, comparisonOperator, negated)
        {
        }

        /// <summary>
        /// Validates by comparing <paramref name="objectToValidate" /> with the result of extracting a value from
        /// <paramref name="currentTarget" /> usign the configured <see cref="P:Microsoft.Practices.EnterpriseLibrary.Validation.Validators.ValueAccessComparisonValidator.ValueAccess" /> using
        /// the configured <see cref="P:Microsoft.Practices.EnterpriseLibrary.Validation.Validators.ValueAccessComparisonValidator.ComparisonOperator" />.
        /// </summary>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The object on the behalf of which the validation is performed.</param>
        /// <param name="key">The key that identifies the source of <paramref name="objectToValidate" />.</param>
        /// <param name="validationResults">The validation results to which the outcome of the validation should be stored.</param>
        public override void DoValidate(object objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            if (objectToValidate == null)
                return;
            base.DoValidate(objectToValidate, currentTarget, key, validationResults);
        }

    }

    /// <summary>
    /// This validator compares the value to be checked with the value of a property, as long as the value to be checked is not null.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments")]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
    public sealed class IgnoreNullPropertyComparisonValidatorAttribute : ValueValidatorAttribute
    {

        private ComparisonOperator comparisonOperator;

        private string propertyToCompare;
        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullPropertyComparisonValidatorAttribute" /> class.
        /// </summary>
        /// <param name="propertyToCompare">The property to compare.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        public IgnoreNullPropertyComparisonValidatorAttribute(string propertyToCompare, ComparisonOperator comparisonOperator)
        {
            if ((propertyToCompare == null))
            {
                throw new ArgumentNullException("propertyToCompare");
            }
            this.propertyToCompare = propertyToCompare;
            this.comparisonOperator = comparisonOperator;
        }

        /// <summary>
        /// Creates the <see cref="T:Microsoft.Practices.EnterpriseLibrary.Validation.Validator" /> described by the attribute object providing validator specific
        /// information.
        /// </summary>
        /// <param name="targetType">The type of object that will be validated by the validator.</param>
        /// <returns>
        /// The created <see cref="T:Microsoft.Practices.EnterpriseLibrary.Validation.Validator" />.
        /// </returns>
        /// <remarks>This operation must be overriden by subclasses.</remarks>
        protected override Validator DoCreateValidator(Type targetType)
        {
            throw new NotImplementedException("Should not be called.");
        }

        /// <summary>
        /// Creates the <see cref="T:Microsoft.Practices.EnterpriseLibrary.Validation.Validator"/> described by the configuration object.
        /// </summary>
        /// <param name="targetType">The type of object that will be validated by the validator.</param>
        /// <param name="ownerType">The type of the object from which the value to validate is extracted.</param>
        /// <param name="memberValueAccessBuilder">The <see cref="T:Microsoft.Practices.EnterpriseLibrary.Validation.MemberValueAccessBuilder"/> to use for validators that
        /// require access to properties.</param>
        /// <param name="validatorFactory">The validator factory.</param>
        /// <returns>
        /// The created <see cref="T:Microsoft.Practices.EnterpriseLibrary.Validation.Validator"/>.
        /// </returns>
        /// <remarks>
        /// The default implementation invokes <see cref="M:Microsoft.Practices.EnterpriseLibrary.Validation.Validators.ValidatorAttribute.DoCreateValidator(System.Type)"/>. Subclasses requiring access to all
        /// the parameters or this method may override it instead of <see cref="M:Microsoft.Practices.EnterpriseLibrary.Validation.Validators.ValidatorAttribute.DoCreateValidator(System.Type)"/>.
        /// </remarks>
        protected override Validator DoCreateValidator(Type targetType, Type ownerType, MemberValueAccessBuilder memberValueAccessBuilder, ValidatorFactory validatorFactory)
        {
            System.Reflection.PropertyInfo propertyInfo = GetProperty(ownerType, this.propertyToCompare, false);
            if ((propertyInfo == null))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Property To Compare Not Found", new object[] {
                        this.propertyToCompare,
                        ownerType.FullName
                    }));
            }
            return new IgnoreNullPropertyComparisonValidator(memberValueAccessBuilder.GetPropertyValueAccess(propertyInfo), this.comparisonOperator, base.Negated);
        }


        private static PropertyInfo GetProperty(Type type, string propertyName, bool throwIfInvalid)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException("propertyName");

            PropertyInfo propertyInfo = type.GetProperty(propertyName, (BindingFlags.Public | BindingFlags.Instance));
            if (IsValidProperty(propertyInfo))
                return propertyInfo;

            if (throwIfInvalid)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid Property", new object[] {
					propertyName,
					type.FullName
				}));
            return null;
        }

        private static bool IsValidProperty(PropertyInfo propertyInfo)
        {
            return ((((propertyInfo != null)) && propertyInfo.CanRead) && (propertyInfo.GetIndexParameters().Length == 0));
        }

    }

}
