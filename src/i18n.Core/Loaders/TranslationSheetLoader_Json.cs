using BindOpen.Labs.i18n.Models;
using System.IO;
using System.Text.Json;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This class represents a translation sheet loader.
    /// </summary>
    public class TranslationSheetLoader_Json : ITranslationSheetLoader
    {
        /// <summary>
        /// Loads the translation sheet from the input file path.
        /// </summary>
        /// <param name="inputFilePath">The input file path to consider.</param>
        /// <returns>Returns the translation sheet loaded.</returns>
        public TranslationSheet Load(string inputFilePath)
        {
            if (!File.Exists(inputFilePath)) return null;

            var sheet = new TranslationSheet();

            var options = new JsonDocumentOptions
            {
                AllowTrailingCommas = true
            };

            var jsonString = File.ReadAllText(inputFilePath);

            using (var doc = JsonDocument.Parse(jsonString, options))
            {
                sheet.Language = doc.RootElement.GetProperty("locale").GetString();
                var translations = doc.RootElement.GetProperty("translations");
                foreach (var element in translations.EnumerateObject())
                {
                    var entry = new TranslationEntry
                    {
                        Key = element.Name,
                        Source = element.Value.GetString()
                    };
                    sheet.Entries.Add(entry);
                }
            }

            return sheet;
        }
    }
}
