using API.Helpers;
using System;
using System.Runtime.Serialization;

namespace API.Exceptions
{

    /// <summary> The MyBankException class </summary>
    public class MyBankException : Exception
    {
        [DataMember]
        public Response Response { get; set; }

        /// <summary> The MyBankException class constructor</summary>
        /// <param name="response"></param>
        public MyBankException(Response response) : base()
        {

        }

        /// <summary> The MyBankException class constructor</summary>
        /// <param name="exception">The exception</param>
        /// <param name="response">Then response object</param>
        public MyBankException(Exception exception, Response response)
            : base(exception.Message, exception)
        {
            Response = response;
        }
    }
}
