using System;
using System.Collections;
using System.Runtime.Serialization;


namespace Framework.Validation.Ssn
{
    /// <summary>
    /// Exception that is thrown when the SSN is invalid.
    /// </summary>
    [Serializable]
    public sealed class InvalidSsnException : Exception
    {
        /// <summary>
        /// InvalidSsnException
        /// </summary>
        public InvalidSsnException()
        { 
        }
        
        /// <summary>
        /// InvalidSsnException
        /// </summary>
        /// <param name="msg"></param>
        public InvalidSsnException(string msg)
            :base(msg)
        {
        }

        /// <summary>
        /// InvalidSsnException
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="inner"></param>
        public InvalidSsnException(string msg, Exception inner)
            : base(msg, inner)
        {
        }

        /// <summary>
        /// InvalidSsnException
        /// </summary>
        /// <param name="dictionary"></param>
        public InvalidSsnException(IDictionary dictionary)
        {
            foreach (DictionaryEntry de in dictionary)
            {
                this.Data.Add(de.Key, de.Value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSsnException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        private InvalidSsnException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

}