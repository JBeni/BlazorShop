﻿// <copyright file="DeleteClotheCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteClotheCommandHandler"/> class.
    /// </summary>
    public class DeleteClotheCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteClotheCommandHandlerTests"/> class.
        /// </summary>
        public DeleteClotheCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new DeleteClotheCommandHandler(
                this.ApplicationDbContext,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="DeleteClotheCommandHandler"/> to use.
        /// </summary>
        private DeleteClotheCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{DeleteClotheCommandHandler}"/> to use.
        /// </summary>
        private ILogger<DeleteClotheCommandHandler> Logger { get; } = Mock.Of<ILogger<DeleteClotheCommandHandler>>();

        /// <summary>
        /// A test for <see cref="DeleteClotheCommandHandler.Handle(DeleteClotheCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            var deleteClotheCommand = Mock.Of<DeleteClotheCommand>(q =>
                q.Id == new Random().Next(1, 10));

            var clotheEntity = Mock.Of<Clothe>(q =>
                q.Id == deleteClotheCommand.Id &&
                q.Description == "Test User" &&
                q.ImageName == "Test" &&
                q.ImagePath == "Test" &&
                q.Name == "Test" &&
                q.Price == new decimal(new Random().NextDouble()) &&
                q.IsActive == true);

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == null &&
                x.EntityId == deleteClotheCommand.Id);

            this.ApplicationDbContext.Clothes.Add(clotheEntity);
            await this.ApplicationDbContext.SaveChangesAsync(default);

            var result = await this.SUT.Handle(deleteClotheCommand, default);

            var clotheEntityDb = await this.ApplicationDbContext.Clothes
                .FirstOrDefaultAsync(x => x.Id == result.EntityId);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);

            Assert.NotNull(clotheEntityDb);
            Assert.False(clotheEntityDb.IsActive);
        }

        /// <summary>
        /// A test for <see cref="DeleteClotheCommandHandler.Handle(DeleteClotheCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.DeleteClotheCommand);

            var result = await this.SUT.Handle(It.IsAny<DeleteClotheCommand>(), default);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }

        /// <summary>
        /// Ensure garbage collector for db context.
        /// </summary>
        public void Dispose()
        {
            this.ApplicationDbContext.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}
