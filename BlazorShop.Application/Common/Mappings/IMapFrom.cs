// <copyright file="IMapFrom.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="profile"></param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
