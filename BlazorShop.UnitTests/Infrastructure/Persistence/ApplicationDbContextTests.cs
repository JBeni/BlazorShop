// <copyright file="ApplicationDbContextTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Domain.Entities;
using BlazorShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorShop.UnitTests.Infrastructure.Persistence
{
    /// <summary>
    /// Tests for <see cref="ApplicationDbContext"/> class.
    /// </summary>
    public class ApplicationDbContextTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly DbContextOptions<ApplicationDbContext> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContextTests"/> class.
        /// </summary>
        public ApplicationDbContextTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"BlazorShopTest_{Guid.NewGuid()}")
                .Options;

            _context = new ApplicationDbContext(_options);
        }

        [Fact]
        public async Task SaveChangesAsync_SetsAuditProperties()
        {
            // Arrange
            var todoItem = new TodoItem
            {
                Title = "Test Item",
                ListId = 1,
                Note = "Test Note",
                Priority = 1,
                Reminder = DateTime.Now
            };

            // Act
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            // Assert
            Assert.NotEqual(default, todoItem.Created);
            Assert.NotEqual(default, todoItem.LastModified);
            Assert.NotNull(todoItem.CreatedBy);
            Assert.NotNull(todoItem.LastModifiedBy);
        }

        [Fact]
        public void DbContext_SetsCorrectTableNames()
        {
            // Assert
            Assert.Equal("TodoItems", _context.Model.FindEntityType(typeof(TodoItem)).GetTableName());
            Assert.Equal("TodoLists", _context.Model.FindEntityType(typeof(TodoList)).GetTableName());
            Assert.Equal("Users", _context.Model.FindEntityType(typeof(User)).GetTableName());
        }

        [Fact]
        public async Task DbContext_EnforcesUniqueConstraints()
        {
            // Arrange
            var user1 = new User { Email = "test@example.com", UserName = "test1" };
            var user2 = new User { Email = "test@example.com", UserName = "test2" };

            // Act
            _context.Users.Add(user1);
            await _context.SaveChangesAsync();

            _context.Users.Add(user2);

            // Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => _context.SaveChangesAsync());
        }

        [Fact]
        public async Task DbContext_CascadeDeletesBehavior()
        {
            // Arrange
            var todoList = new TodoList { Title = "Test List" };
            var todoItem = new TodoItem { Title = "Test Item", ListId = todoList.Id };

            _context.TodoLists.Add(todoList);
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            // Act
            _context.TodoLists.Remove(todoList);
            await _context.SaveChangesAsync();

            // Assert
            Assert.Empty(await _context.TodoItems.Where(i => i.ListId == todoList.Id).ToListAsync());
        }

        [Fact]
        public void DbContext_ConfiguresRelationships()
        {
            // Arrange & Act
            var todoListEntity = _context.Model.FindEntityType(typeof(TodoList));
            var todoItemEntity = _context.Model.FindEntityType(typeof(TodoItem));

            // Assert
            var todoListToItemsNavigation = todoListEntity
                .GetNavigations()
                .First(n => n.Name == "Items");

            Assert.NotNull(todoListToItemsNavigation);
            Assert.Equal("ListId", todoListToItemsNavigation.ForeignKey.Properties.First().Name);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
