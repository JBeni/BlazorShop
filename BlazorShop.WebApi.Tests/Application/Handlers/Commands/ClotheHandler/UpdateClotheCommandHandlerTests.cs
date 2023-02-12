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
    public class UpdateClotheCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateClotheCommandHandlerTests"/> class.
        /// </summary>
        public UpdateClotheCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new UpdateClotheCommandHandler(
                this.ApplicationDbContext,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="UpdateClotheCommandHandler"/> to use.
        /// </summary>
        private UpdateClotheCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

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
                q.Id == 1 &&
                q.Description == "Update User" &&
                q.ImageName == "UpdateTest" &&
                q.ImagePath == "UpdateTest" &&
                q.Name == "UpdateTest" &&
                q.Price == new decimal(new Random().NextDouble()));

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
            Assert.Equal(clotheEntityDb.Description, updateClotheCommand.Description);
            Assert.Equal(clotheEntityDb.ImageName, updateClotheCommand.ImageName);
            Assert.Equal(clotheEntityDb.ImagePath, updateClotheCommand.ImagePath);
            Assert.Equal(clotheEntityDb.Name, updateClotheCommand.Name);
            Assert.Equal(clotheEntityDb.Price, updateClotheCommand.Price);
            Assert.True(clotheEntityDb.IsActive);
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
        public void Dispose()
        {
            this.ApplicationDbContext.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}
