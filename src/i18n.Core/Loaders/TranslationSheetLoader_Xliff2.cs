using BindOpen.Labs.i18n.Models;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This class represents a translation sheet loader.
    /// </summary>
    public class TranslationSheetLoader_Xliff2 : ITranslationSheetLoader
    {
        /// <summary>
        /// Loads the translation sheet from the input file path.
        /// </summary>
        /// <param name="inputFilePath">The input file path to consider.</param>
        /// <returns>Returns the translation sheet loaded.</returns>
        public TranslationSheet Load(
            string inputFilePath)
        {
            if (!File.Exists(inputFilePath)) return null;

            var sheet = new TranslationSheet();
            XNamespace ns = "urn:oasis:names:tc:xliff:document:2.0";

            var doc = XDocument.Load(inputFilePath);
            {
                sheet.Language = doc.Root.Attribute("srcLang").Value;
                var element_units = doc.Root.Descendants(ns + "unit");

                foreach (var element_unit in element_units)
                {
                    var entry = new TranslationEntry
                    {
                        Key = element_unit.Attribute("id").Value
                    };

                    var element_notes = element_unit.Descendants(ns + "note")
                        .Where(q => q.Attribute("category")?.Value == "location");

                    foreach (var element_note in element_notes)
                    {
                        entry.Locations.Add(element_note.Value);
                    }

                    entry.Source = element_unit.Descendants(ns + "source")?.FirstOrDefault()?.Value;
                    entry.Target = element_unit.Descendants(ns + "target")?.FirstOrDefault()?.Value;
                    sheet.Entries.Add(entry);
                }
            }

            return sheet;
        }
    }
}
