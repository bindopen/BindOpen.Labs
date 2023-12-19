using System.Text.Json.Serialization;

namespace BindOpen.Labs.Shared.Data
{
    /// <summary>
    /// This class represents the dated DTO.
    /// </summary>
    public abstract class DatedTrackedDto : DatedDto, IDatedTracked
    {
        #region Properties

        /// <summary>
        /// The one who has created this instance.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// The one who has lastly modified this instance.
        /// </summary>
        [JsonPropertyName("lastModifiedBy")]
        public string LastModifiedBy { get; set; }

        #endregion
    }
}