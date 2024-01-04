using System;

namespace BindOpen.Labs.i18n.Models
{
    /// <summary>
    /// This class represents the translation file formats.
    /// </summary>
    [Flags]
    public enum TranslationFileFormats
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Any.
        /// </summary>
        Any,

        /// <summary>
        /// Json.
        /// </summary>
        Json = 0x01 << 0,

        /// <summary>
        /// Xliff2.
        /// </summary>
        Xliff2 = 0x01 << 1
    }
}