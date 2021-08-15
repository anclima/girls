using System;

using Microsoft.AspNetCore.Mvc.Filters;

namespace Generics.Girls.Filters
{
    public class FileFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var fileType = context.HttpContext.Request.Form.Files[0].ContentType;
            if (!fileType.Equals("text/csv"))
                context.HttpContext.Response.StatusCode = 415;
        }

        public void OnActionExecuted(ActionExecutedContext context){}
    }
}
