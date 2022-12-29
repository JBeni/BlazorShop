// <copyright file="ValidationException.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Exceptions
{
    /// <summary>
    /// A validation class to validate the commands & queries.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// A list of validation errors.
        /// </summary>
        public IDictionary<string?, string?[]> Errors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        public ValidationException() : base("One or more validation failures have occurred")
        {
            Errors = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="failures">The fluent validation failures.</param>
        public ValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
