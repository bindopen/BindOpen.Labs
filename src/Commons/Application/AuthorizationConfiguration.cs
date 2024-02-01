using System.Text.Json.Serialization;

namespace BindOpen.Labs.Application
{
    /// <summary>
    /// This class represents the authorization configuration.
    /// </summary>
    public class AuthorizationConfiguration
    {
        #region Properties

        /// <summary>
        /// The issuer of this instance.
        /// </summary>
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// The audience of this instance.
        /// </summary>
        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the AuthorizationConfiguration class.
        /// </summary>
        public AuthorizationConfiguration()
        {
        }

        #endregion
    }
}