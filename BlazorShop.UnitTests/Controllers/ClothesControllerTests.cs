// <copyright file="ClothesControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="ClothesController"/> class.
    /// </summary>
    public class ClothesControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClothesControllerTests"/> class.
        /// </summary>
        public ClothesControllerTests()
        {
            this.ClothesController = new ClothesController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="ClothesController"/> to use.
        /// </summary>
        private ClothesController ClothesController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="ClothesController.CreateClothe(CreateClotheCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateClothe()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ClothesController.UpdateClothe(UpdateClotheCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateClothe()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ClothesController.DeleteClothe(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteClothe()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ClothesController.GetClothe(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetClothe()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ClothesController.GetClothes()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetClothes()
        {
            await Task.CompletedTask;
        }
    }
}
