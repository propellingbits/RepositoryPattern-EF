using System;
using System.Runtime.Serialization;

namespace Framework.Validation.Ssn
{

    /// <summary>
    /// InvalidGroupNumberException
    /// </summary>
    [Serializable]
    public sealed class InvalidGroupNumberException : Exception
    {
        /// <summary>
        /// InvalidGroupNumberException
        /// </summary>
        public InvalidGroupNumberException() { }

        /// <summary>
        /// InvalidGroupNumberException
        /// </summary>
        /// <param name="msg"></param>
        public InvalidGroupNumberException(string msg)
            : base(msg) { }

        /// <summary>
        /// InvalidGroupNumberException
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="inner"></param>
        public InvalidGroupNumberException(string msg, Exception inner)
            : base(msg, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidGroupNumberException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        private InvalidGroupNumberException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

}