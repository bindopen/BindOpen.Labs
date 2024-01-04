namespace BindOpen.Data
{
    /// <summary>
    /// This interface defines dated DTO.
    /// </summary>
    public interface IProtected
    {
        /// <summary>
        /// Indicates whether this instance is readonly.
        /// </summary>
        bool? ReadOnly { get; set; }
    }
}