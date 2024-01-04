using BindOpen.Labs.i18n.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This interface defines a translation sheet merger.
    /// </summary>
    public static class TranslationSheetExtensions
    {
        /// <summary>
        /// Merges the input sheet with the output one.
        /// </summary>
        /// <param name="inputSheet">The input sheet to consider.</param>
        /// <param name="outputSheet">The output sheet to consider.</param>
        /// <param name="onlyIfExisting">Indicates whether the merge must done only if sheets exist.</param>
        /// <param name="elementKinds">The kinds of elements to consider.</param>
        public static void Merge(
            this TranslationSheet inputSheet,
            TranslationSheet outputSheet,
            bool onlyIfExisting = false,
            params TranslationElementKinds[] elementKinds)
        {
            if (outputSheet?.Entries == null) return;

            if (!elementKinds.Contains(TranslationElementKinds.Any) && !elementKinds.Any(q => TranslationElementKinds.Entry.HasFlag(q))) return;

            inputSheet.Entries.ForEach(q =>
            {
                if (elementKinds.Contains(TranslationElementKinds.Any) || elementKinds.Contains(TranslationElementKinds.Entry_Source_Target))
                {
                    var value = q.Target ?? "";
                    if (!onlyIfExisting || value != "")
                    {
                        q.Source = value;
                    }
                }
                if (elementKinds.Contains(TranslationElementKinds.Any) || elementKinds.Contains(TranslationElementKinds.Entry_Target_Source))
                {
                    var value = q.Source ?? "";
                    if (!onlyIfExisting || value != "")
                    {
                        q.Target = value;
                    }
                }
            });

            foreach (var outputEntry in outputSheet.Entries)
            {
                var inputEntry = inputSheet.Entries.FirstOrDefault(q => q.Key.Equals(outputEntry.Key, StringComparison.OrdinalIgnoreCase));

                if (inputEntry != null)
                {
                    if (elementKinds.Contains(TranslationElementKinds.Any) || elementKinds.Contains(TranslationElementKinds.Entry_Locations))
                    {
                        inputEntry.Locations = new List<string>(outputEntry.Locations);
                    }


                    if (elementKinds.Contains(TranslationElementKinds.Any) || elementKinds.Contains(TranslationElementKinds.Entry_Source))
                    {
                        var value = outputEntry.Source ?? "";
                        if (!onlyIfExisting || value != "")
                        {
                            inputEntry.Source = value;
                        }
                    }
                    if (elementKinds.Contains(TranslationElementKinds.Any) || elementKinds.Contains(TranslationElementKinds.Entry_Source_Entry_Target))
                    {
                        var value = outputEntry.Target ?? "";
                        if (!onlyIfExisting || value != "")
                        {
                            inputEntry.Source = value;
                        }
                    }

                    if (elementKinds.Contains(TranslationElementKinds.Any) || elementKinds.Contains(TranslationElementKinds.Entry_Target))
                    {
                        var value = outputEntry.Target ?? "";
                        if (!onlyIfExisting || value != "")
                        {
                            inputEntry.Target = value;
                        }
                    }
                    if (elementKinds.Contains(TranslationElementKinds.Any) || elementKinds.Contains(TranslationElementKinds.Entry_Target_Entry_Source))
                    {
                        var value = outputEntry.Source ?? "";
                        if (!onlyIfExisting || value != "")
                        {
                            inputEntry.Target = value;
                        }
                    }
                }
            }
        }
    }
}
