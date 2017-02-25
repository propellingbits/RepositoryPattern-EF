using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;


namespace Framework.Validation.Validators
{

    /// <summary>
    /// 
    /// </summary>
    public class IgnoreNullRegexValidator : RegexValidator
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public IgnoreNullRegexValidator(string pattern)
            : base(pattern)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullRegexValidator(string pattern, bool negated)
            : base(pattern, negated)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="messageTemplate">The message template.</param>
        public IgnoreNullRegexValidator(string pattern, string messageTemplate)
            : base(pattern, messageTemplate)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullRegexValidator(string pattern, string messageTemplate, bool negated)
            : base(pattern, messageTemplate, negated)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        /// <param name="options">The options.</param>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullRegexValidator(string pattern, string patternResourceName, System.Type patternResourceType, System.Text.RegularExpressions.RegexOptions options, string messageTemplate, bool negated)
            : base(pattern, patternResourceName, patternResourceType, options, messageTemplate, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="options">The options.</param>
        public IgnoreNullRegexValidator(string pattern, System.Text.RegularExpressions.RegexOptions options)
            : base(pattern, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="options">The options.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullRegexValidator(string pattern, System.Text.RegularExpressions.RegexOptions options, bool negated)
            : base(pattern, options, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="options">The options.</param>
        /// <param name="messageTemplate">The message template.</param>
        public IgnoreNullRegexValidator(string pattern, System.Text.RegularExpressions.RegexOptions options, string messageTemplate)
            : base(pattern, options, messageTemplate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="options">The options.</param>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullRegexValidator(string pattern, System.Text.RegularExpressions.RegexOptions options, string messageTemplate, bool negated)
            : base(pattern, options, messageTemplate, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        public IgnoreNullRegexValidator(string patternResourceName, System.Type patternResourceType)
            : base(patternResourceName, patternResourceType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullRegexValidator(string patternResourceName, System.Type patternResourceType, bool negated)
            : base(patternResourceName, patternResourceType, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        /// <param name="messageTemplate">The message template.</param>
        public IgnoreNullRegexValidator(string patternResourceName, System.Type patternResourceType, string messageTemplate)
            : base(patternResourceName, patternResourceType, messageTemplate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullRegexValidator(string patternResourceName, System.Type patternResourceType, string messageTemplate, bool negated)
            : base(patternResourceName, patternResourceType, messageTemplate, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        /// <param name="options">The options.</param>
        public IgnoreNullRegexValidator(string patternResourceName, System.Type patternResourceType, System.Text.RegularExpressions.RegexOptions options)
            : base(patternResourceName, patternResourceType, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        /// <param name="options">The options.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullRegexValidator(string patternResourceName, System.Type patternResourceType, System.Text.RegularExpressions.RegexOptions options, bool negated)
            : base(patternResourceName, patternResourceType, options, negated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        /// <param name="options">The options.</param>
        /// <param name="messageTemplate">The message template.</param>
        public IgnoreNullRegexValidator(string patternResourceName, System.Type patternResourceType, System.Text.RegularExpressions.RegexOptions options, string messageTemplate)
            : base(patternResourceName, patternResourceType, options, messageTemplate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidator" /> class.
        /// </summary>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        /// <param name="options">The options.</param>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public IgnoreNullRegexValidator(string patternResourceName, System.Type patternResourceType, System.Text.RegularExpressions.RegexOptions options, string messageTemplate, bool negated)
            : base(patternResourceName, patternResourceType, options, messageTemplate, negated)
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
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
    public sealed class IgnoreNullRegexValidatorAttribute : ValueValidatorAttribute
    {

        private string _pattern;
        private System.Text.RegularExpressions.RegexOptions _options;
        private string _patternResourceName;

        private System.Type _patternResourceType;

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        public System.Text.RegularExpressions.RegexOptions Options
        {
            get { return _options; }
        }

        /// <summary>
        /// Gets the pattern.
        /// </summary>
        /// <value>The pattern.</value>
        public string Pattern
        {
            get { return _pattern; }
        }

        /// <summary>
        /// Gets the name of the pattern resource.
        /// </summary>
        /// <value>The name of the pattern resource.</value>
        public string PatternResourceName
        {
            get { return _patternResourceName; }
        }

        /// <summary>
        /// Gets the type of the pattern resource.
        /// </summary>
        /// <value>The type of the pattern resource.</value>
        public System.Type PatternResourceType
        {
            get { return _patternResourceType; }
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public IgnoreNullRegexValidatorAttribute(string pattern)
        {
            _pattern = pattern;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidatorAttribute" /> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="options">The options.</param>
        public IgnoreNullRegexValidatorAttribute(string pattern, System.Text.RegularExpressions.RegexOptions options)
        {
            _pattern = pattern;
            _options = options;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidatorAttribute" /> class.
        /// </summary>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        public IgnoreNullRegexValidatorAttribute(string patternResourceName, System.Type patternResourceType)
        {
            _patternResourceName = patternResourceName;
            _patternResourceType = patternResourceType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreNullRegexValidatorAttribute" /> class.
        /// </summary>
        /// <param name="patternResourceName">Name of the pattern resource.</param>
        /// <param name="patternResourceType">Type of the pattern resource.</param>
        /// <param name="options">The options.</param>
        public IgnoreNullRegexValidatorAttribute(string patternResourceName, System.Type patternResourceType, System.Text.RegularExpressions.RegexOptions options)
        {
            _patternResourceName = patternResourceName;
            _patternResourceType = patternResourceType;
            _options = options;
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
            return new IgnoreNullRegexValidator(this.Pattern, this.MessageTemplate);
        }




    }
}
