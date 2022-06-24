// <copyright file="TodoItemResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    public class TodoItemResponse : IMapFrom<TodoItem>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TodoItemPriority Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TodoItemState State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TodoListResponse List { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoItem, TodoItemResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.ListId, opt => opt.MapFrom(s => s.List.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(x => x.Note, opt => opt.MapFrom(s => s.Note))
                .ForMember(x => x.Priority, opt => opt.MapFrom(s => s.Priority))
                .ForMember(x => x.State, opt => opt.MapFrom(s => s.State))
                .ForMember(x => x.Done, opt => opt.MapFrom(s => s.Done))
                .ForMember(x => x.List, opt => opt.MapFrom(s => s.List));
        }
    }
}
