using Microsoft.AspNetCore.Http;
using System.Linq;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This static class exposes custom string helper methods.
    /// </summary>
    public static class CustomStringHelper
    {
        #region Variables

        private static readonly char __SeparatorChar = '$';

        #endregion

        #region Functions

        /// <summary>
        /// Gets the translation dictionary key from the specified language and translation key.
        /// </summary>
        /// <param name="lang">The language to consider.</param>
        /// <param name="key">The translation key to consider.</param>
        /// <returns></returns>
        public static string GetTranslationDictionaryKey(string lang, string key) => lang?.ToUpper() + __SeparatorChar + key;

        /// <summary>
        /// Gets the translation entry key from the specified translation dictionary key.
        /// </summary>
        /// <param name="dictionaryKey">The translation dictionary key to consider.</param>
        /// <returns></returns>
        public static string GetTranslationEntryKey(string dictionaryKey) => dictionaryKey?.Contains(__SeparatorChar) == false ? dictionaryKey : dictionaryKey[(dictionaryKey.IndexOf(__SeparatorChar) + 1)..];

        /// <summary>
        /// Gets the translation language from the specified dictionary key.
        /// </summary>
        /// <param name="dictionaryKey">The dictionary key to consider.</param>
        /// <returns></returns>
        public static string GetEntryLanguage(string dictionaryKey) => dictionaryKey?.Contains(__SeparatorChar) == false ? dictionaryKey : dictionaryKey.Substring(0, dictionaryKey.IndexOf(__SeparatorChar));

        /// <summary>
        /// Gets the Http context UI culture.
        /// </summary>
        /// <param name="context">The context to consider.</param>
        /// <param name="defaultUICulture">The default UI culture to consider.</param>
        /// <returns></returns>
        public static string GetHttpContextUICulture(
            this HttpContext context, string defaultUICulture = null)
        {
            // we retrieve the language from query string first
            // then (if not existing) from header

            var lang = context?.Request.Query["lang"].ToString();
            if (string.IsNullOrEmpty(lang))
            {
                lang = context?.Request.Headers["Accept-Language"].ToString();
            }

            lang = lang?.Split(',').FirstOrDefault();

            if (string.IsNullOrEmpty(lang))
            {
                lang = defaultUICulture;
            }

            return lang;
        }

        #endregion
    }
}