// <copyright file="CsvFileBuilderTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Infrastructure.Files;

namespace BlazorShop.UnitTests.Infrastructure
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.Infrastructure.Files.CsvFileBuilder"/> class.
    /// </summary>
    public class CsvFileBuilderTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsvFileBuilderTests"/> class.
        /// </summary>
        public CsvFileBuilderTests()
        {
            this.CsvFileBuilder = new CsvFileBuilder();
        }

        /// <summary>
        /// Gets the instance of the <see cref="CsvFileBuilder"/> to use.
        /// </summary>
        private CsvFileBuilder CsvFileBuilder { get; }

        /// <summary>
        /// A test for <see cref="CsvFileBuilder.BuildTodoItemsFile(IEnumerable{TodoItemResponse})"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task BuildTodoItemsFile()
        {
            await Task.CompletedTask;
        }
    }
}
