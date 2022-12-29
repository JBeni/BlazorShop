// <copyright file="IMapFrom.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Mappings
{
    /// <summary>
    /// A custom mapping service.
    /// </summary>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Converting an object to another type, DAL to BLL.
        /// </summary>
        /// <param name="profile">The profile setting to use when mapping objects.</param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
