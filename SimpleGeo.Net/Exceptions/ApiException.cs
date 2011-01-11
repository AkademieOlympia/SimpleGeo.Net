// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiException.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the ApiException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net.Exceptions
{
    using System;
    using System.Net;

    /// <summary>
    /// Exception that occurs in case interaction with the SimpleGeo.com API fails for one reason or another.
    /// <see cref="http://simplegeo.com/docs/getting-started/introduction#status-codes"/>
    /// </summary>
    public class ApiException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="contentBody">The content body.</param>
        internal ApiException(HttpStatusCode errorCode, string message = "", Exception innerException = null, string contentBody = "") : base(message, innerException)
        {
            this.ErrorCode = errorCode;
            this.ContentBody = contentBody;
        }

        /// <summary>
        /// Gets the http error code.
        /// <see cref="http://simplegeo.com/docs/getting-started/introduction#status-codes"/>
        /// </summary>
        public HttpStatusCode ErrorCode { get; private set; }

        /// <summary>
        /// Gets the content body.
        /// </summary>
        public string ContentBody { get; private set; }
    }
}
