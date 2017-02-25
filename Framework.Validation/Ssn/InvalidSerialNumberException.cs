using System;
using System.Runtime.Serialization;


namespace Framework.Validation.Ssn
{

    /// <summary>
    /// Exception that is thrown when an SSN contains an invalid serial number.
    /// </summary>
    [Serializable]
    public sealed class InvalidSerialNumberException : Exception
    {
        /// <summary>
        /// InvalidSerialNumberException
        /// </summary>
        public InvalidSerialNumberException()
        {
        }

        /// <summary>
        /// InvalidSerialNumberException
        /// </summary>
        /// <param name="msg"></param>
        public InvalidSerialNumberException(string msg)
            : base(msg)
        {
        }

        /// <summary>
        /// InvalidSerialNumberException
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="inner"></param>
        public InvalidSerialNumberException(string msg, Exception inner)
            : base(msg, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSerialNumberException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        private InvalidSerialNumberException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

}