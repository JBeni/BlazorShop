// <copyright file="TodoItemRecordMap.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using System.Globalization;

using CsvHelper.Configuration;

namespace BlazorShop.Infrastructure.Files.Maps
{
    /// <summary>
    /// A mapping model for files.
    /// </summary>
    public class TodoItemRecordMap : ClassMap<TodoItemResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItemRecordMap"/> class.
        /// </summary>
        public TodoItemRecordMap()
        {
            this.AutoMap(CultureInfo.InvariantCulture);

            // this.Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
