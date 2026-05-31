using Microsoft.AspNetCore.Mvc.Filters;

namespace Asp.NetCore_Playlist.Filters
{
    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(
       ActionExecutingContext context)
        {
            Console.WriteLine(
                "Before Action Execution");
        }

        public override void OnActionExecuted(
            ActionExecutedContext context)
        {
            Console.WriteLine(
                "After Action Execution");
        }
    }
}
