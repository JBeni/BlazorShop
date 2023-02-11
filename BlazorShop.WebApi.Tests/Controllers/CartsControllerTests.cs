// <copyright file="CartsControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.WebApi.Controllers;
using BlazorShop.WebApi.Tests.Controllers.Utils;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="WebApi.Controllers.CartsController"/> class.
    /// </summary>
    public class CartsControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartsControllerTests"/> class.
        /// </summary>
        public CartsControllerTests()
        {
        }

        /// <summary>
        /// Gets a mock instance of the <see cref="ISender"/> to use.
        /// </summary>
        private ISender Mediator { get; } = Mock.Of<ISender>();

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> mock to use.
        /// </summary>
        private IServiceProvider Services { get; } = Mock.Of<IServiceProvider>();

        /// <summary>
        /// Gets the mock <see cref="IHttpContextAccessor"/>.
        /// </summary>
        private Mock<IHttpContextAccessor> HttpContextAccessor { get; } = new Mock<IHttpContextAccessor>();

        /// <summary>
        /// Gets the <see cref="WebApi.Controllers.CartsController"/> instance to use.
        /// </summary>
        private CartsController CartsController { get; }

        private HttpContextISenderFixture Fixture { get; } = Mock.Of<HttpContextISenderFixture>();

        /// <summary>
        /// A test for <see cref="CartsController.CreateCart(CreateCartCommand)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task CreateCart()
        {
            var command = Mock.Of<CreateCartCommand>(x =>
                x.UserId == new Random().Next() &&
                x.ClotheId == new Random().Next() &&
                x.Name == "Test Cart" &&
                x.Price == new decimal(new Random().NextDouble()) &&
                x.Amount == new Random().Next());

            var mediator = this.Fixture.Mediator;
            var httpContext = this.Fixture.HttpContextAccessor.HttpContext;

            // Act
            var controller = new CartsController();
            controller.ControllerContext.HttpContext = httpContext;
            var result = await controller.CreateCart(command);

            //var serviceScopeFactory = Mock.Of<IServiceScopeFactory>();
            //var scope = Mock.Of<IServiceScope>();
            //var httpContextAccessor = Mock.Of<IHttpContextAccessor>();

            //Mock.Get(scope).Setup(x => x.ServiceProvider)
            //    .Returns(this.Services);
            //Mock.Get(serviceScopeFactory).Setup(s => s.CreateScope())
            //    .Returns(scope);

            //Mock.Get(this.Services).Setup(s => s.GetService(typeof(IServiceScopeFactory)))
            //    .Returns(serviceScopeFactory);
            //Mock.Get(this.Services).Setup(s => s.GetService(typeof(ISender)))
            //    .Returns(this.Mediator);

            //var httpContext = new Mock<HttpContext>();
            //httpContext.SetupGet(c => c.RequestServices)
            //    .Returns(this.Services);

            //this.HttpContextAccessor.SetupGet(s => s.HttpContext).Returns(httpContext.Object);

            //var cartsController = new TestCartsController(this.HttpContextAccessor.Object);

            //var response = await CartsController.CreateCart(command);
            //var result = Assert.IsAssignableFrom<OkObjectResult>(response);
            //var requestResponse = Assert.IsAssignableFrom<RequestResponse>(result.Value);

            //Assert.IsType<OkObjectResult>(response);
            //Assert.IsType<RequestResponse>(result);

            //Assert.True(requestResponse.Successful);
            //Assert.Null(requestResponse.Error);
            //Assert.NotEqual(0, requestResponse.EntityId);
        }

        /// <summary>
        /// A test for <see cref="CartsController.DeleteAllCarts(int)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task DeleteAllCarts()
        {
        }

        /// <summary>
        /// A test for <see cref="CartsController.DeleteCart(int, int)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task DeleteCart()
        {
        }

        /// <summary>
        /// A test for <see cref="CartsController.GetCart(int, int)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task GetCart()
        {
        }

        /// <summary>
        /// A test for <see cref="CartsController.GetCarts(int)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task GetCarts()
        {
        }

        /// <summary>
        /// A test for <see cref="CartsController.GetCartsCount(int)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task GetCartsCount()
        {
        }

        /// <summary>
        /// A test for <see cref="CartsController.UpdateCart(UpdateCartCommand)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task UpdateCart()
        {
        }
    }

    public class TestCartsController : ApiBaseController
    {
        /// <summary>
        /// Gets the <see cref="ISender"/> instance to use.
        /// </summary>
        private readonly ISender mediator = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCartsController"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The <see cref="IHttpContextAccessor"/> instance to use.</param>
        public TestCartsController(IHttpContextAccessor httpContextAccessor)
        {
            this.mediator = httpContextAccessor.HttpContext.RequestServices.GetService<ISender>();
        }

        /// <summary>
        /// Gets the <see cref="ISender"/> instance to use.
        /// </summary>
        protected new ISender Mediator => this.mediator;
    }
}
