using System.Text.Json.Serialization;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents an problem detail DTO.
    /// </summary>
    public class ProblemDetailsDto
    {
        #region Properties

        /// <summary>
        /// The name of this instance.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The product name of this instance.
        /// </summary>
        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        /// <summary>
        /// The status code of this instance.
        /// </summary>
        [JsonPropertyName("status")]
        public string StatusCode { get; set; }

        /// <summary>
        /// The request ID of this instance.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// The internal code of this instance.
        /// </summary>
        /// <example>'ERROR-854'</example>
        [JsonPropertyName("internalCode")]
        public string InternalCode { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the ProblemDetailsDto class.
        /// </summary>
        public ProblemDetailsDto()
        {
        }

        #endregion
    }
}