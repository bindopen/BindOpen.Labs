using BindOpen.Labs.i18n.Models;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This class represents a translation sheet exporter factory.
    /// </summary>
    public static class TranslationSheetLoaderFactory
    {
        /// <summary>
        /// Creates a new instance of the ITranslationSheetExporter class.
        /// </summary>
        public static ITranslationSheetLoader Create(TranslationFileFormats format)
        {
            return format switch
            {
                TranslationFileFormats.Json => new TranslationSheetLoader_Json(),
                TranslationFileFormats.Xliff2 => new TranslationSheetLoader_Xliff2(),
                _ => null,
            };
        }
    }
}
