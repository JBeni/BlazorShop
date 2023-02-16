// <copyright file="GetClotheByIdQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Queries.ClotheHandler
{
    /// <summary>
    /// Tests for <see cref="GetClotheByIdQueryHandler"/> class.
    /// </summary>
    public class GetClotheByIdQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetClotheByIdQueryHandlerTests"/> class.
        /// </summary>
        public GetClotheByIdQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetClotheByIdQueryHandler(
                this.ApplicationDbContext,
                this.Logger,
                this.Mapper);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetClotheByIdQueryHandler"/> to use.
        /// </summary>
        private GetClotheByIdQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetClotheByIdQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetClotheByIdQueryHandler> Logger { get; } = Mock.Of<ILogger<GetClotheByIdQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetClotheByIdQueryHandler.Handle(GetClotheByIdQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            var getClotheByIdQuery = Mock.Of<GetClotheByIdQuery>(q => q.Id == 1);

            var clotheResponse = Mock.Of<ClotheResponse>(q =>
                q.Id == 1 &&
                q.Description == string.Empty &&
                q.Name == string.Empty &&
                q.Amount == 0 &&
                q.ImageName == string.Empty &&
                q.ImagePath == string.Empty &&
                q.Price == 0 &&
                q.IsActive == true);

            var response = Mock.Of<Result<ClotheResponse>>(x =>
                x.Successful == true &&
                x.Error == null &&
                x.Item == clotheResponse &&
                x.Items == null);

            this.ApplicationDbContext.Clothes.AddRange(new List<Clothe>
            {
                Mock.Of<Clothe>(q =>
                    q.Id == 1 &&
                    q.Description == string.Empty &&
                    q.ImageName == string.Empty &&
                    q.ImagePath == string.Empty &&
                    q.Name == string.Empty &&
                    q.Price == 0 &&
                    q.IsActive == true),
                Mock.Of<Clothe>(q =>
                    q.Id == 2 &&
                    q.Description == string.Empty &&
                    q.ImageName == string.Empty &&
                    q.ImagePath == string.Empty &&
                    q.Name == string.Empty &&
                    q.Price == new decimal(new Random().NextDouble()) &&
                    q.IsActive == true),
                Mock.Of<Clothe>(q =>
                    q.Id == 3 &&
                    q.Description == string.Empty &&
                    q.ImageName == string.Empty &&
                    q.ImagePath == string.Empty &&
                    q.Name == string.Empty &&
                    q.Price == new decimal(new Random().NextDouble()) &&
                    q.IsActive == true),
            });
            await this.ApplicationDbContext.SaveChangesAsync(default);

            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<Clothe, ClotheResponse>());
            Mock.Get(this.Mapper)
                .Setup(x => x.ConfigurationProvider)
                .Returns(configuration.CreateMapper().ConfigurationProvider);

            var result = await this.SUT.Handle(getClotheByIdQuery, default);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
            Assert.Equal(result.Items, response.Items);

            Assert.Equal(result.Item.Description, response.Item.Description);
            Assert.Equal(result.Item.Name, response.Item.Name);
            Assert.Equal(result.Item.Amount, response.Item.Amount);
            Assert.Equal(result.Item.Price, response.Item.Price);
            Assert.Equal(result.Item.ImagePath, response.Item.ImagePath);
            Assert.Equal(result.Item.ImageName, response.Item.ImageName);
            Assert.Equal(result.Item.IsActive, response.Item.IsActive);
        }

        /// <summary>
        /// A test for <see cref="GetClotheByIdQueryHandler.Handle(GetClotheByIdQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<Result<ClotheResponse>>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.GetClotheByIdQuery &&
                x.Item == null &&
                x.Items == null);

            var result = await this.SUT.Handle(It.IsAny<GetClotheByIdQuery>(), default);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
            Assert.Equal(result.Item, response.Item);
            Assert.Equal(result.Items, response.Items);
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
