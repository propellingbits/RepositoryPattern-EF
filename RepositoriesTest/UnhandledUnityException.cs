using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriesTest
{
    /// <summary>
    /// Wrapper class for all the important Unity based exceptions.
    /// </summary>
    public class UnhandledUnityException : Exception
    {
    //    int _errorNumber = int.MinValue;
    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="UnhandledUnityException"/> class.
    //    /// </summary>
    //    public UnhandledUnityException()
    //        : base()
    //    {

    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="UnhandledUnityException"/> class.
    //    /// </summary>
    //    /// <param name="message">The message.</param>
    //    public UnhandledUnityException(string message)
    //        : base(message)
    //    {
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="UnhandledUnityException"/> class.
    //    /// </summary>
    //    /// <param name="message">The message.</param>
    //    /// <param name="innerException">The inner exception.</param>
    //    public UnhandledUnityException(string message, Exception innerException)
    //        : base(message, innerException)
    //    {
    //        if (InnerException == null) throw new ArgumentNullException("innerException cannot be null.");
    //        ProcessException();
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="UnhandledUnityException"/> class.
    //    /// </summary>
    //    /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
    //    /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
    //    /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
    //    /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
    //    protected UnhandledUnityException(SerializationInfo info, StreamingContext context)
    //        : base(info, context)
    //    {

    //    }

    //    /// <summary>
    //    /// Gets a collection of key/value pairs that provide additional user-defined information about the exception.
    //    /// </summary>
    //    /// <value></value>
    //    /// <returns>An object that implements the <see cref="T:System.Collections.IDictionary"/> interface and contains a collection of user-defined key/value pairs. The default is an empty collection.</returns>
    //    public override System.Collections.IDictionary Data
    //    {
    //        get
    //        {
    //            // TODO: add some contextual information to the exception.
    //            return base.Data;
    //        }
    //    }



    //    /// <summary>
    //    /// Gets a detailed message that describes the current exception.
    //    /// </summary>
    //    /// <value></value>
    //    /// <returns>The error message that explains the reason for the exception, or an empty string("").</returns>
    //    public override string DetailedMessage
    //    {
    //        get
    //        {
    //            return Environment.NewLine + _information + Environment.NewLine;
    //        }
    //    }

    //    StringBuilder _toStringBuilder = new StringBuilder();

    //    private string _information = string.Empty;
    //    private void ProcessException()
    //    {
    //        if (InnerException is ResolutionFailedException)
    //        {
    //            _toStringBuilder.AppendLine("--- Unity exception details ---");

    //            Exception innermostException = base.GetBaseException();

    //            HelpLink = @"\\pwishbgdts01\ICIS\Technical Documentation\Technical Bulletins (TB)\TB005 eCIS Container and Dependency Issues FAQ.doc";
    //            _information = innermostException.Message;
    //            _errorNumber = 80120;
    //            return;
    //        }

    //        // if you reached this point, its unhandled. But you still need to restore related exception information.
    //        //_toStringBuilder.AppendLine(InnerException.ToString());

    //    }

    //    private string _toString = string.Empty;
    //    /// <summary>
    //    /// Creates and returns a string representation of the current exception.
    //    /// </summary>
    //    /// <returns>
    //    /// A string representation of the current exception.
    //    /// </returns>
    //    /// <PermissionSet>
    //    /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/>
    //    /// </PermissionSet>
    //    public override string ToString()
    //    {
    //        string str2;
    //        string message = this.DetailedMessage;
    //        string className = this.GetType().Name;

    //        if ((message == null) || (message.Length <= 0))
    //        {
    //            str2 = this.GetType().Name;
    //        }
    //        else
    //        {
    //            str2 = className + ": " + message;
    //        }
    //        if (InnerException != null)
    //        {
    //            str2 = str2 + " ---> " + this.InnerException.ToString() + Environment.NewLine + "   " + "--- End of inner exception stack trace ---";
    //        }
    //        if (this.StackTrace != null)
    //        {
    //            str2 = str2 + Environment.NewLine + this.StackTrace;
    //        }
    //        return str2 + Environment.NewLine + _toStringBuilder.ToString();


    //    }



    //    /// <summary>
    //    /// Gets the error number.
    //    /// </summary>
    //    /// <value>The error number.</value>
    //    public override int ErrorNumber
    //    {
    //        get
    //        {
    //            if (_errorNumber != int.MinValue)
    //                return _errorNumber;

    //            return base.ErrorNumber;
    //        }
    //    }
    }
}