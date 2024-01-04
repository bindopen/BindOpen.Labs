using System.Collections.Generic;

namespace BindOpen.Labs.i18n.Models
{
    /// <summary>
    /// This class represents the translation sheet.
    /// </summary>
    public class TranslationSheet
    {
        #region Properties

        /// <summary>
        /// The language of translation of this instance.
        /// </summary>
        public string Language { get; internal set; }

        /// <summary>
        /// The translation entries of this instance.
        /// </summary>
        public List<TranslationEntry> Entries { get; set; } = new List<TranslationEntry>();

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the TranslationSheet class.
        /// </summary>
        public TranslationSheet()
        {
        }

        #endregion
    }
}