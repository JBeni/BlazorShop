// <copyright file="ValidationExceptionTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Exceptions;
using BlazorShop.Application.Common.Mappings;
using BlazorShop.UnitTests.Application.Mappings;
using FluentValidation.Results;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.UnitTests.Application.Exceptions
{
    /// <summary>
    /// Tests for <see cref=""/> class.
    /// </summary>
    public class ValidationExceptionTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationExceptionTests"/> class.
        /// </summary>
        public ValidationExceptionTests()
        {
        }

        [Fact]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidationException().Errors;

            // actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

        [Fact]
        public void SingleValidationFailureCreatesASingleElementErrorDictionary()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Age", "must be over 18"),
            };

            var actual = new ValidationException(failures).Errors;

            // actual.Keys.Should().BeEquivalentTo(new string[] { "Age" });
            // actual["Age"].Should().BeEquivalentTo(new string[] { "must be over 18" });
        }

        [Fact]
        public void MulitpleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Age", "must be 18 or older"),
                new ValidationFailure("Age", "must be 25 or younger"),
                new ValidationFailure("Password", "must contain at least 8 characters"),
                new ValidationFailure("Password", "must contain a digit"),
                new ValidationFailure("Password", "must contain upper case letter"),
                new ValidationFailure("Password", "must contain lower case letter"),
            };

            var actual = new ValidationException(failures).Errors;

            //actual.Keys.Should().BeEquivalentTo(new string[] { "Password", "Age" });

            //actual["Age"].Should().BeEquivalentTo(new string[]
            //{
            //    "must be 25 or younger",
            //    "must be 18 or older",
            //});

            //actual["Password"].Should().BeEquivalentTo(new string[]
            //{
            //    "must contain lower case letter",
            //    "must contain upper case letter",
            //    "must contain at least 8 characters",
            //    "must contain a digit",
            //});
        }
    }
}
