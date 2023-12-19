using BindOpen.Labs.i18n.Models;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This interface defines a translation sheet exporter.
    /// </summary>
    public interface ITranslationSheetExporter
    {
        /// <summary>
        /// Exports the specified translation sheet to the specified output file path.
        /// </summary>
        /// <param name="sheet">The sheet to consider.</param>
        /// <param name="outputFilePath">The output file path to consider.</param>
        /// <returns>Returns True if the exportation has succeeded.</returns>
        bool Export(
            TranslationSheet sheet,
            string outputFilePath);
    }
}
