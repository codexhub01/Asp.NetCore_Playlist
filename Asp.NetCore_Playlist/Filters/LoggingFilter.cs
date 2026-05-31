using Microsoft.AspNetCore.Mvc.Filters;

namespace Asp.NetCore_Playlist.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILogger<LoggingFilter> _logger;

        public LoggingFilter(
            ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(
            ActionExecutingContext context)
        {
            _logger.LogInformation(
                "Action Started");
        }

        public void OnActionExecuted(
            ActionExecutedContext context)
        {
            _logger.LogWarning("Action Ends");
        }
    }
}
