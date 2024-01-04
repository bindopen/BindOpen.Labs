using BindOpen.Labs.i18n.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This class represents a translation sheet JSON exporter.
    /// </summary>
    public class TranslationSheetExporter_Json : ITranslationSheetExporter
    {
        /// <summary>
        /// Initializes a new instance of the TranslationSheetExporter_Json class.
        /// </summary>
        public TranslationSheetExporter_Json()
        {
        }

        /// <summary>
        /// Exports the specified translation sheet to the specified output file path.
        /// </summary>
        /// <param name="sheet">The sheet to consider.</param>
        /// <param name="outputFilePath">The output file path to consider.</param>
        /// <returns>Returns True if the exportation has succeeded.</returns>
        public bool Export(
            TranslationSheet sheet,
            string outputFilePath)
        {
            if (sheet == null) return false;

            var encoderSettings = new TextEncoderSettings();

            encoderSettings.AllowRange(UnicodeRanges.LatinExtendedA);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            var translations = new ExpandoObject();
            sheet.Entries.ForEach(q =>
            {
                translations.TryAdd(q.Key, q.Target);
            });

            dynamic sheetDto = new
            {
                locale = sheet.Language,
                translations
            };

            string jsonString = JsonSerializer.Serialize(sheetDto, options);
            File.WriteAllText(outputFilePath, jsonString);

            return true;
        }
    }
}
