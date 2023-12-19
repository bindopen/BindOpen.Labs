using System;

namespace BindOpen.Labs.i18n.Models
{
    /// <summary>
    /// This class represents the translation entry.
    /// </summary>
    [Flags]
    public enum TranslationElementKinds
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Any.
        /// </summary>
        Any,

        /// <summary>
        /// Language.
        /// </summary>
        Language = 0x01 << 0,

        /// <summary>
        /// Entry key.
        /// </summary>
        Entry_Key = 0x01 << 1,

        /// <summary>
        /// Entry locations.
        /// </summary>
        Entry_Locations = 0x01 << 2,

        /// <summary>
        /// Entry source.
        /// </summary>
        Entry_Source = 0x01 << 3,

        /// <summary>
        /// Entry source from target.
        /// </summary>
        Entry_Source_Target = 0x01 << 4,

        /// <summary>
        /// Entry source from entry target.
        /// </summary>
        Entry_Source_Entry_Target = 0x01 << 5,

        /// <summary>
        /// Entry target.
        /// </summary>
        Entry_Target = 0x01 << 6,

        /// <summary>
        /// Entry target from source.
        /// </summary>
        Entry_Target_Source = 0x01 << 7,

        /// <summary>
        /// Entry target from entry source.
        /// </summary>
        Entry_Target_Entry_Source = 0x01 << 8,

        /// <summary>
        /// Entry.
        /// </summary>
        Entry = Entry_Key | Entry_Locations
            | Entry_Source | Entry_Source_Target | Entry_Source_Entry_Target
            | Entry_Target | Entry_Target_Source | Entry_Target_Entry_Source
    }
}