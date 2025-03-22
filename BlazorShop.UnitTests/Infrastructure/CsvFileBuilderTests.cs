// <copyright file="CsvFileBuilderTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.TodoItems;
using BlazorShop.Infrastructure.Files;
using CsvHelper;
using System.Globalization;

namespace BlazorShop.UnitTests.Infrastructure
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.Infrastructure.Files.CsvFileBuilder"/> class.
    /// </summary>
    public class CsvFileBuilderTests
    {
        private readonly CsvFileBuilder _csvFileBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvFileBuilderTests"/> class.
        /// </summary>
        public CsvFileBuilderTests()
        {
            _csvFileBuilder = new CsvFileBuilder();
        }

        [Fact]
        public async Task BuildTodoItemsFile_WithValidData_ReturnsByteArray()
        {
            // Arrange
            var todoItems = new List<TodoItemResponse>
            {
                new TodoItemResponse
                {
                    Id = 1,
                    ListId = 1,
                    Title = "Test Todo",
                    Note = "Test Note",
                    Priority = 1,
                    Reminder = DateTime.Now,
                    Done = false,
                    Created = DateTime.Now,
                    CreatedBy = "Test User",
                    LastModified = DateTime.Now,
                    LastModifiedBy = "Test User"
                }
            };

            // Act
            var result = await _csvFileBuilder.BuildTodoItemsFile(todoItems);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length > 0);

            // Verify CSV content
            using var memoryStream = new MemoryStream(result);
            using var streamReader = new StreamReader(memoryStream);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

            var records = csvReader.GetRecords<TodoItemResponse>().ToList();
            
            Assert.Single(records);
            var record = records.First();
            Assert.Equal(1, record.Id);
            Assert.Equal("Test Todo", record.Title);
            Assert.Equal("Test Note", record.Note);
        }

        [Fact]
        public async Task BuildTodoItemsFile_WithEmptyList_ReturnsEmptyFile()
        {
            // Arrange
            var todoItems = new List<TodoItemResponse>();

            // Act
            var result = await _csvFileBuilder.BuildTodoItemsFile(todoItems);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length > 0); // Should contain at least headers
        }

        [Fact]
        public async Task BuildTodoItemsFile_WithNullList_ThrowsArgumentNullException()
        {
            // Arrange
            IEnumerable<TodoItemResponse> todoItems = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => 
                _csvFileBuilder.BuildTodoItemsFile(todoItems));
        }

        [Fact]
        public async Task BuildTodoItemsFile_WithMultipleItems_ContainsAllItems()
        {
            // Arrange
            var todoItems = new List<TodoItemResponse>
            {
                new TodoItemResponse { Id = 1, Title = "First Todo", Note = "Note 1" },
                new TodoItemResponse { Id = 2, Title = "Second Todo", Note = "Note 2" },
                new TodoItemResponse { Id = 3, Title = "Third Todo", Note = "Note 3" }
            };

            // Act
            var result = await _csvFileBuilder.BuildTodoItemsFile(todoItems);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length > 0);

            using var memoryStream = new MemoryStream(result);
            using var streamReader = new StreamReader(memoryStream);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

            var records = csvReader.GetRecords<TodoItemResponse>().ToList();
            
            Assert.Equal(3, records.Count);
            Assert.Equal("First Todo", records[0].Title);
            Assert.Equal("Second Todo", records[1].Title);
            Assert.Equal("Third Todo", records[2].Title);
        }
    }
}
