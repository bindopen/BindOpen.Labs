using BindOpen.Kernel.Logging;
using BindOpen.Labs.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BindOpen.Labs.Shared.AspNetCore.Diagnostics
{
    /// <summary>
    /// 
    /// </summary>
    public static class BdoLogExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ProblemDetailsDto> ToProblemDetailsList(this IBdoLog log)
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

        /// <summary>
        /// 
        /// </summary>
        public static JsonResult GetJsonResult(this object result, IBdoLog log = null)
        {
            JsonResult jsonResult;
            if (log?.HasErrorsOrExceptions() == true)
            {
                var statusCode =
                    log.HasException() ?
                    StatusCodes.Status500InternalServerError :
                    StatusCodes.Status400BadRequest;

                jsonResult = new JsonResult(log.ToProblemDetailsList())
                {
                    StatusCode = statusCode
                };
            }
            else
            {
                jsonResult = new JsonResult(result);
            }

            return jsonResult;
        }
    }
}
