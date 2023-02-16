// <copyright file="CreateClotheCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Application.Handlers.Commands.ClotheHandler
{
    /// <summary>
    /// Tests for <see cref="CreateClotheCommandHandler"/> class.
    /// </summary>
    public class CreateClotheCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClotheCommandHandlerTests"/> class.
        /// </summary>
        public CreateClotheCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new CreateClotheCommandHandler(
                this.ApplicationDbContext,
                this.Logger);
        }

        /// <summary>
        /// Gets the instance of <see cref="CreateClotheCommandHandler"/> to use.
        /// </summary>
        private CreateClotheCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{CreateClotheCommandHandler}"/> to use.
        /// </summary>
        private ILogger<CreateClotheCommandHandler> Logger { get; } = Mock.Of<ILogger<CreateClotheCommandHandler>>();

        /// <summary>
        /// A test for <see cref="CreateClotheCommandHandler.Handle(CreateClotheCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            var createClotheCommand = Mock.Of<CreateClotheCommand>(q =>
                q.Description == string.Empty &&
                q.ImageName == string.Empty &&
                q.ImagePath == string.Empty &&
                q.Name == string.Empty &&
                q.Price == new decimal(new Random().NextDouble()) &&
                q.IsActive == true);

            var clotheEntity = Mock.Of<Clothe>(q =>
                q.Description == createClotheCommand.Description &&
                q.ImageName == createClotheCommand.ImageName &&
                q.ImagePath == createClotheCommand.ImagePath &&
                q.Name == createClotheCommand.Name &&
                q.Price == createClotheCommand.Price &&
                q.IsActive == createClotheCommand.IsActive);

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == null);

            this.ApplicationDbContext.Clothes.Add(clotheEntity);
            await this.ApplicationDbContext.SaveChangesAsync(default);

            var result = await this.SUT.Handle(createClotheCommand, default);

            var clotheEntityDb = await this.ApplicationDbContext.Clothes
                .FirstOrDefaultAsync(x => x.Id == result.EntityId);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);

            Assert.Equal(clotheEntity.Description, clotheEntityDb.Description);
            Assert.Equal(clotheEntity.ImagePath, clotheEntityDb.ImagePath);
            Assert.Equal(clotheEntity.ImageName, clotheEntityDb.ImageName);
            Assert.Equal(clotheEntity.Name, clotheEntityDb.Name);
            Assert.Equal(clotheEntity.Price, clotheEntityDb.Price);
            Assert.Equal(clotheEntity.IsActive, clotheEntityDb.IsActive);
        }

        /// <summary>
        /// A test for <see cref="CreateClotheCommandHandler.Handle(CreateClotheCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.CreateClotheCommand &&
                x.EntityId == 0);

            var result = await this.SUT.Handle(It.IsAny<CreateClotheCommand>(), default);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }

        /// <summary>
        /// Ensure garbage collector for db context and reset the database.
        /// </summary>
        public void Dispose()
        {
            this.ApplicationDbContext.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}
