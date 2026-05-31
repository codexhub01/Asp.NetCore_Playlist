using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Asp.NetCore_Playlist.Filters
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(
        ExceptionContext context)
        {
            context.Result =
                new ContentResult
                {
                    Content = "Error Occurred"
                };

            context.ExceptionHandled = true;
        }
    }
}
