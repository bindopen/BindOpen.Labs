using BindOpen.Labs.i18n.Models;
using System.Linq;
using System.Xml.Linq;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This class represents a translation sheet JSON exporter.
    /// </summary>
    public class TranslationSheetExporter_Xliff2 : ITranslationSheetExporter
    {
        /// <summary>
        /// Initializes a new instance of the TranslationSheetExporter_Xliff2 class.
        /// </summary>
        public TranslationSheetExporter_Xliff2()
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

            XNamespace ns = "urn:oasis:names:tc:xliff:document:2.0";

            var doc = new XDocument(
                new XElement(ns + "xliff",
                    new XAttribute("version", "2.0"),
                    //new XAttribute("xmlns", ns),
                    new XAttribute("srcLang", sheet.Language),
                    new XElement(ns + "file",
                        new XAttribute("id", "ngi18n"),
                        new XAttribute("original", "ng.template"),
                        sheet.Entries.Select(entry =>
                            new XElement(ns + "unit",
                                new XAttribute("id", entry.Key),
                                new XElement(ns + "notes",
                                    entry.Locations.Select(q =>
                                        new XElement(ns + "note", new XAttribute("category", q)))),
                                new XElement(ns + "segment",
                                    new XElement(ns + "source", entry.Source),
                                    new XElement(ns + "target", entry.Target)))))));

            doc.Save(outputFilePath);

            return true;
        }
    }
}
