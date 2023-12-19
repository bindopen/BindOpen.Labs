﻿namespace BindOpen.Labs.Shared.Data
{
    /// <summary>
    /// This interface defines a dated and tracked DTO.
    /// </summary>
    public interface IDatedTracked : IDated
    {
        #region Properties

        /// <summary>
        /// The one who has created this instance.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// The one who has lastly modified this instance.
        /// </summary>
        string LastModifiedBy { get; set; }

        #endregion
    }
}