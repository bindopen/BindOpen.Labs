using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This class represents a custom string localizer.
    /// </summary>
    public class CustomStringLocalizer : IStringLocalizer
    {
        #region Variables

        readonly List<string> _languages = new List<string>();
        readonly Dictionary<string, string> _entries = new Dictionary<string, string>();

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the CustomStringLocalizer class.
        /// </summary>
        /// <param name="entries">The entries to consider.</param>
        public CustomStringLocalizer(Dictionary<string, string> entries = null)
        {
            _entries = entries;
            _languages = _entries?.Select(p => CustomStringHelper.GetEntryLanguage(p.Key)).Distinct().ToList();
        }

        #endregion

        #region IStringLocalizer_Implementation

        /// <summary>
        /// Gets the translation entry value having the specified key.
        /// </summary>
        /// <param name="key">The key to consider.</param>
        /// <returns>Returns the translation corresponding to the specified key.</returns>
        public LocalizedString this[string key]
        {
            get
            {
                string lang = CultureInfo.CurrentUICulture?.Name ?? i18nDefaultSettings.__DefaultCulture;
                int i;

                // if the current culture is not handled then we try with the child one. Ex. fr-FR -> fr

                if (!_languages.Contains(lang) && (i = lang.IndexOf('-')) > -1)
                {
                    lang = lang.Substring(0, i);
                }
                string globalKey = CustomStringHelper.GetTranslationDictionaryKey(lang, key);
                var found = _entries.TryGetValue(globalKey, out string text);
                return new LocalizedString(key, text ?? "", resourceNotFound: found);
            }
        }

        /// <summary>
        /// Gets the translation entry value having the specified key considering the specified arguments.
        /// </summary>
        /// <param name="name">The name to consider.</param>
        /// <param name="arguments">The arguments to consider.</param>
        /// <returns>Returns the translation corresponding to the specified key.</returns>
        public LocalizedString this[string name, params object[] arguments] => this[name];


        /// <summary>
        /// Gets all the localized strings of the current culture.
        /// </summary>
        /// <param name="includeParentCultures">Indicates whether the parent culture is considered.</param>
        /// <returns>Returns all the localized strings of the current culture.</returns>
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _entries.Select(p => new LocalizedString(CustomStringHelper.GetTranslationEntryKey(p.Key), p.Value)).ToList();
        }

        /// <summary>
        /// Gets a new string localizer consider the specified culture.
        /// </summary>
        /// <returns>Returns a new string localizer consider the specified culture.</returns>
        /// <remarks>This method is not used.</remarks>
        public static IStringLocalizer WithCulture()
        {
            return new CustomStringLocalizer();
        }

        #endregion
    }
}