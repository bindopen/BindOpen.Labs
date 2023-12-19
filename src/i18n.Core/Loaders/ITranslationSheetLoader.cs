using BindOpen.Labs.i18n.Models;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This interface defines a translation sheet loader.
    /// </summary>
    public interface ITranslationSheetLoader
    {
        /// <summary>
        /// Loads the translation sheet from the input file path.
        /// </summary>
        /// <param name="inputFilePath">The input file path to consider.</param>
        /// <returns>Returns the translation sheet loaded.</returns>
        TranslationSheet Load(string inputFilePath);
    }
}
