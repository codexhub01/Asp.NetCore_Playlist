using Microsoft.AspNetCore.Mvc.Filters;

namespace Asp.NetCore_Playlist.Filters
{
    public class MyResultFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(
            ResultExecutingContext context)
        {
            Console.WriteLine("Before Result");
        }

        public override void OnResultExecuted(
            ResultExecutedContext context)
        {
            Console.WriteLine("After Result");
        }
    }
}
