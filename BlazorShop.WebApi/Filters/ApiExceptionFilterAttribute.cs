// <copyright file="ApiExceptionFilterAttribute.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Filters
{
    /// <summary>
    /// An exception model to filter the exception's application.
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiExceptionFilterAttribute"/> class.
        /// </summary>
        public ApiExceptionFilterAttribute()
        {
            this.ExceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), this.HandleValidationException },
            };
        }

        /// <summary>
        /// Gets the instance of the <see cref="IDictionary{Type, Action{ExceptionContext}}"/> to use.
        /// </summary>
        private IDictionary<Type, Action<ExceptionContext>> ExceptionHandlers { get; }

        /// <summary>
        /// The base method to handle the exception.
        /// </summary>
        /// <param name="context">The instance of the <see cref="ExceptionContext"/> to use.</param>
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            this.HandleException(context);
        }

        /// <summary>
        /// Handling the type of the exception.
        /// </summary>
        /// <param name="context">The instance of the <see cref="ExceptionContext"/> to use.</param>
        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (this.ExceptionHandlers.ContainsKey(type))
            {
                this.ExceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                this.HandleInvalidModelStateException(context);
                return;
            }

            this.HandleUnknownException(context);
        }

        /// <summary>
        /// Handle the validation exception.
        /// </summary>
        /// <param name="context">The instance of the <see cref="ExceptionContext"/> to use.</param>
        private void HandleValidationException(ExceptionContext context)
        {
            var exception = (ValidationException)context.Exception;
            var response = new RequestResponse
            {
                Successful = false,
                Error = $"Fluent Handlers Validations. {exception.Message}. {exception.InnerException?.Message}",
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
        /// Handle the invalid model state exception.
        /// </summary>
        /// <param name="context">The instance of the <see cref="ExceptionContext"/> to use.</param>
        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var response = new RequestResponse
            {
                Successful = false,
                Error = $"Invalid Model State. {context.Exception.Message}. {context.Exception?.InnerException?.Message}",
            };

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// Handle the unknown type of exception.
        /// </summary>
        /// <param name="context">The instance of the <see cref="ExceptionContext"/> to use.</param>
        private void HandleUnknownException(ExceptionContext context)
        {
            var response = new RequestResponse
            {
                Successful = false,
                Error = $"An error occurred while processing your request. {context.Exception.Message}. {context.Exception?.InnerException?.Message}",
            };

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }
    }
}
