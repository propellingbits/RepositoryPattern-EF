using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Framework.Validation.Validators
{

    /// <summary>
    /// A StringLengthValidator that ignores null or empty values.
    /// </summary>
    public class IgnoreNullStringLengthValidator : StringLengthValidator
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidator" /> class.
        /// </summary>
        /// <param name="upperBound">The upper bound.</param>
        public IgnoreNullStringLengthValidator(int upperBound)
            : base(upperBound)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidator" /> class.
        /// </summary>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullStringLengthValidator(int upperBound, bool negated)
            : base(upperBound, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public IgnoreNullStringLengthValidator(int lowerBound, int upperBound)
            : base(lowerBound, upperBound)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullStringLengthValidator(int lowerBound, int upperBound, bool negated)
            : base(lowerBound, upperBound, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        public IgnoreNullStringLengthValidator(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType)
            : base(lowerBound, lowerBoundType, upperBound, upperBoundType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullStringLengthValidator(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType, bool negated)
            : base(lowerBound, lowerBoundType, upperBound, upperBoundType, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        /// <param name="messageTemplate">The message template.</param>
        public IgnoreNullStringLengthValidator(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType, string messageTemplate)
            : base(lowerBound, lowerBoundType, upperBound, upperBoundType, messageTemplate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullStringLengthValidator(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType, string messageTemplate, bool negated)
            : base(lowerBound, lowerBoundType, upperBound, upperBoundType, messageTemplate, negated)
        {
        }

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


    /// <summary>
    /// A StringLengthValidator that ignores null or empty values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
    public sealed class IgnoreNullStringLengthValidatorAttribute : ValueValidatorAttribute
    {

        private int _lowerBound;
        private RangeBoundaryType _lowerBoundType;
        private int _upperBound;

        private RangeBoundaryType _upperBoundType;

        /// <summary>
        /// Gets the lower bound.
        /// </summary>
        /// <value>The lower bound.</value>
        public int LowerBound
        {
            get { return _lowerBound; }
        }

        /// <summary>
        /// Gets the type of the lower bound.
        /// </summary>
        /// <value>The type of the lower bound.</value>
        public RangeBoundaryType LowerBoundType
        {
            get { return _lowerBoundType; }
        }

        /// <summary>
        /// Gets the upper bound.
        /// </summary>
        /// <value>The upper bound.</value>
        public int UpperBound
        {
            get { return _upperBound; }
        }

        /// <summary>
        /// Gets the type of the upper bound.
        /// </summary>
        /// <value>The type of the upper bound.</value>
        public RangeBoundaryType UpperBoundType
        {
            get { return _upperBoundType; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidatorAttribute" /> class.
        /// </summary>
        /// <param name="upperBound">The upper bound.</param>
        public IgnoreNullStringLengthValidatorAttribute(int upperBound)
            : this(0, RangeBoundaryType.Ignore, upperBound, RangeBoundaryType.Inclusive)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidatorAttribute" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public IgnoreNullStringLengthValidatorAttribute(int lowerBound, int upperBound)
            : this(lowerBound, RangeBoundaryType.Inclusive, upperBound, RangeBoundaryType.Inclusive)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullStringLengthValidatorAttribute" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        public IgnoreNullStringLengthValidatorAttribute(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType)
        {
            this._lowerBound = lowerBound;
            this._lowerBoundType = lowerBoundType;
            this._upperBound = upperBound;
            this._upperBoundType = upperBoundType;
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
        protected override Microsoft.Practices.EnterpriseLibrary.Validation.Validator DoCreateValidator(System.Type targetType)
        {
            return new IgnoreNullStringLengthValidator(this.LowerBound, this.LowerBoundType, this.UpperBound, this.UpperBoundType, base.Negated);
        }

    }

}
