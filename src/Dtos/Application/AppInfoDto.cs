using BindOpen.Data;
using System;
using System.Text.Json.Serialization;

namespace BindOpen.Labs.Application
{
    /// <summary>
    /// This class represents an application information DTO.
    /// </summary>
    public class AppInfoDto : IBdoDto
    {
        #region Properties

        /// <summary>
        /// The name of this instance.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of this instance.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The product name of this instance.
        /// </summary>
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }

        /// <summary>
        /// The version of this instance.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        /// The displayed version of this instance.
        /// </summary>
        [JsonPropertyName("displayedVersion")]
        public string DisplayedVersion { get; set; }

        /// <summary>
        /// The company of this instance.
        /// </summary>
        [JsonPropertyName("company")]
        public string Company { get; set; }

        /// <summary>
        /// The copyright of this instance.
        /// </summary>
        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// The authors of this instance.
        /// </summary>
        [JsonPropertyName("authors")]
        public string Authors { get; set; }

        /// <summary>
        /// The build date of this instance.
        /// </summary>
        [JsonPropertyName("buildDate")]
        public DateTime? BuildDate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the AppInfoDto class.
        /// </summary>
        public AppInfoDto()
        {
        }

        #endregion
    }
}