namespace BlazorShop.WebApi.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            HandleException(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }
            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private void HandleValidationException(ExceptionContext context)
        {
            var exception = (ValidationException)context.Exception;
            var response = new RequestResponse
            {
                Successful = false,
                Error = $"Fluent Handlers Validations. {exception.Message}. {exception.InnerException?.Message}"
            };
            foreach (var item in exception.Errors)
            {
                foreach (var value in item.Value)
                {
                    response.Error += $"{value}. ";
                }
            }

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var response = new RequestResponse
            {
                Successful = false,
                Error = $"Invalid Model State. {context.Exception.Message}. {context.Exception?.InnerException?.Message}"
            };

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private void HandleUnknownException(ExceptionContext context)
        {
            var response = new RequestResponse
            {
                Successful = false,
                Error = $"An error occurred while processing your request. {context.Exception.Message}. {context.Exception?.InnerException?.Message}"
            };

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }
    }
}
