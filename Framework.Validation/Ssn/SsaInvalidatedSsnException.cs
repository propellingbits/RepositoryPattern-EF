using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;


namespace Framework.Validation.Ssn
{

    /// <summary>
    /// SsaInvalidatedSsnException
    /// </summary>
    [Serializable]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ssa")]
    public sealed class SsaInvalidatedSsnException : Exception
    {
        /// <summary>
        /// SsaInvalidatedSsnException
        /// </summary>
        public SsaInvalidatedSsnException()
        {

        }

        /// <summary>
        /// SsaInvalidatedSsnException
        /// </summary>
        /// <param name="msg"></param>
        public SsaInvalidatedSsnException(string msg)
            : base(msg)
        {

        }

        /// <summary>
        /// SsaInvalidatedSsnException
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="inner"></param>
        public SsaInvalidatedSsnException(string msg, Exception inner)
            : base(msg, inner)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SsaInvalidatedSsnException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        private SsaInvalidatedSsnException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

    }

}