// <copyright file="MappingTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Mappings;
using System.Runtime.Serialization;

namespace BlazorShop.UnitTests.Application.Mappings
{
    /// <summary>
    /// Tests for <see cref=""/> class.
    /// </summary>
    public class MappingTests
    {
        private readonly AutoMapper.IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingTests"/> class.
        /// </summary>
        public MappingTests()
        {
            _configuration = new MapperConfiguration(config =>
                config.AddProfile<MappingProfile>());

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(CartResponse), typeof(Cart))]
        [InlineData(typeof(ClotheResponse), typeof(Clothe))]
        [InlineData(typeof(TodoListResponse), typeof(TodoList))]
        [InlineData(typeof(OrderResponse), typeof(Order))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);

            _mapper.Map(instance, source, destination);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;

            // Type without parameterless constructor
            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
