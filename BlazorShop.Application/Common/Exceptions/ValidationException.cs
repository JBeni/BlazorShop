// <copyright file="ValidationException.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        /// <summary>
        /// .
        /// </summary>
        public IDictionary<string?, string?[]> Errors { get; }

        public ValidationException() : base("One or more validation failures have occurred")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
