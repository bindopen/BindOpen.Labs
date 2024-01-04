using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This class represents a factory to a custom string localizer.
    /// </summary>
    public class CustomStringLocalizerFactory : IStringLocalizerFactory
    {
        #region Variables

        string _folderPath = null;
        string _fileBaseName = null;

        #endregion

        #region Properties

        /// <summary>
        /// The path of the i18n folder.
        /// </summary>
        string FolderPath
        {
            get => _folderPath;
            set
            {
                _folderPath = value;
                if (string.IsNullOrEmpty(_folderPath))
                {
                    _folderPath = i18nDefaultSettings.__DefaultFolderPath;
                }
                if (_folderPath?.Contains(':') == false)
                {
                    _folderPath = Path.Combine(Directory.GetCurrentDirectory(), _folderPath);
                }
            }
        }

        /// <summary>
        /// The base name of i18n files.
        /// </summary>
        private string FileBaseName
        {
            get => _fileBaseName;
            set
            {
                if (value != null)
                {
                    _fileBaseName = value;
                    if (string.IsNullOrEmpty(_fileBaseName))
                    {
                        _fileBaseName = i18nDefaultSettings.__DefaultFileBaseName;
                    }
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the CustomStringLocalizerFactory class.
        /// </summary>
        /// <param name="i18nOptions">The i18n options to consider.</param>
        public CustomStringLocalizerFactory(IOptions<I18nConfiguration> i18nOptions)
        {
            // we retrieve the i18n configuration

            var localizationConfiguration = i18nOptions?.Value;

            FolderPath = localizationConfiguration?.FolderPath ?? i18nDefaultSettings.__DefaultFolderPath;
            FileBaseName = localizationConfiguration?.FileBaseName ?? i18nDefaultSettings.__DefaultFileBaseName;
        }

        #endregion

        #region IStringLocalizerFactory_Implementation

        /// <summary>
        /// Creates a new string localizer considering the specified resource type.
        /// </summary>
        /// <param name="resourceSource">The resource source to consider.</param>
        /// <returns>Returns a new string localizer.</returns>
        public IStringLocalizer Create(Type resourceSource)
        {
            return new CustomStringLocalizer();
        }

        /// <summary>
        /// Creates a new string localizer considering the specified base file name and folder location.
        /// </summary>
        /// <param name="baseName">The name of the base file to consider.</param>
        /// <param name="location">The path of the folder to consider.</param>
        /// <returns>Returns a new string localizer.</returns>
        public IStringLocalizer Create(string baseName, string location)
        {
            FileBaseName = baseName;
            FolderPath = location;
            return new CustomStringLocalizer(GetEntries());
        }

        #endregion

        #region Seekers

        /// <summary>
        /// Retrieve the entry dictionary from files.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetEntries()
        {
            Dictionary<string, string> entries = new Dictionary<string, string>();

            var files = Directory.GetFiles(FolderPath, FileBaseName + "*.json");
            foreach (var file in files)
            {
                var translation = GetTranslationFromFile(file);
                if (translation != null)
                {
                    string language = translation.Language;

                    // if the language is missing then we retrieve from the file name (as its format is {basename}.{lang}.{ext})

                    if (string.IsNullOrEmpty(language))
                    {
                        string fileWithoutExtension = Path.GetFileNameWithoutExtension(file);
                        if (fileWithoutExtension.Contains("."))
                        {
                            language = fileWithoutExtension[(fileWithoutExtension.LastIndexOf('.') + 1)..];
                        }
                    }

                    // otherwise we get the default language

                    if (string.IsNullOrEmpty(language))
                    {
                        language = i18nDefaultSettings.__DefaultCulture;
                    }

                    var key = "";
                    foreach (var entry in translation.Entries)
                    {
                        try
                        {
                            key = CustomStringHelper.GetTranslationDictionaryKey(language, entry.Key);
                            entries.Add(key, entry.Target);
                        }
                        catch
                        {
                            var fileName = Path.GetFileName(file);
                            throw new I18nException("Duplicated key found in file '" + fileName + "' ('" + entry.Key + "')");
                        }
                    }
                }
            }

            return entries;
        }

        /// <summary>
        /// Gets the DTO translation from the specified file.
        /// </summary>
        /// <param name="filePath">The file to consider.</param>
        /// <returns>Returns the DTO translation.</returns>
        private static TranslationDto GetTranslationFromFile(string filePath)
        {
            TranslationDto translation;

            // we read the translation file

            var fileName = "";

            try
            {
                fileName = Path.GetFileName(filePath);
                translation = JsonSerializer.Deserialize<TranslationDto>(File.ReadAllText(filePath));
            }
            catch
            {

                throw new I18nException("Could not load translation file '" + fileName + "'");
            }

            return translation;
        }

        #endregion
    }
}