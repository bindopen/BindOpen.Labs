using BindOpen.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BindOpen.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static class JsonResultExtension
    {
        /// <summary>
        /// 
        /// </summary>
        public static JsonResult ToJsonResult(this object result, IBdoLog log = null)
        {
            JsonResult jsonResult;
            if (log?.HasErrorOrException() == true)
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
