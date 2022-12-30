// <copyright file="TodoItemState.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Enums
{
    /// <summary>
    /// A enumeration for the todo item states.
    /// </summary>
    public enum TodoItemState
    {
        /// <summary>
        /// The item was not started.
        /// </summary>
        NotStarted,

        /// <summary>
        /// The item is in progress.
        /// </summary>
        InProgress,

        /// <summary>
        /// The item was blocked.
        /// </summary>
        Blocked,

        /// <summary>
        /// The item was completed.
        /// </summary>
        Done,
    }
}
