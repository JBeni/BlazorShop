// <copyright file="ICsvFileBuilder.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A service to provide Csv File features.
    /// </summary>
    public interface ICsvFileBuilder
    {
        /// <summary>
        /// Build a file.
        /// </summary>
        /// <param name="records">The data to be converted into file.</param>
        /// <returns>The request response.</returns>
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemResponse> records);
    }
}
