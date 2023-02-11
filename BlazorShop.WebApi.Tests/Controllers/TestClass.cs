// <copyright file="TestClass.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Handlers.Commands.CartHandler;
using BlazorShop.WebApi.Controllers;
using BlazorShop.WebApi.Tests.Controllers.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BlazorShop.WebApi.Tests.Controllers
{
    public class HttpContextMediatRFixture : IDisposable
    {
        public HttpContext HttpContext { get; private set; }

        public HttpContextMediatRFixture()
        {
            var services = new ServiceCollection();

            // services.AddTransient<IRequestHandler<CreateCartCommand, RequestResponse>>();

            // services.AddScoped<CreateCartCommandHandler>();

            services.AddMediatR(typeof(CreateCartCommand).Assembly);
            services.AddMediatR(typeof(IApplicationDbContext).Assembly);
            services.AddMediatR(typeof(CreateCartCommandHandler).Assembly);

            var httpContext = new DefaultHttpContext();
            httpContext.RequestServices = services.BuildServiceProvider();

            this.HttpContext = httpContext;
        }

        public void Dispose()
        {
        }
    }

    [CollectionDefinition("MediatR Collection")]
    public class MediatRCollection : ICollectionFixture<HttpContextISenderFixture>
    {
    }

    //[Collection("MediatR Collection")]
    //public class ApiBaseControllerTests
    //{
    //    private readonly HttpContextMediatRFixture _fixture;

    //    public ApiBaseControllerTests(HttpContextMediatRFixture fixture)
    //    {
    //        _fixture = fixture;
    //    }

    //    [Fact]
    //    public void Mediator_GetsCorrectInstance()
    //    {
    //        // Arrange
    //        var httpContext = _fixture.HttpContextAccessor.HttpContext;
    //        var controller = new ApiBaseController();
    //        controller.ControllerContext.HttpContext = httpContext;

    //        // Act
    //        var mediator = controller.Mediator;

    //        // Assert
    //        Assert.NotNull(mediator);
    //        Assert.IsType<ISender>(mediator);
    //    }
    //}

    //    [Collection("MediatR Collection")]

    /// <summary>
    /// Test.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    public class CartsControllerTestss : IClassFixture<HttpContextMediatRFixture>
#pragma warning restore SA1402 // File may only contain a single type
    {
        private readonly HttpContextMediatRFixture fixture;

        public CartsControllerTestss(HttpContextMediatRFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async void CreateCart_ReturnsOkResult()
        {
            // Arrange
            var controller = new CartsController();
            controller.ControllerContext.HttpContext = this.fixture.HttpContext;
            var command = new CreateCartCommand();

            // Act
            var result = await controller.CreateCart(command);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        //[Fact]
        //public async void CreateCart_ReturnsBadRequestResult()
        //{
        //    // Arrange
        //    var mediator = _fixture.Mediator;
        //    var httpContext = _fixture.HttpContextAccessor.HttpContext;

        //    var command = new CreateCartCommand();
        //    var failureResult = new Result();
        //    failureResult.Successful = false;
        //    mediator
        //        .Setup(x => x.Send(command, default))
        //        .ReturnsAsync(failureResult);

        //    // Act
        //    var controller = new CartsController();
        //    controller.ControllerContext.HttpContext = httpContext;
        //    var result = await controller.CreateCart(command);

        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(result);
        //    var badRequestResult = (BadRequestObjectResult)result;
        //    Assert.Equal(failureResult, badRequestResult.Value);
        //}
    }
}
