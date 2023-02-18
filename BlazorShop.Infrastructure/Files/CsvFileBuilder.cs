// <copyright file="CsvFileBuilder.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using System.Globalization;

using BlazorShop.Infrastructure.Files.Maps;
using CsvHelper;

namespace BlazorShop.Infrastructure.Files
{
    /// <summary>
    /// An implementation of the <see cref="ICsvFileBuilder"/> class.
    /// </summary>
    public class CsvFileBuilder : ICsvFileBuilder
    {
        /// <inheritdoc/>
        public byte[] BuildTodoItemsFile(IEnumerable<TodoItemResponse> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
