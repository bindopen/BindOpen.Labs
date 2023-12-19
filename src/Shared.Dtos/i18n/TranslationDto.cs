using BindOpen.Labs.Shared.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BindOpen.Labs.Shared.i18n
{
    /// <summary>
    /// This class represents the translation DTO.
    /// </summary>
    public class TranslationDto : IDto
    {
        #region Properties

        /// <summary>
        /// The language of translation of this instance.
        /// </summary>
        [JsonPropertyName("lang")]
        public string Language { get; internal set; }

        /// <summary>
        /// The translation entries of this instance.
        /// </summary>
        [JsonPropertyName("entries")]
        public List<TranslationEntryDto> Entries { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the TranslationDto class.
        /// </summary>
        public TranslationDto()
        {
        }

        #endregion
    }
}