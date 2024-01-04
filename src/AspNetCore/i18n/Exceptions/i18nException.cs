using System;

namespace BindOpen.Labs.i18n
{
    /// <summary>
    /// This class represents an i18n exception.
    /// </summary>
    public class I18nException : Exception
    {
        #region Constructors

        /// <summary>
        /// This class represents an exception occuring in the localization service.
        /// </summary>
        /// <param name="title"></param>
        public I18nException(string title) : base(title)
        {
        }

        #endregion
    }
}