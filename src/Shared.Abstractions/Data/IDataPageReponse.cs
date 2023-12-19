namespace BindOpen.Labs.Shared.Data
{
    /// <summary>
    /// This class represents the data page form request DTO.
    /// </summary>
    public interface IDataPageReponse : IDataPageRequest
    {
        #region Properties

        /// <summary>
        /// The count.
        /// </summary>
        int? TotalCount { get; set; }

        #endregion
    }
}