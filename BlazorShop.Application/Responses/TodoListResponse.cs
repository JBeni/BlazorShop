// <copyright file="TodoListResponse.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A TodoList response model.
    /// </summary>
    public class TodoListResponse : IMapFrom<TodoList>
    {
        /// <summary>
        /// The id of the list.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the list.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The items of the list.
        /// </summary>
        public List<TodoItemResponse> Items { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoList, TodoListResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(x => x.Items, opt => opt.MapFrom(s => s.Items));
        }
    }
}
