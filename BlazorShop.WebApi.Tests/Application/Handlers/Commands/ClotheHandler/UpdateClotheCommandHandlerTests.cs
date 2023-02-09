// <copyright file="UpdateClotheCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Handlers.Commands.ClotheHandler;
using BlazorShop.Infrastructure.Persistence;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateClotheCommandHandler"/> class.
    /// </summary>
    public class UpdateClotheCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateClotheCommandHandlerTests"/> class.
        /// </summary>
        public UpdateClotheCommandHandlerTests()
        {
            this.ApplicationDbContext = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: $"ApplicationDbContext-Core")
                    .Options);

            this.SUT = new UpdateClotheCommandHandler(
                this.ApplicationDbContext,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="UpdateClotheCommandHandler"/> to use.
        /// </summary>
        private UpdateClotheCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="BlazorShop.Infrastructure.Persistence.ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; }

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{UpdateClotheCommandHandler}"/> to use.
        /// </summary>
        private ILogger<UpdateClotheCommandHandler> Logger { get; } = Mock.Of<ILogger<UpdateClotheCommandHandler>>();

        /// <summary>
        /// A test for <see cref="UpdateClotheCommandHandler.Handle(UpdateClotheCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            var updateClotheCommand = Mock.Of<UpdateClotheCommand>(q =>
                q.Id == new Random().Next(1, 10));

            var clotheEntity = Mock.Of<Clothe>(q =>
                q.Id == updateClotheCommand.Id &&
                q.Description == "Test User" &&
                q.ImageName == "Test" &&
                q.ImagePath == "Test" &&
                q.Name == "Test" &&
                q.Price == new decimal(new Random().NextDouble()) &&
                q.IsActive == true);

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == null &&
                x.EntityId == updateClotheCommand.Id);

            this.ApplicationDbContext.Clothes.Add(clotheEntity);
            await this.ApplicationDbContext.SaveChangesAsync(default);

            var result = await this.SUT.Handle(updateClotheCommand, default);

            var clotheEntityDb = await this.ApplicationDbContext.Clothes
                .FirstOrDefaultAsync(x => x.Id == result.EntityId);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);

            Assert.NotNull(clotheEntityDb);
            Assert.False(clotheEntityDb.IsActive);
        }

        /// <summary>
        /// A test for <see cref="UpdateClotheCommandHandler.Handle(UpdateClotheCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.UpdateClotheCommand);

            var result = await this.SUT.Handle(It.IsAny<UpdateClotheCommand>(), default);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }

        /// <summary>
        /// Ensure garbage collector for db context.
        /// </summary>
        //public void Dispose()
        //{
        //    this.Dispose(disposing: true);
        //    GC.SuppressFinalize(this);
        //}

        public void Dispose()
        {
            this.ApplicationDbContext.Database.EnsureDeleted();
        }

        /// <summary>
        /// Ensure the context is reset.
        /// </summary>
        /// <param name="disposing">A value indicating whether the class is disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            this.ApplicationDbContext.Database.EnsureDeleted();
        }
    }
}
