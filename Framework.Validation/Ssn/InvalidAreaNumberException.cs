using System;
using System.Runtime.Serialization;


namespace Framework.Validation.Ssn
{   
    /// <summary>
    /// InvalidAreaNumberException
    /// </summary>
    [Serializable]
    public sealed class InvalidAreaNumberException : Exception
    {
        /// <summary>
        /// InvalidAreaNumberException
        /// </summary>
        public InvalidAreaNumberException()
        { 

        }
        
        /// <summary>
        /// InvalidAreaNumberException
        /// </summary>
        /// <param name="msg"></param>
        public InvalidAreaNumberException(string msg)
            :base(msg)
        {

        }

        /// <summary>
        /// InvalidAreaNumberException
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="inner"></param>
        public InvalidAreaNumberException(string msg, Exception inner)
            : base(msg, inner)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAreaNumberException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        private InvalidAreaNumberException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

}