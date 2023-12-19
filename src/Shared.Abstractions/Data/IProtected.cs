using System;

namespace BindOpen.Labs.Shared.Data
{
    /// <summary>
    /// This interface defines dated DTO.
    /// </summary>
    public interface IProtected : IDto
    {
        #region Properties

        /// <summary>
        /// Indicates whether this instance is readonly.
        /// </summary>
        bool? ReadOnly { get; set; }

        #endregion
    }
}