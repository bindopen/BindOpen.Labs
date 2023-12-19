using BindOpen.Labs.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// This class represents a Http response exception filter.
    /// </summary>
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        /// <summary>
        /// The order of this instance.
        /// </summary>
        public int Order { get; set; } = int.MaxValue - 10;

        /// <summary>
        /// Executes when action is executing.
        /// </summary>
        /// <param name="context">The context to consider.</param>
        public void OnActionExecuting(ActionExecutingContext context) { }


        /// <summary>
        /// Executes when action is executed.
        /// </summary>
        /// <param name="context">The context to consider.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(exception.Value)
                {
                    StatusCode = exception.Status,
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
