using BindOpen.Logging;
using System.Collections.Generic;

namespace BindOpen.Processing
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProblemDetailsExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ProblemDetailsDto> ToProblemDetailsList(this IBdoLog log)
        {
            var list = new List<ProblemDetailsDto>();

            if (log != null)
            {
                foreach (var _event in log.Events(true, EventKinds.Exception, EventKinds.Error))
                {
                    list.Add(new ProblemDetailsDto()
                    {
                        Title = _event.Title,
                        Detail = _event?.Description,
                        StatusCode = _event?.ResultCode
                    });
                }
            }

            return list;
        }
    }
}
