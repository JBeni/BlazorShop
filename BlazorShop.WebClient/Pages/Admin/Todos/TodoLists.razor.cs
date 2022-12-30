// <copyright file="TodoLists.razor.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Pages.Admin.Todos
{
    /// <summary>
    /// The todo list model.
    /// </summary>
    public partial class TodoLists
    {
        /// <summary>
        /// The instance of the <see cref="TodoListResponse"/> to use.
        /// </summary>
        private TodoListResponse newTodoList = new ();

        /// <summary>
        /// Gets or Sets the instance of the <see cref="TodoState"/> to use.
        /// </summary>
        [CascadingParameter]
        public TodoState State { get; set; }

        /// <summary>
        /// Gets or Sets the instance of the <see cref="ElementReference"/> to use.
        /// </summary>
        private ElementReference TitleInput { get; set; }

        /// <summary>
        /// Gets or Sets the instance of the <see cref="ElementReference"/> to use.
        /// </summary>
        private ElementReference NewListModal { get; set; }

        /// <summary>
        /// Creating a new list.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task NewList()
        {
            this.newTodoList = new TodoListResponse();

            await Task.Delay(500);
            if (this.TitleInput.Context != null)
            {
                await this.TitleInput.FocusAsync();
            }
        }

        /// <summary>
        /// Adding item to list.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task CreateNewList()
        {
            var list = await this.State.TodoListService.PostTodoListAsync(this.newTodoList);
            this.State.TodoLists.Add(list);

            await this.SelectList(list);
            this.State.JS.InvokeVoid(JsInteropConstants.HideModal, this.NewListModal);
        }

        /// <summary>
        /// Check if a list is selected.
        /// </summary>
        /// <param name="list">The todo list.</param>
        /// <returns>A boolean value.</returns>
        private bool IsSelected(TodoListResponse list)
        {
            return this.State.SelectedList.Id == list.Id;
        }

        /// <summary>
        /// Select a list.
        /// </summary>
        /// <param name="list">The todo list.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task SelectList(TodoListResponse list)
        {
            if (this.IsSelected(list))
            {
                return;
            }

            this.State.SelectedList = await this.State.TodoListService.GetTodoListAsync(list.Id);
        }
    }
}
