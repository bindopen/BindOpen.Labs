namespace BindOpen.Labs.Shared.Data
{
    /// <summary>
    /// This interface defines a repairable item.
    /// </summary>
    public interface IRepairable
    {
        /// <summary>
        /// Repairs this instance.
        /// </summary>
        void Repair();
    }
}