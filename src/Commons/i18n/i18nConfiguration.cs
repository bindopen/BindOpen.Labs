using System.Text.Json.Serialization;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This class represents the i18n configuration.
    /// </summary>
    public class I18nConfiguration
    {
        #region Properties

        /// <summary>
        /// The file base name of this instance.
        /// </summary>
        [JsonPropertyName("fileBaseName")]
        public string FileBaseName { get; set; }

        /// <summary>
        /// The path of the translation folder of this instance.
        /// </summary>
        [JsonPropertyName("folderPath")]
        public string FolderPath { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the LocalizationConfiguration class.
        /// </summary>
        /// <param name="fileBaseName">The file base name to consider.</param>
        /// <param name="folderPath">The path of the translation folder to consider.</param>
        public I18nConfiguration(string fileBaseName = null, string folderPath = null)
        {
            FileBaseName = fileBaseName;
            FolderPath = folderPath;
        }

        #endregion
    }
}