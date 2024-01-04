﻿using System.Threading.Tasks;

namespace BindOpen.Data
{
    /// <summary>
    /// This interface defines a lockable object.
    /// </summary>
    public interface ILockable
    {
        /// <summary>
        /// Indicates whether this object is locked.
        /// </summary>
        bool IsLocked
        {
            get;
        }

        /// <summary>
        /// Locks this object.
        /// </summary>
        /// <param key="isRecursive">Indicates whether the protection is applied to sub objects.</param>
        Task Lock(bool isRecursive = true);

        /// <summary>
        /// Unlocks this object.
        /// </summary>
        /// <param key="isRecursive">Indicates whether the protection is applied to sub objects.</param>
        Task Unlock(bool isRecursive = true);
    }
}
