using BindOpen.Labs.i18n.Models;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This class represents a translation sheet exporter factory.
    /// </summary>
    public static class TranslationSheetExporterFactory
    {
        /// <summary>
        /// Creates a new instance of the ITranslationSheetExporter class.
        /// </summary>
        public static ITranslationSheetExporter Create(TranslationFileFormats format)
        {
            return format switch
            {
                TranslationFileFormats.Json => new TranslationSheetExporter_Json(),
                TranslationFileFormats.Xliff2 => new TranslationSheetExporter_Xliff2(),
                _ => null,
            };
        }
    }
}
