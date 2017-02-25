using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;


namespace Framework.Validation.Validators
{

    /// <summary>
    /// This validator checks that a <see cref="ICollection" /> contains the specified range of elements.
    /// </summary>
    [ConfigurationElementType(typeof(CollectionCountValidator))]
    public class CollectionCountValidator : ValueValidator<ICollection>
    {

        private RangeValidator<int> _rangeValidator;
        private int _lowerBound;
        private RangeBoundaryType _lowerBoundType;
        private int _upperBound;

        private RangeBoundaryType _upperBoundType;
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="upperBound">The upper bound.</param>
        public CollectionCountValidator(int upperBound)
            : this(0, RangeBoundaryType.Ignore, upperBound, RangeBoundaryType.Inclusive)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public CollectionCountValidator(int upperBound, bool negated)
            : this(0, RangeBoundaryType.Ignore, upperBound, RangeBoundaryType.Inclusive, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public CollectionCountValidator(int lowerBound, int upperBound)
            : this(lowerBound, RangeBoundaryType.Inclusive, upperBound, RangeBoundaryType.Inclusive)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public CollectionCountValidator(int lowerBound, int upperBound, bool negated)
            : this(lowerBound, RangeBoundaryType.Inclusive, upperBound, RangeBoundaryType.Inclusive, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        public CollectionCountValidator(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType)
            : this(lowerBound, lowerBoundType, upperBound, upperBoundType, null, false)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public CollectionCountValidator(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType, bool negated)
            : this(lowerBound, lowerBoundType, upperBound, upperBoundType, null, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        /// <param name="messageTemplate">The message template.</param>
        public CollectionCountValidator(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType, string messageTemplate)
            : this(lowerBound, lowerBoundType, upperBound, upperBoundType, messageTemplate, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>

        public CollectionCountValidator(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType, string messageTemplate, bool negated)
            : base(messageTemplate, null, negated)
        {
            _rangeValidator = new RangeValidator<int>(lowerBound, lowerBoundType, upperBound, upperBoundType, messageTemplate, negated);
            _lowerBound = lowerBound;
            _lowerBoundType = lowerBoundType;
            _upperBound = upperBound;
            _upperBoundType = upperBoundType;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator"/> class.
        /// </summary>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        protected CollectionCountValidator(string messageTemplate, string tag, bool negated)
            : base(messageTemplate, tag, negated)
        {
            
        }
         

        /// <summary>
        /// Gets the Default Message Template when the validator is negated.
        /// </summary>
        /// <value></value>
        protected override string DefaultNegatedMessageTemplate
        {
            get { return "{0} on property {1} should contain fewer than {2} ({3}) or more than {4} ({5}) elements, but it contains {6} elements."; }
        }

        /// <summary>
        /// Gets the Default Message Template when the validator is non negated.
        /// </summary>
        /// <value></value>
        protected override string DefaultNonNegatedMessageTemplate
        {
            get { return "{0} on property {1} should contain between {2} ({3}) and {4} ({5}) elements, but it contains {6} elements."; }
        }

        /// <summary>
        /// Performs the validation.
        /// </summary>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The current target.</param>
        /// <param name="key">The key.</param>
        /// <param name="validationResults">The validation results.</param>

        protected override void DoValidate(System.Collections.ICollection objectToValidate, object currentTarget, string key, Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResults validationResults)
        {
            if (objectToValidate == null)
                LogValidationResult(validationResults, GetMessage(objectToValidate, key), currentTarget, key);

            if (!_rangeValidator.Validate(objectToValidate.Count).IsValid)
            {
                LogValidationResult(validationResults, GetMessage(objectToValidate, key), currentTarget, key);
            }

        }

        /// <summary>
        /// Gets the message representing a failed validation.
        /// </summary>
        /// <param name="objectToValidate">The object for which validation was performed.</param>
        /// <param name="key">The key representing the value being validated for <paramref name="objectToValidate" />.</param>
        /// <returns>
        /// The message representing the validation failure.
        /// </returns>
        /// <remarks>The default validation maessage formatting provides the object to validate, the key and the tag.<para />
        /// Subclasses may provide additional formatting parameters.
        /// </remarks>
        protected override string GetMessage(object objectToValidate, string key)
        {
            ICollection typedObjectToValidate = (ICollection)objectToValidate;
#if DEBUG
			if (string.IsNullOrEmpty(key))
				key = "TestProperty";
#endif
            return string.Format(CultureInfo.InvariantCulture, MessageTemplate, objectToValidate, key, _lowerBound, _lowerBoundType, _upperBound, _upperBoundType, typedObjectToValidate.Count.ToString(CultureInfo.InvariantCulture));
        }

    }

    /// <summary>
    /// This validator checks that a <see cref="ICollection" /> contains the specified range of elements.
    /// </summary>
    /// 
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments")]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
    public sealed class CollectionCountValidatorAttribute : ValueValidatorAttribute
    {

        private int _lowerBound;
        private RangeBoundaryType _lowerBoundType;
        private int _upperBound;

        private RangeBoundaryType _upperBoundType;
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="upperBound">The upper bound.</param>
        public CollectionCountValidatorAttribute(int upperBound)
            : this(0, RangeBoundaryType.Ignore, upperBound, RangeBoundaryType.Inclusive)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public CollectionCountValidatorAttribute(int upperBound, bool negated)
            : this(0, RangeBoundaryType.Ignore, upperBound, RangeBoundaryType.Inclusive, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidatorAttribute" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public CollectionCountValidatorAttribute(int lowerBound, int upperBound)
            : this(lowerBound, RangeBoundaryType.Inclusive, upperBound, RangeBoundaryType.Inclusive)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public CollectionCountValidatorAttribute(int lowerBound, int upperBound, bool negated)
            : this(lowerBound, RangeBoundaryType.Inclusive, upperBound, RangeBoundaryType.Inclusive, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        public CollectionCountValidatorAttribute(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType)
            : this(lowerBound, lowerBoundType, upperBound, upperBoundType, null, false)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public CollectionCountValidatorAttribute(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType, bool negated)
            : this(lowerBound, lowerBoundType, upperBound, upperBoundType, null, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        /// <param name="messageTemplate">The message template.</param>
        public CollectionCountValidatorAttribute(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType, string messageTemplate)
            : this(lowerBound, lowerBoundType, upperBound, upperBoundType, messageTemplate, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionCountValidator" /> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="lowerBoundType">Type of the lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="upperBoundType">Type of the upper bound.</param>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>

        public CollectionCountValidatorAttribute(int lowerBound, RangeBoundaryType lowerBoundType, int upperBound, RangeBoundaryType upperBoundType, string messageTemplate, bool negated)
        {
            _lowerBound = lowerBound;
            _lowerBoundType = lowerBoundType;
            _upperBound = upperBound;
            _upperBoundType = upperBoundType;
            base.MessageTemplate = messageTemplate;
            base.Negated = negated;

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
        protected override Validator DoCreateValidator(System.Type targetType)
        {
            return new CollectionCountValidator(_lowerBound, _lowerBoundType, _upperBound, _upperBoundType, MessageTemplate, Negated);
        }

    }

}
