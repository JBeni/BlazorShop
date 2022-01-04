namespace BlazorShop.WebApi.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            HandleUnknownException(context);
        }

        private static void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = context.Exception.Message ?? "An error occurred while processing your request",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };
            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
