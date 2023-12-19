﻿namespace BindOpen.Labs.Shared.Data
{
    /// <summary>
    /// This class represents the search form request DTO.
    /// </summary>
    public interface IExportRequest
    {
        #region Properties

        /// <summary>
        /// The export format of this instance.
        /// </summary>
        ExportFormats ExportFormat { get; set; }

        /// <summary>
        /// The file name of this instance.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// The document title of this instance.
        /// </summary>
        string DocumentDisplayName { get; set; }

        /// <summary>
        /// The culture of this instance.
        /// </summary>
        string Culture { get; set; }

        #endregion
    }
}