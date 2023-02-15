// <copyright file="GetClothesQueryHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Queries.ClotheHandler
{
    /// <summary>
    /// Tests for <see cref="GetClothesQueryHandler"/> class.
    /// </summary>
    public class GetClothesQueryHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetClothesQueryHandlerTests"/> class.
        /// </summary>
        public GetClothesQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.ApplicationDbContext = new ApplicationDbContext(options);

            this.SUT = new GetClothesQueryHandler(
                this.ApplicationDbContext,
                this.Logger,
                this.Mapper);
        }

        /// <summary>
        /// Gets the instance of <see cref="GetClothesQueryHandler"/> to use.
        /// </summary>
        private GetClothesQueryHandler SUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="ApplicationDbContext"/> to use.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of  <see cref="ILogger{GetClothesQueryHandler}"/> to use.
        /// </summary>
        private ILogger<GetClothesQueryHandler> Logger { get; } = Mock.Of<ILogger<GetClothesQueryHandler>>();

        /// <summary>
        /// Gets the instance of  <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="GetClothesQueryHandler.Handle(GetClothesQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle()
        {
            var getClothesQuery = Mock.Of<GetClothesQuery>();

            var clothesResponse = new List<ClotheResponse>
            {
                Mock.Of<ClotheResponse>(q =>
                    q.Id == 1 &&
                    q.IsActive == true),
                Mock.Of<ClotheResponse>(q =>
                    q.Id == 2 &&
                    q.IsActive == true),
                Mock.Of<ClotheResponse>(q =>
                    q.Id == 3 &&
                    q.IsActive == true),
            };

            var response = Mock.Of<Result<ClotheResponse>>(x =>
                x.Successful == true &&
                x.Error == null &&
                x.Item == null &&
                x.Items == clothesResponse);

            this.ApplicationDbContext.Clothes.AddRange(new List<Clothe>
            {
                Mock.Of<Clothe>(q =>
                    q.Id == 1 &&
                    q.Description == string.Empty &&
                    q.ImageName == string.Empty &&
                    q.ImagePath == string.Empty &&
                    q.Name == string.Empty &&
                    q.Price == new decimal(new Random().NextDouble()) &&
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

            var result = await this.SUT.Handle(getClothesQuery, default);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
            Assert.Equal(result.Item, response.Item);
            Assert.Equal(result.Items.Count, response.Items.Count);
        }

        /// <summary>
        /// A test for <see cref="GetClothesQueryHandler.Handle(GetClothesQuery, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Result{ClotheResponse}"/> async result.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<Result<ClotheResponse>>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.GetClothesQuery &&
                x.Item == null &&
                x.Items == null);

            var result = await this.SUT.Handle(It.IsAny<GetClothesQuery>(), default);

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
