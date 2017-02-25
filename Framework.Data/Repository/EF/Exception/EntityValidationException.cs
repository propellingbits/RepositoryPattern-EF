using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Framework.Data.Repository.EF
{
    /// <summary>
    /// EntityValidationException 
    /// </summary>
    [Serializable]
    public class EntityValidationException : Exception
    {
        private readonly ValidationResults _errors;


        /// <summary>
        /// Initializes a new instance of the EntityValidationException class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        public EntityValidationException(ValidationResults errors)
        {
            _errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityValidationException"/> class.
        /// </summary>
        public EntityValidationException()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public EntityValidationException(string message)
            : base(message)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errors">The errors.</param>
        public EntityValidationException(string message, ValidationResults errors)
            : base(message)
        {
            _errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public EntityValidationException(string message, System.Exception innerException)
            : base(message, innerException)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="errors">The errors.</param>
        public EntityValidationException(string message, System.Exception innerException, ValidationResults errors)
            : base(message, innerException)
        {
            _errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityValidationException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized data.</param>
        /// <param name="context">Context information about the source or destination of the serialized object.</param>
        protected EntityValidationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            
        }


        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        /// <value>The validation errors.</value>
        public ValidationResults ValidationErrors
        {
            get { return _errors; }
        }

        /// <summary>
        /// Gets information about the exception and adds it to the <see cref="T:System.Runtime.Serialization.SerializationInfoEnumerator"/> object
        /// </summary>
        /// <param name="info">The object that holds the serialized object data for the exception that occurred.</param>
        /// <param name="context">Context information about the source or destination of the exception.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            
            base.GetObjectData(info, context);
            // TODO add information to info with info.AddValue
        }


    }
}