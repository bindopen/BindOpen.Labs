using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BindOpen.Labs.Shared.i18n
{
    /// <summary>
    /// This class represents the localization default settings.
    /// </summary>
    public static class i18nDefaultSettings
    {
        #region Properties

        /// <summary>
        /// The path of the default folder.
        /// </summary>
        public static readonly string __DefaultFolderPath = Path.Combine("wwwroot", "i18n");

        /// <summary>
        /// The base name of the file.
        /// </summary>
        public static readonly string __DefaultFileBaseName = "translate_";

        /// <summary>
        /// The default culture.
        /// </summary>
        public static readonly string __DefaultCulture = "fr-FR";

        /// <summary>
        /// The supported cultures.
        /// </summary>
        public static readonly List<CultureInfo> __SupportedCultures = new List<CultureInfo>
        {
            new CultureInfo("fr-FR"),
            new CultureInfo("en-US")
        };

        #endregion
    }
}