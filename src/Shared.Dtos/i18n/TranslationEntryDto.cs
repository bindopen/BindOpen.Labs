﻿using BindOpen.Labs.Shared.Data;
using System.Text.Json.Serialization;

namespace BindOpen.Labs.Shared.i18n
{
    /// <summary>
    /// This class represents the translation entry DTO.
    /// </summary>
    public class TranslationEntryDto : IDto
    {
        #region Properties

        /// <summary>
        /// The translation key of this instance.
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// The location of this instance.
        /// </summary>
        /// <remarks>This is a description of the location of the translation entry in the application.</remarks>
        /// <example>home, clients-edit-general</example>
        [JsonPropertyName("location")]
        public string Location { get; set; }

        /// <summary>
        /// The translation source of this instance.
        /// </summary>
        /// <remarks>This is the translation of the entry into a source language. This property is used for translators.</remarks>
        [JsonPropertyName("source")]
        public string Source { get; set; }

        /// <summary>
        /// The translation target of this instance.
        /// </summary>
        /// <remarks>This is the translation of the entry taken into account.</remarks>
        [JsonPropertyName("target")]
        public string Target { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the TranslationEntryDto class.
        /// </summary>
        public TranslationEntryDto()
        {
        }

        #endregion
    }
}