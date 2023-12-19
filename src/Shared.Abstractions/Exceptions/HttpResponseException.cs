using System;

namespace BindOpen.Labs.Shared.Exceptions
{
    /// <summary>
    /// This class represents a HTTP response exception.
    /// </summary>
    public class HttpResponseException : Exception
    {
        #region Properties

        /// <summary>
        /// The status.
        /// </summary>
        public int Status { get; set; } = 500;

        /// <summary>
        /// The object value.
        /// </summary>
        public object Value { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the HttpResponseException class.
        /// </summary>
        public HttpResponseException() : base()
        {
        }

        #endregion
    }
}