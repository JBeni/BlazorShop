// <copyright file="JwtTokenParserTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.WebClient.Auth
{
    /// <summary>
    /// Tests for <see cref="JwtTokenParser"/> class.
    /// </summary>
    public class JwtTokenParserTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenParserTests"/> class.
        /// </summary>
        public JwtTokenParserTests()
        {
        }

        /// <summary>
        /// A test for <see cref="JwtTokenParser.ParseClaimsFromJwt(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ParseClaimsFromJwt()
        {
            await Task.CompletedTask;
        }
    }
}
